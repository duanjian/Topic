using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFHE.Topic.Model
{
    public partial class Template
    {
        public int ID { get; set; }
        public string TemplateTitle { get; set; }
        public string TemplateContent { get; set; }
        public Nullable<int> Type { get; set; }
        public string URI { get; set; }
        public string ImageURI { get; set; }
        public Nullable<int> CreateID { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public string Remark { get; set; }
    }
}
