﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace MobileShop.Views.HtmlHelpers
{
    public static class ResourceRenderHelper
    {
        public static IHtmlString Resource(this HtmlHelper HtmlHelper, Func<object, HelperResult> Template, string Type)
        {
            if (HtmlHelper.ViewContext.HttpContext.Items[Type] != null) ((List<Func<object, HelperResult>>)HtmlHelper.ViewContext.HttpContext.Items[Type]).Add(Template);
            else HtmlHelper.ViewContext.HttpContext.Items[Type] = new List<Func<object, HelperResult>>() { Template };

            return new HtmlString(String.Empty);
        }
        public static IHtmlString RenderResources(this HtmlHelper HtmlHelper, string Type)
        {
            if (HtmlHelper.ViewContext.HttpContext.Items[Type] != null)
            {
                List<Func<object, HelperResult>> Resources = (List<Func<object, HelperResult>>)HtmlHelper.ViewContext.HttpContext.Items[Type];

                foreach (var Resource in Resources)
                {
                    if (Resource != null) HtmlHelper.ViewContext.Writer.Write(Resource(null));
                }
            }

            return new HtmlString(String.Empty);
        }
    }
}