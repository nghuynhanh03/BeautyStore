using BeautyStore.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;

namespace BeautyStore.DesignPattern
{


    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class SparkleEffectAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);

            // Thêm script jQuery và CSS vào trang web
            var viewResult = filterContext.Result as ViewResult;
            if (viewResult != null)
            {
                var viewData = viewResult.ViewData;
                var scriptManager = viewData["ScriptManager"] as MvcHtmlString;
                var styleManager = viewData["StyleManager"] as MvcHtmlString;

                if (scriptManager == null)
                {
                    scriptManager = new MvcHtmlString("<script src=\"https://code.jquery.com/jquery-3.6.4.min.js\"></script>");
                    viewData["ScriptManager"] = scriptManager;
                }

                if (styleManager == null)
                {
                    styleManager = new MvcHtmlString("<style>.sparkle-effect { display: inline-block; font-size: 24px; color: #ffeb3b; } @keyframes sparkle { 0%, 100% { transform: translateY(0); } 50% { transform: translateY(-10px); } } .sparkle-animation { animation: sparkle 1s ease-in-out infinite; }</style>");
                    viewData["StyleManager"] = styleManager;
                }
            }
        }
    }


}
