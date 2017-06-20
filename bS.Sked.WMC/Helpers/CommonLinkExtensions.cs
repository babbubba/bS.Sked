using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace bS.Sked.WMC.Helpers
{
 public static class CommonLinkExtensions
    {
        //public static MvcHtmlString FormGroup<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
        //{
        //    var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
        //    var fieldName = ExpressionHelper.GetExpressionText(expression);
        //    var displayName = metadata.DisplayName ?? metadata.PropertyName ?? fieldName.Split('.').Last();
        //    if (String.IsNullOrEmpty(displayName))
        //    {
        //        return MvcHtmlString.Empty;
        //    }

        //    var divFormGroup = new TagBuilder("div");
        //    divFormGroup.AddCssClass("form-group");
        //    divFormGroup.MergeAttributes(htmlAttributes);


        //    var label = new TagBuilder("label");
        //    label.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(fieldName));
        //    label.AddCssClass("control-label col-md-2");
        //    label.SetInnerText(displayName);
        //    divFormGroup.InnerHtml += label.ToString(TagRenderMode.Normal);

        //    var divFormGroupInside = new TagBuilder("div");
        //    divFormGroupInside.AddCssClass("col-md-10");

        //    divFormGroupInside.InnerHtml += EditorExtensions.EditorFor(html, expression, new { htmlAttributes = new { @class = "form-control" } });
        //    divFormGroupInside.InnerHtml += ValidationExtensions.ValidationMessageFor(html, expression, "", new { htmlAttributes = new { @class = "text-danger" } });

        //    divFormGroup.InnerHtml += divFormGroupInside.ToString(TagRenderMode.Normal);

        //    return MvcHtmlString.Create(divFormGroup.ToString(TagRenderMode.Normal));
        //}

        //public static MvcHtmlString FormGroupCheckBox<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
        //{
        //    var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
        //    var fieldName = ExpressionHelper.GetExpressionText(expression);
        //    var displayName = metadata.DisplayName ?? metadata.PropertyName ?? fieldName.Split('.').Last();
        //    if (String.IsNullOrEmpty(displayName))
        //    {
        //        return MvcHtmlString.Empty;
        //    }



        //    var divFormGroup = new TagBuilder("div");
        //    divFormGroup.AddCssClass("form-group");
        //    divFormGroup.MergeAttributes(htmlAttributes);

        //    var divLabel = new TagBuilder("div");
        //    divLabel.AddCssClass("col-md-offset-2 col-md-10");

        //    var divCheckBox = new TagBuilder("div");
        //    divCheckBox.AddCssClass("checkbox");



        //    var label = new TagBuilder("label");
        //    label.InnerHtml += EditorExtensions.EditorFor(html, expression, null);
        //    label.InnerHtml += displayName;
        //    divCheckBox.InnerHtml += label.ToString(TagRenderMode.Normal);

        //    divCheckBox.InnerHtml += ValidationExtensions.ValidationMessageFor(html, expression, "", new { htmlAttributes = new { @class = "text-danger" } });
        //    divLabel.InnerHtml = divCheckBox.ToString(TagRenderMode.Normal);
        //    divFormGroup.InnerHtml = divLabel.ToString(TagRenderMode.Normal);


        //    return MvcHtmlString.Create(divFormGroup.ToString(TagRenderMode.Normal));
        //}

        public static MvcHtmlString BackToIndexLink(this HtmlHelper html)
        {
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            var url = urlHelper.Action("Index");

            // <a href="@Url.Action("Index")"><i class="fa fa-backward button-a"></i> Back to List</a>
            var aLink = new TagBuilder("a");
            aLink.Attributes.Add("href", url);
            var i = new TagBuilder("i");
            i.AddCssClass("fa fa-backward button-a");
            aLink.InnerHtml += i.ToString(TagRenderMode.Normal);
            aLink.InnerHtml += "  Back to list";

            return MvcHtmlString.Create(aLink.ToString(TagRenderMode.Normal));
        }

    }
}