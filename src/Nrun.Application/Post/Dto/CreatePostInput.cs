using Microsoft.AspNetCore.Http;

namespace Nrun.Post.Dto
{
    public class CreatePostInput
    {
        public string Text { get; set; }

        public string Image { get; set; }
    }
}