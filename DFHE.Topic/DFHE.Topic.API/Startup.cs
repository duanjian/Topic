using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using DFHE.Topic.Model;
using Microsoft.OData.Edm;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(DFHE.Topic.API.Startup))]

namespace DFHE.Topic.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888

            ConfigureAuth(app);

            HttpConfiguration config = new HttpConfiguration();

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            #region Wep API 配置

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //移除XML格式支持
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            #endregion

            #region OData配置

            //启用OData支持
            config.MapODataServiceRoute(routeName: "OData", routePrefix: "odata", model: GetEdmModel());
            //app.UseWebApi(config);

            #endregion

            #region 跨域配置

            //var cors = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(cors);

            #endregion

            app.UseWebApi(config);

        }



        /// <summary>
        /// OData查询对象配置
        /// </summary>
        /// <returns></returns>
        private IEdmModel GetEdmModel()
        {

            var modelBuilder = new ODataConventionModelBuilder();

            modelBuilder.EntitySet<Topic.Model.Topic>("Topic");

            modelBuilder.EntitySet<Template>("Template");

            return modelBuilder.GetEdmModel();
        }
    }
}
