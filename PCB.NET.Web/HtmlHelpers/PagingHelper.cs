﻿using PCB.NET.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PCB.NET.Web.HtmlHelpers
{
    public static class PagingHelper
    {
        #region PageLinksLeft
        public static MvcHtmlString PageLinksLeft(this HtmlHelper html,
            ListView listView,
            Func<int, string> pageUrl)
        {
            StringBuilder builder = new StringBuilder();

            // Prev
            var prevBuilder = new TagBuilder("a");
            var fafaAngleLeft = new TagBuilder("i");

            if (listView.CurrentPage == 1)
            {
                fafaAngleLeft.AddCssClass("fa fa-angle-double-left");
                prevBuilder.MergeAttribute("href", "#");
                prevBuilder.InnerHtml += fafaAngleLeft;
                builder.AppendLine(prevBuilder.ToString());
            }
            else
            {
                fafaAngleLeft.AddCssClass("fa fa-angle-double-left");
                prevBuilder.MergeAttribute("href", pageUrl.Invoke(listView.CurrentPage - 1));
                prevBuilder.InnerHtml += fafaAngleLeft;
                builder.AppendLine(prevBuilder.ToString());
            }

            return new MvcHtmlString(builder.ToString());
        }
        #endregion

        #region PageLinksRight

        public static MvcHtmlString PageLinksRight(this HtmlHelper html,
            ListView listView,
            Func<int, string> pageUrl)
        {
            StringBuilder builder = new StringBuilder();

            // Next
            var nextBuilder = new TagBuilder("a");
            var fafaAngleRight = new TagBuilder("i");

            if (listView.CurrentPage == listView.TotalPages)
            {
                fafaAngleRight.AddCssClass("fa fa-angle-double-right");
                nextBuilder.MergeAttribute("href", "#");
                nextBuilder.InnerHtml += fafaAngleRight;
                builder.AppendLine(nextBuilder.ToString());
            }
            else
            {
                fafaAngleRight.AddCssClass("fa fa-angle-double-right");
                nextBuilder.MergeAttribute("href", pageUrl.Invoke(listView.CurrentPage + 1));
                nextBuilder.InnerHtml += fafaAngleRight;
                builder.AppendLine(nextBuilder.ToString());
            }

            return new MvcHtmlString(builder.ToString());
        }
        #endregion

        #region PageLinks
        public static MvcHtmlString PageLinks(this HtmlHelper html,
            ListView listView,
            Func<int, string> pageUrl)
        {
            StringBuilder builder = new StringBuilder();

            // In order
            for (int i = 1; i <= listView.TotalPages; i++)
            {
                // Conditions that derive only the necessary number
                if (((i <= 3) || (i > (listView.TotalPages - 3))) || ((i > (listView.CurrentPage - 2)) && (i < (listView.CurrentPage + 2))))
                {
                    var subBuilder = new TagBuilder("a");
                    subBuilder.InnerHtml = i.ToString(CultureInfo.InvariantCulture);
                    if (i == listView.CurrentPage)
                    {
                        subBuilder.MergeAttribute("href", "#");
                        builder.AppendLine(subBuilder.ToString());
                    }
                    else
                    {
                        subBuilder.MergeAttribute("href", pageUrl.Invoke(i));
                        builder.AppendLine(subBuilder.ToString());
                    }
                }
                else if ((i == 4) && (listView.CurrentPage > 5))
                {
                    // The ellipsis first
                    builder.Append("<a href=\"#\"> <i class=\"no-active\"> ... </i></a>");
                }
                else if ((i == (listView.TotalPages - 3)) && (listView.CurrentPage < (listView.TotalPages - 4)))
                {
                    // The ellipsis second
                    builder.AppendLine("<a href=\"#\"> <i class=\"no-active\"> ... </i></a>");
                }
            }

            return new MvcHtmlString(builder.ToString());
        }
        #endregion
    }
}