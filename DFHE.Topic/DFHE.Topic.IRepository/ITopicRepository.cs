using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFHE.Topic.Model;

namespace DFHE.Topic.IRepository
{
    public interface ITopicRepository : IBaseRepository<Topic.Model.Topic> 
    {
        /// <summary>
        /// 添加新专题
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        //Task<Topic.Model.Topic> Insert(Model.Topic topic);

    }
}
