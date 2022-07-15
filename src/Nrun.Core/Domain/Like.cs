using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Nrun.Authorization.Users;

namespace Nrun.Domain
{
    public class Like : FullAuditedEntity<long>
    {
        public long PostId { get; set; }
        [ForeignKey(nameof(PostId))] public Post Post { get; set; }

        [ForeignKey(nameof(CreatorUserId))] public User CreatorUser { get; set; }
    }
}