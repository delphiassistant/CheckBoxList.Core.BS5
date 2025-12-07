using CheckBoxList.Core.BS5.Models;
using CheckBoxList.Core.BS5.Templates;

namespace CheckBoxList.Core.BS5.Factory
{
    /// <summary>
    /// Factory class used to generate Template generator
    /// </summary>
    internal static class TemplateGeneratorFactory
    {

        /// <summary>
        /// Returns template generator for template type
        /// </summary>
        /// <param name="templateType">Template type</param>
        /// <returns>Template Generator for template type</returns>
        internal static ITemplateGenerator GetTemplateGenerator(TemplateType templateType)
        {
            switch(templateType)
            {
                case TemplateType.Bootstrap3Basic:
                    return new Bootstrap3BasicTemplateGenerator();
                case TemplateType.Bootstrap3Inline:
                    return new Bootstrap3InlineTemplateGenerator();
                case TemplateType.Bootstrap5Basic:
                    return new Bootstrap5BasicTemplateGenerator();
                case TemplateType.Bootstrap5Inline:
                    return new Bootstrap5InlineTemplateGenerator();
                default:
                    return new BasicTemplateGenerator();
            }
        }
    }
}
