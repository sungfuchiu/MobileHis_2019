using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MobileHis_2019.Areas.Settings.Views
{
    public static class SettingHtmlHelper
    {
        public static MvcHtmlString SettingTextBox<TModel, TValue>(this HtmlHelper<TModel> html,
               Expression<Func<TModel, TValue>> expression)
        {
            return SettingTextBox(html,expression, null);
        }
        public static MvcHtmlString SettingTextBox<TModel, TValue>(this HtmlHelper<TModel> html, 
            Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            string fieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? fieldName.Split('.').Last();

            TagBuilder builder = new TagBuilder("label");
            builder.InnerHtml = labelText +
                html.TextBoxFor(expression, htmlAttributes).ToHtmlString() +
                html.ValidationMessageFor(expression, "", htmlAttributes).ToHtmlString();
            return MvcHtmlString.Create(builder.ToString());
        }
    }
}