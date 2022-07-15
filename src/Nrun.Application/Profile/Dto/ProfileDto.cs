using Nrun.Users.Dto;

namespace Nrun.Profile.Dto
{
    public class ProfileDto
    {
        public UserDto User { get; set; }

        public int PostCount { get; set; }

        public int FollwerCount { get; set; }

        public int FollowingCount { get; set; }
    }
}