using System;
using System.Collections.Generic;
using System.Text;

namespace CheckBoxList.Core.BS5.Models
{
    /// <summary>
    /// Template types for checkbox type input
    /// </summary>
    public enum TemplateType
    {
        /// <summary>
        /// Basic HTML markup
        /// </summary>
        Basic,

        /// <summary>
        /// Basic checkbox input markup using Bootstrap 3
        /// </summary>
        Bootstrap3Basic,

        /// <summary>
        /// Inline checkbox input markup using Bootstrap 3
        /// </summary>
        Bootstrap3Inline,

        /// <summary>
        /// Basic checkbox input markup using Bootstrap 5 form-check
        /// </summary>
        Bootstrap5Basic,

        /// <summary>
        /// Inline checkbox input markup using Bootstrap 5 form-check-inline
        /// </summary>
        Bootstrap5Inline
    }
}
