using System;
using Abp.Domain.Entities.Auditing;
using Nrun.Users.Dto;

namespace Nrun.Post.Dto
{
    public class CommentDto : IHasCreationTime
    {
        public string Text { get; set; }
        
        public UserDto CreatorUser { get; set; }
        public DateTime CreationTime { get; set; }
    }
}