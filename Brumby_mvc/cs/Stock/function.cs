using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brumby_mvc.cs.Stock
{
    public class function
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

        /// <summary>
        /// Solar to vids with dash
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public string SolarToVidsDash(string date)
        {
            string[] dateSplit = date.Trim().Split('/');
            string year = (Convert.ToInt32(dateSplit[0]) + 1911).ToString();
            string returnDate = "";
            returnDate = $"{year}-{dateSplit[1]}-{dateSplit[2]}";
            return returnDate;
        }

        /// <summary>
        /// Solar to vids
        /// </summary>
        /// <param name="date">108/08/08</param>
        /// <param name="Slash">return with slash 2019/08/08</param>
        /// <returns></returns>
        public string SolarToVids(string date, bool Slash)
        {

            string[] dateSplit = date.Trim().Split('/');
            string year = (Convert.ToInt32(dateSplit[0]) + 1911).ToString();
            string returnDate = "";
            if (Slash)
                returnDate = $"{year}/{dateSplit[1]}/{dateSplit[2]}";
            else
                returnDate = $"{year}{dateSplit[1]}{dateSplit[2]}";

            return returnDate;
        }
    }
}