using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_FSSP
{
    public partial class FsspViolator
    {
        public long Id { get; set; }
        public DateTime Birthdate { get; set; }
        public string Comment { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string BirthPlace { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
