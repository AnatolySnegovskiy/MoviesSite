using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Movies.HtmlHelpers
{
    public static class VideoHelper
    {
        public static MvcHtmlString YoutubeBlock(this HtmlHelper html, string Link)
        {
            StringBuilder result = new StringBuilder();
            if (Link.Contains("watch"))
            {
                Link = Link.Replace("watch?v=", "embed/");
            }

            TagBuilder tag = new TagBuilder("iframe");
            tag.MergeAttribute("class", "w-100");
            tag.MergeAttribute("height", "315");
            tag.MergeAttribute("src", Link);
            tag.MergeAttribute("allow", "accelerometer");
            tag.MergeAttribute("picture-in-picture", "");
            result.Append(tag.ToString());

            return MvcHtmlString.Create(result.ToString());
        }
    }
}