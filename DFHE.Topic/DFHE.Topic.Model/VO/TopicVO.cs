using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFHE.Topic.Model
{
    public class TopicVO
    {
        public string Title { get; set; }

        public int Type { get; set; }

        public int TemplateId { get; set; }

        public int PageCount { get; set; }

        public int[] RequiredInfo { get; set; }

        public int SubmitType { get; set; }

        public string RedirectURI { get; set; }

        public IList<PageVO> Pages { get; set; }
        

    }
}
