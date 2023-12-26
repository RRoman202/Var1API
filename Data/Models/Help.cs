using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Help
    {
        public Guid Id { get; set; }
        public DateTime IssueDate { get; set; }
        public int Money { get; set; }
        [Required]
        public string HelpBasis { get; set; }
    }
}
