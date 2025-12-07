using CheckBoxList.Core.BS5.Factory;
using CheckBoxList.Core.BS5.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;

namespace CheckBoxList.Core.BS5.TagHelpers
{
    public class CheckBoxListTagHelper : TagHelper
    {
        public string Name { get; set; }
        public List<CheckBoxItem> Items { get; set; }
        public TemplateType Template { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (Items == null)
            {
                throw new Exception("item property of checkbox-list cannot be null");
            }

            if (String.IsNullOrEmpty(Name))
            {
                throw new Exception("name property of checkbox-list cannot be null or empty");
            }

            output.TagName = string.Empty;
            var templateGenerator = TemplateGeneratorFactory.GetTemplateGenerator(Template);
            var template = templateGenerator.Generate(Name, Items);
            output.Content.SetHtmlContent(template);
        }
    }
}
