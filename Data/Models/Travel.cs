using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Travel
    {
        public Guid Id { get; set; }
        public bool IsHelpful { get; set; }
        public string Name { get; set; }
        public int Days { get; set; }
        public DateTime StartDate {  get; set; }
    }
}
