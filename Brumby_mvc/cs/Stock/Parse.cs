using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brumby_mvc.cs.Stock
{
    public class Parse
    {
        /// <summary>
        /// Find table node in html
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public HtmlNode FindTable(HtmlNode node)
        {
            if (node.ParentNode.Name.Equals("table", StringComparison.OrdinalIgnoreCase))
            {
                return node.ParentNode;
            }
            else
            {
                return FindTable(node.ParentNode);
            }
        }
    }
}