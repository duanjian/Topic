using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFHE.Topic.Model;

namespace DFHE.Topic.IService
{
    public interface ITopicService
    {
        /// <summary>
        /// 增加新专题
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        Task<ResultVO> Insert(Topic.Model.Topic topic);

        /// <summary>
        /// 生成静态页
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        //Task GenerateStaticPage(Object survey, string tmplName, string staticPageName);
    }
}
