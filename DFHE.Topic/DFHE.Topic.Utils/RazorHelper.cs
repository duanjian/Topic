using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using RazorEngine;
using RazorEngine.Templating;

namespace DFHE.Topic.Utils
{


    public class RazorHelper
    {

        public RazorHelper()
        {
            if (AppDomain.CurrentDomain.IsDefaultAppDomain())
            {
                // RazorEngine cannot clean up from the default appdomain...               
                AppDomainSetup adSetup = new AppDomainSetup();
                adSetup.ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                var current = AppDomain.CurrentDomain;
                // You only need to add strongnames when your appdomain is not a full trust environment.
                var strongNames = new StrongName[0];

                var domain = AppDomain.CreateDomain(
                    "RazorDomain", null,
                    current.SetupInformation, new PermissionSet(PermissionState.Unrestricted),
                    strongNames);
                var exitCode = domain.ExecuteAssembly(Assembly.GetExecutingAssembly().Location);
                // RazorEngine will cleanup. 
                AppDomain.Unload(domain);                
            }           
        }
        /// <summary>
        /// 模版文件名
        /// </summary>
        public string TemplateName { get; set; }

        /// <summary>
        /// 输出页面路径
        /// </summary>
        public string OutputFolderPath { get; set; }
        
        /// <summary>
        /// 静态页面名
        /// </summary>
        public string StaticPageName { get; set; }

        /// <summary>
        /// 模版键
        /// </summary>
        public string TemplateKey { get; set; }

        /// <summary>
        /// 模版解析对象
        /// </summary>
        public Object ParseObject { get; set; }

        public void GenerateHtml()
        {
            TemplateName = string.Format("{0}{1}",System.Web.HttpRuntime.AppDomainAppPath,TemplateName);

            var template = System.IO.File.ReadAllText(TemplateName, System.Text.Encoding.UTF8);

            var fullPath = string.Format("{0}{1}\\{2}",System.Web.HttpRuntime.AppDomainAppPath,OutputFolderPath, StaticPageName);
            
            var dir = Path.GetDirectoryName(fullPath);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            using (StreamWriter writer = new StreamWriter(fullPath, false, System.Text.Encoding.UTF8, 200))
            {
                //var ret = Engine.Razor.RunCompile(template, "templateKey", null, ParseObject);
                var ret = Engine.Razor.RunCompile(template, template, null, ParseObject);

                writer.Write(ret);
                writer.Flush();                    
                writer.Close();
            }
        }
    }
}
