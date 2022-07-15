using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using Nrun.Domain;
using Nrun.Users.Dto;

namespace Nrun.Post.Dto
{
    public class PostDto : EntityDto<long>, IHasCreationTime
    {
        public string Text { get; set; }

        public string Image { get; set; }

        public UserDto User { get; set; }

        public DateTime CreationTime { get; set; }

        public int LikeCount { get; set; }

        public bool IsLikeedByCurrentUser { get; set; }

        public List<CommentDto> Comments { get; set; }
        
    }
}