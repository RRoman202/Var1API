using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class TravelApplication
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public bool Accepted { get; set; }
        public Member ApplicationIssuer { get; set; }
    }
}
