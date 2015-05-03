using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFHE.Topic.Model
{
    public partial class Page
    {
        public int ID { get; set; }
        public Nullable<int> TopicID { get; set; }
        public string PageTitle { get; set; }
        public string PageContent { get; set; }
        public Nullable<int> CreateID { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public string Remark { get; set; }
    }
}
