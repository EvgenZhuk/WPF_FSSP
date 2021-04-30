using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_FSSP
{
    public partial class Role
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
