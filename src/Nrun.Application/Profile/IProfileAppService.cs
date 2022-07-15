using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Http;
using Nrun.Post.Dto;
using Nrun.Profile.Dto;
using Nrun.Users.Dto;

namespace Nrun.Profile
{
    public interface IProfileAppService : IApplicationService
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateProfile(ProfileInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        Task UpdateProfilePhoto(IFormFile file);

        //get own profile 
        /// <summary>
        /// get own profile 
        /// </summary>
        /// <returns></returns>
        Task<ProfileDto> GetOwnProfile();

        /// <summary>
        /// get user profile by id  
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ProfileDto> GetProfile(EntityDto<long> input);

        /// <summary>
        /// follow un follow 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Follow(LikeInput input);
        
        /// <summary>
        /// get followers
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<List<UserDto>> GetFollowers(EntityDto<long> input);
        
        /// <summary>
        /// get followings
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<List<UserDto>> GetFollowings(EntityDto<long> input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        Task<string> Upload(IFormFile file);

    }
}