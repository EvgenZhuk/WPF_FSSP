using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_FSSP
{
    public partial class UserRole
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public long? CourtObjectId { get; set; }

        public virtual CourtObject CourtObject { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
