using System.Web.Mvc;

namespace EFCodeFirstApproachExample.HtmlHelpers
{
    public static class CustomHtmlHelper
    {
        public static MvcHtmlString File(this HtmlHelper htmlHelper, string classTag, string idTag, string nameTag)
        {
            TagBuilder tag = new TagBuilder("input");
            tag.MergeAttribute("type", "file");
            tag.MergeAttribute("class", classTag);
            tag.MergeAttribute("id", idTag);
            tag.MergeAttribute("name", nameTag);
            return new MvcHtmlString(tag.ToString(TagRenderMode.SelfClosing));
        }
    }
}