using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.IO.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Nrun.Authorization.Users;
using Nrun.Domain;
using Nrun.Post.Dto;
using Nrun.Profile.Dto;
using Nrun.Users.Dto;

namespace Nrun.Profile
{
    [AbpAuthorize()]
    public class ProfileAppService : NrunAppServiceBase, IProfileAppService
    {
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<Domain.Post, long> _postRepository;
        private readonly IRepository<Follow, long> _followRepository;

        public ProfileAppService(IRepository<User, long> userRepository, IRepository<Domain.Post, long> postRepository,
            IRepository<Follow, long> followRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
            _followRepository = followRepository;
        }

        public async Task UpdateProfile(ProfileInput input)
        {
            await _userRepository.UpdateAsync(AbpSession.UserId.Value, async (x) => { x.Name = input.Name;
                x.Image = input.Image;
            });

            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task UpdateProfilePhoto(IFormFile file)
        {
            //
        }

        public async Task<ProfileDto> GetOwnProfile()
        {
            var user = await _userRepository.FirstOrDefaultAsync(x => x.Id == AbpSession.UserId.Value);

            return new ProfileDto()
            {
                User = ObjectMapper.Map<UserDto>(user),
                FollowingCount = await _followRepository.CountAsync(x => x.CreatorUserId == user.Id),
                FollwerCount = await _followRepository.CountAsync(x => x.TargetUserId == user.Id),
                PostCount = await _postRepository.CountAsync(x => x.CreatorUserId == user.Id)
            };
        }

        public async Task<ProfileDto> GetProfile(EntityDto<long> input)
        {
            var user = await _userRepository.FirstOrDefaultAsync(x => x.Id == input.Id);

            return new ProfileDto()
            {
                User = ObjectMapper.Map<UserDto>(user),
                FollowingCount = await _followRepository.CountAsync(x => x.CreatorUserId == user.Id),
                FollwerCount = await _followRepository.CountAsync(x => x.TargetUserId == user.Id),
                PostCount = await _postRepository.CountAsync(x => x.CreatorUserId == user.Id)
            };
        }

        public async Task Follow(LikeInput input)
        {
            var exist = await _followRepository.FirstOrDefaultAsync(x =>
                x.TargetUserId == input.Id && x.CreatorUserId == AbpSession.UserId.Value);

            if (input.IsLiked && exist == null)
            {
                await _followRepository.InsertAsync(new Follow()
                {
                    TargetUserId = input.Id
                });
            }

            if (!input.IsLiked && exist != null)
            {
                await _followRepository.DeleteAsync(exist);
            }
        }

        public async Task<List<UserDto>> GetFollowers(EntityDto<long> input)
        {
            if (input.Id == 0)
            {
                input.Id = AbpSession.UserId.Value;
            }
            var users = await _followRepository.GetAll().Where(x => x.TargetUserId == input.Id)
                .ToListAsync();
            return ObjectMapper.Map<List<UserDto>>(users);
        }

        public async Task<List<UserDto>> GetFollowings(EntityDto<long> input)
        {
            if (input.Id == 0)
            {
                input.Id = AbpSession.UserId.Value;
            }
            var users = await _followRepository.GetAll().Where(x => x.CreatorUserId == input.Id)
                .ToListAsync();
            return ObjectMapper.Map<List<UserDto>>(users);
        }

        [HttpPut]
        public async Task<string> Upload(IFormFile file)
        {
            using (var client = new HttpClient())
            {
                    byte[] fileBytes = file.OpenReadStream().GetAllBytes();
                    var byteArrayContent = new ByteArrayContent(fileBytes);
                    var url = "https://www.filestackapi.com/api/store/S3?key=Ai7nZU6Q5RAeF7hYGrJuSz";
                    var result = await client.PostAsync(url, byteArrayContent);
                    var g = JsonConvert.DeserializeObject<UploadModel>(await result.Content.ReadAsStringAsync()) ;
                    return g.Url;
            }
        }
    }
}
