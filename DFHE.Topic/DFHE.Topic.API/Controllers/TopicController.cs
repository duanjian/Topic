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
        [ODataRoute]
        [EnableQuery]
        public IHttpActionResult Get()
        {
            return Ok(ServiceLocator.Query<Topic.Model.Topic>());
        }

        /// <summary>
        /// 新增专题
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Post(Topic.Model.Topic topic)
        {
            ServiceLocator.Service<ITopicService>().Insert(topic);
            return Ok();
        }
    }
}
