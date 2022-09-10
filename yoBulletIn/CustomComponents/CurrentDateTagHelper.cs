using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yoBulletIn.CustomComponents
{
    public class CurrentTime : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Content.SetContent(DateTime.Now.ToString("HH:mm:ss"));
        }
    }
}
