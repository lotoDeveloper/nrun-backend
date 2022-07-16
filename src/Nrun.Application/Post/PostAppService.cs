using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Nrun.Domain;
using Nrun.Post.Dto;

namespace Nrun.Post
{
    [AbpAuthorize()]
    public class PostAppService : NrunAppServiceBase, IPostAppService
    {
        private readonly IRepository<Domain.Post, long> _postRepository;
        private readonly IRepository<Like, long> _likeRepository;
        private readonly IRepository<Comment, long> _commentRepository;
        private readonly IRepository<Follow, long> _followRepository;


        public PostAppService(IRepository<Domain.Post, long> postRepository, IRepository<Like, long> likeRepository,
            IRepository<Comment, long> commentRepository, IRepository<Follow, long> followRepository)
        {
            _postRepository = postRepository;
            _likeRepository = likeRepository;
            _commentRepository = commentRepository;
            _followRepository = followRepository;
        }

        public async Task CreatePost(CreatePostInput input)
        {
            await _postRepository.InsertAsync(new Domain.Post()
            {
                Image = input.Image,
                Text = input.Text
            });

            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task DeletePost(EntityDto<long> input)
        {
            var post = await _postRepository.FirstOrDefaultAsync(input.Id);

            if (AbpSession.UserId.Value != post.CreatorUserId)
            {
                throw new AuthenticationException();
            }

            await _postRepository.DeleteAsync(post);

            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task<PostDto> GetPostById(EntityDto<long> input)
        {
            var post = await _postRepository
                .GetAll()
                .Where(x => x.Id == input.Id)
                .Include(x => x.CreatorUser)
                .Include(x => x.Likes)
                .Include(x => x.Comments)
                .ThenInclude(x=>x.CreatorUser)
                .FirstOrDefaultAsync();

            var mappedResult = ObjectMapper.Map<PostDto>(post);
            
            if (post.Likes.Any(x => x.CreatorUserId == AbpSession.UserId.Value))
            {
                mappedResult.IsLikedByCurrentUser = true;
            }

            return mappedResult;
        }

        public async Task<List<PostDto>> GetPostByUserId(EntityDto<long> input)
        {
            var posts = await _postRepository
                .GetAll()
                .Where(x => x.CreatorUserId == input.Id)
                .Include(x => x.CreatorUser)
                .Include(x => x.Likes)
                .ThenInclude(x => x.CreatorUser)
                .ToListAsync();

            var mappedResult = ObjectMapper.Map<List<PostDto>>(posts);

            foreach (var item in mappedResult)
            {
                if (posts.FirstOrDefault(x => x.Id == item.Id).Likes
                    .Any(x => x.CreatorUserId == AbpSession.UserId.Value))
                {
                    item.IsLikedByCurrentUser = true;
                }
            }

            return mappedResult;
        }


        public async Task<List<PostDto>> GetGlobalPosts(EntityDto<long> input)
        {
            var posts = await _postRepository
                .GetAll()
                .Include(x => x.CreatorUser)
                .Include(x => x.Likes)
                .Include(x => x.Comments)
                .ThenInclude(x => x.CreatorUser)
                .OrderByDescending(x => x.CreationTime)
                .ToListAsync();

            var mappedResult = ObjectMapper.Map<List<PostDto>>(posts);

            foreach (var item in mappedResult)
            {
                if (posts.FirstOrDefault(x => x.Id == item.Id).Likes
                    .Any(x => x.CreatorUserId == AbpSession.UserId.Value))
                {
                    item.IsLikedByCurrentUser = true;
                }
            }

            return mappedResult;
        }


        public async Task<List<PostDto>> GetFollowingPosts(EntityDto<long> input)
        {
            var users = await _followRepository.GetAll().Where(x => x.CreatorUserId == input.Id).Select(x => x.Id)
                .ToListAsync();

            var posts = await _postRepository
                .GetAll()
                .Where(x => users.Contains(x.CreatorUserId.Value))
                .Include(x => x.CreatorUser)
                .Include(x => x.Likes)
                .ThenInclude(x => x.CreatorUser)
                .OrderByDescending(x => x.CreationTime)
                .ToListAsync();

            var mappedResult = ObjectMapper.Map<List<PostDto>>(posts);

            foreach (var item in mappedResult)
            {
                if (posts.FirstOrDefault(x => x.Id == item.Id).Likes
                    .Any(x => x.CreatorUserId == AbpSession.UserId.Value))
                {
                    item.IsLikedByCurrentUser = true;
                }
            }

            return mappedResult;
        }

        public async Task LikePost(LikeInput input)
        {
            var exist = await _likeRepository.FirstOrDefaultAsync(x =>
                x.PostId == input.Id && x.CreatorUserId == AbpSession.UserId.Value);

            if (input.IsLiked && exist == null)
            {
                await _likeRepository.InsertAsync(new Like()
                {
                    PostId = input.Id
                });
            }

            if (!input.IsLiked && exist != null)
            {
                await _likeRepository.DeleteAsync(exist);
            }
        }

        public async Task CommentToPost(CommentInput input)
        {
            await _commentRepository.InsertAsync(new Comment()
            {
                PostId = input.PostId,
                Text = input.Text
            });

            await CurrentUnitOfWork.SaveChangesAsync();
        }
    }
}