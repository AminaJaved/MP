using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    class Report
    {
        public int ProjectID { get; set; }
        public String description { get; set; }
        public String title { get; set; }
        public int GroupID { get; set; }
        public int AdvisorId { get; set; }
        public int AdvisorRole { get; set; }
        public string RegistrationNo { get; set; }
    }
}
