using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFHE.Topic.IRepository;
using DFHE.Topic.IService;
using DFHE.Topic.Model;

namespace DFHE.Topic.Service
{
    public class TopicService : ITopicService
    {
        ITopicRepository _topicRepositpry;
        IUnitOfWork _unitOfWork;

        public TopicService(ITopicRepository topicRepository, IUnitOfWork unitOfWork)
        {
            _topicRepositpry = topicRepository;
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// 插入新专题
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        public Model.ResultVO Insert(Model.Topic topic)
        {
            ResultVO result = new ResultVO { Result = 0 };

            try
            {
                result.Data = _topicRepositpry.Insert(topic);
                _unitOfWork.Commit();
                result.Result = 1;
            }
            catch (Exception ex)
            {
                result.ErrorMsg = ex.Message;
            }

            return result;
        }
    }
}
