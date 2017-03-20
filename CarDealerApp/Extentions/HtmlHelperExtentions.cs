using CarDealer.Models.EntityModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CarDealerApp.Extentions
{
    public static class HtmlHelperExtentions
    {
        public static MvcHtmlString Image(this HtmlHelper helper, string url, string alt)
        {
            TagBuilder builder = new TagBuilder("img");
            builder.AddCssClass("img-thumbnail");
            builder.MergeAttribute("src", url);
            builder.MergeAttribute("alt", alt);
            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string url)
        {
            TagBuilder builder = new TagBuilder("img");
            builder.AddCssClass("img-thumbnail");
            builder.MergeAttribute("src", url);
            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string url, string width, string height)
        {
            TagBuilder builder = new TagBuilder("img");
            builder.AddCssClass("img-thumbnail");
            builder.MergeAttribute("src", url);
            builder.MergeAttribute("width", width);
            builder.MergeAttribute("height", height);
            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString YouTube(this HtmlHelper helper, string width, string height, string videoId)
        {
            string src = $"https://www.youtube.com/embed/{videoId}";
            TagBuilder builder = new TagBuilder("iframe");
            builder.MergeAttribute("width", width);
            builder.MergeAttribute("height", height);
            builder.MergeAttribute("src", src);
            builder.MergeAttribute("frameborder", "0");
            builder.SetInnerText("allowfullscreen");
            return new MvcHtmlString(builder.ToString(TagRenderMode.Normal));
        }
        public static MvcHtmlString YouTube(this HtmlHelper helper, string videoId)
        {
            string src = $"https://www.youtube.com/embed/{videoId}";
            TagBuilder builder = new TagBuilder("iframe");
            builder.MergeAttribute("src", src);
            builder.MergeAttribute("width", "560");
            builder.MergeAttribute("height", "315");
            builder.MergeAttribute("frameborder", "0");
            builder.SetInnerText("allowfullscreen");
            return new MvcHtmlString(builder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString Table(this HtmlHelper helper, string name, IList items, IDictionary<string, object> attributes)
        {
            if (items == null || items.Count == 0 || string.IsNullOrEmpty(name))
            {
                return null;
            }

            return new MvcHtmlString(BuildTable(name, items, attributes));
        }

        private static string BuildTable(string name, IList items, IDictionary<string, object> attributes)
        {
            StringBuilder sb = new StringBuilder();
            BuildTableHeader(sb, items[0].GetType());

            foreach (var item in items)
            {
                BuildTableRow(sb, item);
            }

            TagBuilder builder = new TagBuilder("table");
            builder.AddCssClass("table table-striped");
            builder.MergeAttributes(attributes);
            builder.MergeAttribute("name", name);
            builder.InnerHtml = sb.ToString();
            return builder.ToString(TagRenderMode.Normal);
        }

        private static void BuildTableRow(StringBuilder sb, object obj)
        {
            Type objType = obj.GetType();
            sb.AppendLine("\t<tr>");
            foreach (var property in objType.GetProperties())
            {
                sb.AppendFormat($"\t\t<td>{property.GetValue(obj, null)}</td>\n");
            }
            sb.AppendLine("\t</tr>");
        }

        private static void BuildTableHeader(StringBuilder sb, Type p)
        {
            sb.AppendLine("\t<tr>");
            foreach (var property in p.GetProperties())
            {
                sb.AppendFormat("\t\t<th>{0}</th>\n", property.Name);
            }
            sb.AppendLine("\t</tr>");
        }
    }
}
