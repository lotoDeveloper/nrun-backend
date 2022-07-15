using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Nrun.Authorization.Users;

namespace Nrun.Domain
{
    public class Comment : FullAuditedEntity<long>
    {
        public string Text { get; set; }
        public long PostId { get; set; }
        [ForeignKey(nameof(PostId))] public Post Post { get; set; }

        [ForeignKey(nameof(CreatorUserId))] public User CreatorUser { get; set; }
    }
}