using Nrun.Users.Dto;

namespace Nrun.Post.Dto
{
    public class CommentDto
    {
        public string Text { get; set; }
        
        public UserDto CreatorUser { get; set; }
    }
}