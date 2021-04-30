using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_FSSP
{
    public partial class ServiceOrganization
    {
        public ServiceOrganization()
        {
            Visitors = new HashSet<Visitor>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Visitor> Visitors { get; set; }
    }
}
