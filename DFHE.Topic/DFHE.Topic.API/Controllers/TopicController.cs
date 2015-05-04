using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;
using DFHE.Topic.Configuration;
using DFHE.Topic.IService;

namespace DFHE.Topic.API.Controllers
{
    public class TopicController : ApiController
    {
        /// <summary>
        /// 基于OData的数据查询
        /// </summary>
        /// <returns></returns>
        [ODataRoute]
        [EnableQuery]
        public IHttpActionResult Get()
        {
            try
            {
                var topic = ServiceLocator.Query<Topic.Model.Topic>();
                return Ok(topic);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 新增专题
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Post(Topic.Model.Topic topic)
        {
            try
            {
                var ret = ServiceLocator.Service<ITopicService>().Insert(topic);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }           
        }        
    }
}
