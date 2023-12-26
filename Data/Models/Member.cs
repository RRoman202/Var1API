using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Member
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public int Experience { get; set; }
        public DateTime MembershipEnterDate { get; set; }
        public List<Travel> Travels { get; set; }
        public List<Help> Helps { get; set; }
    }
}
