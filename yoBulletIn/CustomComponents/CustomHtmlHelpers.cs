using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;

namespace yoBulletIn.CustomComponents
{
    public static class CustomHtmlHelpers
    {
        public static IHtmlContent SubmitBtn(this IHtmlHelper htmlHelper, string btnName)
        {
            TagBuilder tb = new TagBuilder("input");
            tb.MergeAttribute("type", "submit");
            tb.MergeAttribute("value", btnName);
            tb.TagRenderMode = TagRenderMode.SelfClosing;
            var writer = new System.IO.StringWriter();
            tb.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(writer.ToString());        }
    }
}
