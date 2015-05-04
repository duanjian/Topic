using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFHE.Survey.Utility;
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
        public async Task<ResultVO> Insert(Model.Topic topic)
        {
            ResultVO result = new ResultVO { Result = 0 };

            try
            {
                var ret = _topicRepositpry.Insert(topic);

                await GenerateStaticPage(ret, ret.StaticURI.Split("/".ToCharArray())[1].Split('.')[0]);

                result.Data = ret;
                _unitOfWork.Commit();

                result.Result = 1;
            }
            catch (Exception ex)
            {
                result.ErrorMsg = ex.Message;
            }

            return result;
        }

        public async Task<ResultVO> Update(Model.Topic topic)
        {
            ResultVO result = new ResultVO() { Result = 0 };

            try
            {
                _topicRepositpry.Update(topic);

                await GenerateStaticPage(topic, topic.StaticURI.Split("/".ToCharArray())[1].Split('.')[0]);

                _unitOfWork.Commit();

            }
            catch (Exception ex)
            {
                result.ErrorMsg = ex.Message;                
            }

            return result;
        }

        /// <summary>
        /// 生成静态页面
        /// </summary>
        /// <param name="survey"></param>
        /// <param name="tmplName"></param>
        /// <param name="staticPageName"></param>
        /// <returns></returns>
        public async Task GenerateStaticPage(Object topic, string staticPageName, string tmplName = "wapTmpl.html")
        {
            try
            {
                VelocityHelper helper = new VelocityHelper("/statics/tmpl/");
                //NVTools tools = new NVTools();
                //helper.Put("tools", tools);
                helper.Put("Topic", topic);
                await Task.Run(() => helper.GenerateHtml(tmplName, string.Format("/statics/{0}.html", staticPageName)));// ;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //return result;
        }
    }
}
