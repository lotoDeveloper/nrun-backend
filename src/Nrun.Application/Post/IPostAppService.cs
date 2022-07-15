using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Nrun.Post.Dto;

namespace Nrun.Post
{
    public interface IPostAppService : IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreatePost(CreatePostInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeletePost(EntityDto<long> input);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input">post id</param>
        /// <returns></returns>
        Task<PostDto> GetPostById(EntityDto<long> input);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input">user Id</param>
        /// <returns></returns>
        Task<List<PostDto>> GetPostByUserId(EntityDto<long> input);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input">post id</param>
        /// <returns></returns>
        Task LikePost(LikeInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CommentToPost(CommentInput input);
    }
}