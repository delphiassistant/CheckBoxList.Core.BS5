using CheckBoxList.Core.BS5.Models;
using System.Collections.Generic;
using System.Text;

namespace CheckBoxList.Core.BS5.Templates
{
    /// <summary>
    /// Template generator that generates basic check box list markup using Bootstrap 5
    /// </summary>
    internal class Bootstrap5BasicTemplateGenerator : ITemplateGenerator
    {
        public string Generate(string name, List<CheckBoxItem> items)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < items.Count; i++)
            {
                string checkedValue = items[i].IsChecked ? "checked" : string.Empty;
                string disabledValue = items[i].IsDisabled ? "disabled" : string.Empty;
                string nameValue = name;
                string idValue = $"{name}_{i}";

                stringBuilder.Append(
                    $"<div class=\"form-check\">" +
                        $"<input class=\"form-check-input\" type=\"checkbox\" name=\"{nameValue}\" value=\"{items[i].Id}\" id=\"{idValue}\" {checkedValue} {disabledValue}>" +
                        $"<label class=\"form-check-label\" for=\"{idValue}\">{items[i].Title}</label>" +
                    "</div>"
                );
            }

            return stringBuilder.ToString();
        }
    }
}
