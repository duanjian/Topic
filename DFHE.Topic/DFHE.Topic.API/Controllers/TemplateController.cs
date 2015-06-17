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
using DFHE.Topic.Model;

namespace DFHE.Topic.API.Controllers
{
    public class TemplateController : ApiController
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
                var templates = ServiceLocator.Query<Template>();
                return Ok(templates);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// 新增模版
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public IHttpActionResult Post(TemplateVO template)
        {
            try
            {
                var ret = ServiceLocator.Service<ITemplateService>().Insert(template).Result;
                return Ok(ret);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// 生成示例
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/template/sample")]
        public IHttpActionResult Sample(TemplateVO template)
        {
            try
            {
                var ret = ServiceLocator.Service<ITemplateService>().GenerateSample(template).Result;
                return Ok(ret);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}
