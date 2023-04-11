
using System.Web.Mvc;

namespace CelilCavus.Departman.web.CustomHtmlHelperMethods
{
    public static class CustomButton
    {
        public static MvcHtmlString Button(this HtmlHelper html, string ButtonText, string buttonClass, type type = type.submit)
        {
            TagBuilder builder = new TagBuilder("<button>");
            builder.AddCssClass(buttonClass);
            builder.SetInnerText(ButtonText);
            builder.MergeAttribute("type", type.ToString());
            return MvcHtmlString.Create(builder.ToString());
        }
    }

    public enum type
    {
        submit,
        reset,
        none
    }
}