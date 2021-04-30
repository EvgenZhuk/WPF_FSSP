using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_FSSP
{
    public partial class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime SyncDate { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
