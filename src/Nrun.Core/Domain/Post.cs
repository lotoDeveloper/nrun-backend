using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using Abp.Domain.Entities.Auditing;
using Castle.MicroKernel.Registration;
using Nrun.Authorization.Users;

namespace Nrun.Domain
{
    public class Post : FullAuditedEntity<long>
    {
        public string Text { get; set; }

        public string Image { get; set; }

        [ForeignKey(nameof(CreatorUserId))] public User CreatorUser { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}