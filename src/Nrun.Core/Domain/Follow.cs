using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Nrun.Authorization.Users;

namespace Nrun.Domain
{
    public class Follow : FullAuditedEntity<long>
    {
        [ForeignKey(nameof(CreatorUserId))] public User CreatorUser { get; set; }

        public long TargetUserId { get; set; }

        [ForeignKey(nameof(TargetUserId))] public User TargetUser { get; set; }
    }
}