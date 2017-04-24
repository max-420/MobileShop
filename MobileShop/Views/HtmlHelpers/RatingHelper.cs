using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.WebPages;

namespace MobileShop.Views.HtmlHelpers
{
    public static class RatingHelper
    {
        private const string EmptyStarUrl = "/Images/Icons/empty_star.png";
        private const string FilledStarUrl = "/Images/Icons/filled_star.png";
        private const string HalfStarUrl = "/Images/Icons/half_star.png";
        private const int starCount = 5;
        public static MvcHtmlString RatingEditor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, int>> expression,
            object htmlAttributes = null)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var propName = metadata.PropertyName;

            StringBuilder starsInner = new StringBuilder();
            TagBuilder stars = new TagBuilder("div");
            if (htmlAttributes != null)
            {
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                stars.MergeAttributes(attributes);
            }

            TagBuilder hiddenFilledImg = GetStarTag(FilledStarUrl);
            hiddenFilledImg.MergeAttribute("class", "rating_star_hidden");
            hiddenFilledImg.MergeAttribute("style", "display:none");
            starsInner.Append(hiddenFilledImg.ToString(TagRenderMode.SelfClosing));

            for (int i = 1; i <= starCount; i++)
            {
                TagBuilder img = GetStarTag(EmptyStarUrl);
                img.MergeAttribute("class", "rating_star");
                starsInner.Append(img.ToString(TagRenderMode.SelfClosing));
            }

            TagBuilder input = new TagBuilder("input");
            input.MergeAttribute("name", propName);
            input.MergeAttribute("type", "hidden");
            input.MergeAttribute("class", "rating");
            input.MergeAttribute("value", "");
            input.MergeAttributes(html.GetUnobtrusiveValidationAttributes(metadata.PropertyName, metadata));
            starsInner.Append(input.ToString(TagRenderMode.SelfClosing));
            stars.InnerHtml = starsInner.ToString();
            return MvcHtmlString.Create(stars.ToString());
        }
        public static MvcHtmlString RatingShow(this HtmlHelper html, double rating)
        {
            StringBuilder htmlStr = new StringBuilder();
            int intRating = (int)Math.Truncate(rating);
            double frPart = rating - intRating;

            string filledStarHtml = GetStarTag(FilledStarUrl).ToString(TagRenderMode.SelfClosing);
            string halfStarHtml = GetStarTag(HalfStarUrl).ToString(TagRenderMode.SelfClosing);
            string emptyStarHtml = GetStarTag(EmptyStarUrl).ToString(TagRenderMode.SelfClosing);

            htmlStr.Append(string.Join("", Enumerable.Repeat(filledStarHtml, intRating)));

            if (intRating == starCount) return MvcHtmlString.Create(htmlStr.ToString());
            if (frPart < 0.25)
            {
                htmlStr.Append(emptyStarHtml);
            }
            else if (frPart > 0.75)
            {
                htmlStr.Append(filledStarHtml);
            }
            else
            {
                htmlStr.Append(halfStarHtml);
            }
            htmlStr.Append(string.Join("", Enumerable.Repeat(emptyStarHtml, starCount - intRating - 1)));

            return MvcHtmlString.Create(htmlStr.ToString());
        }
        private static TagBuilder GetStarTag(string url)
        {
            TagBuilder img = new TagBuilder("img");
            img.MergeAttribute("src", url);
            return img;
        }
    }
}