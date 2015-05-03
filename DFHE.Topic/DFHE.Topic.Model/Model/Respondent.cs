using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFHE.Topic.Model
{
    public partial class Respondent
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public Nullable<int> Age { get; set; }
        public string Gender { get; set; }
        public string Education { get; set; }
        public string Occupation { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public string MaritalStatus { get; set; }
        public string Referrer { get; set; }
        public string Suggestion { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public string Remark { get; set; }
    }
}
