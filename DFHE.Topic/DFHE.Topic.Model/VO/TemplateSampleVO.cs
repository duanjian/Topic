using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFHE.Topic.Model
{
    //样式示例视图对象
    public class TemplateVO
    {
        /// <summary>
        /// 模版示例标题
        /// </summary>
        public string TemplateTitle { get; set; }

        /// <summary>
        /// 模版类型
        /// </summary>
        public TemplateType TemplateType { get; set; }

        /// <summary>
        /// 模版内容
        /// </summary>
        public string TemplateContent { get; set; }
    }
}
