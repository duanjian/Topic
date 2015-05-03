using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFHE.Topic.Model
{
    public partial class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public string Remark { get; set; }
    }
}
