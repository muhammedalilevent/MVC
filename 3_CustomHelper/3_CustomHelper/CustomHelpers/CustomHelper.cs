using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace _3_CustomHelper
{
    public static class CustomHelper
    {
        /*
         * MvcHtmlString : Yeni bir helper oluşturmak yada var olanın değiştirilmiş halini kullanabilmeniz için kullanılan sınıftır
         */

        public static string SayfayaGit(string name)
        {
            return "<a href='" + name + "'>" + name + "</a>";
        }
        public static MvcHtmlString SayfayaGit(this HtmlHelper helper, string href, string text, string id, string style, string styleClass)
        {
            var builder = new TagBuilder("a");
            builder.Attributes.Add("href", href);
            builder.Attributes.Add("style", style);
            builder.Attributes.Add("class", styleClass);
            builder.InnerHtml = text;
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }
        public static MvcHtmlString Resim(this HtmlHelper helper, string src, string title, int width, int height)
        {
            var builder = new TagBuilder("img");
            builder.Attributes.Add("src", src);
            builder.Attributes.Add("title", title);
            builder.Attributes.Add("width", width.ToString());
            builder.Attributes.Add("height", height.ToString());
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString DeleteActionLink(this HtmlHelper helper, string linkText, string actionName, string controllerName, object routeValue = null, object htmlAttributes = null)
        {
            var routeValueDict = new RouteValueDictionary(routeValue);
            var customAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            if (!customAttributes.ContainsKey("rel"))
            {
                customAttributes.Add("rel", "nofollow");
            }

            return helper.ActionLink(linkText, actionName, controllerName, routeValueDict, customAttributes);
        }
        public static MvcHtmlString UpdateButton(this HtmlHelper htmlHelper, string controller, string action, object routeValues = null, object htmlAttributes = null, object iconAttributes = null)
        {
            var routeValueDict = new RouteValueDictionary(routeValues);
            var customAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var spanCustomAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(iconAttributes);
            var builder = new TagBuilder("a");
            builder.MergeAttribute("href", $"/{controller}/{action}/{string.Join("/", routeValueDict.Values)}");
            builder.MergeAttributes(customAttributes);

            var span = new TagBuilder("span");
            span.MergeAttributes(spanCustomAttributes);
            span.ToString(TagRenderMode.SelfClosing);

            builder.InnerHtml += span.ToString();

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }
    }
}