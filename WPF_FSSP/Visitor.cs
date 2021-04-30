using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_FSSP
{
    public partial class Visitor
    {
        public Visitor()
        {
            VisitorToCourtStations = new HashSet<VisitorToCourtStation>();
            VisitorViolationChecks = new HashSet<VisitorViolationCheck>();
        }

        public long Id { get; set; }
        public DateTime? Birthdate { get; set; }
        public long CourtObjectId { get; set; }
        public DateTime? ExitDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int State { get; set; }
        public DateTime? VisitDate { get; set; }
        public DateTime ProcessDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string Commentary { get; set; }
        public long? ServiceOrganizationId { get; set; }
        public long PersonId { get; set; }

        public virtual CourtObject CourtObject { get; set; }
        public virtual ServiceOrganization ServiceOrganization { get; set; }
        public virtual AcsSessionsInfo AcsSessionsInfo { get; set; }
        public virtual IdentityDocument IdentityDocument { get; set; }
        public virtual ICollection<VisitorToCourtStation> VisitorToCourtStations { get; set; }
        public virtual ICollection<VisitorViolationCheck> VisitorViolationChecks { get; set; }
    }
}
