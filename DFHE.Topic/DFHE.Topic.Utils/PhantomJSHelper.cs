using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NReco.PhantomJS;

namespace DFHE.Topic.Utils
{
    public class PhantomJSHelper
    {        

        /// <summary>
        /// 栅格化
        /// </summary>
        public static void Rasterize(IList<string> jsArgs)
        {
            string jsFile = string.Format("{0}{1}", System.Web.HttpRuntime.AppDomainAppPath, "Scripts\\PhantomJSScript\\rasterize.js");
            PhantomJS _phantomJS = new PhantomJS();
            _phantomJS.Run(jsFile, jsArgs.ToArray());                                    
        }
    }
}
