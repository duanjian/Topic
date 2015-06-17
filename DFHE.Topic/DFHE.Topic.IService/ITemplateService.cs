using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFHE.Topic.Model;

namespace DFHE.Topic.IService
{
    public interface ITemplateService
    {
        /// <summary>
        /// 添加新模版
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        Task<ResultVO> Insert(TemplateVO template);

        /// <summary>
        /// 生成示例
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        Task<ResultVO> GenerateSample(TemplateVO template);
    }
}
