using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFHE.Topic.Model
{
    public partial class Topic
    {
        public int ID { get; set; }
        public string TopicTitle { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<int> TemplateId { get; set; }
        public Nullable<int> PageCount { get; set; }
        public string StaticURI { get; set; }
        public Nullable<int> SubmitType { get; set; }
        public string LocateURI { get; set; }
        public string RequiredInfos { get; set; }
        public Nullable<int> CreateId { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public string Remark { get; set; }
    }
}
