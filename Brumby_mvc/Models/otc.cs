using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brumby_mvc.Models
{
    public class otc
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        /// <summary>
        /// 漲跌
        /// </summary>
        public string UpDown { get; set; }
        /// <summary>
        /// 成交股數
        /// </summary>
        public string DealVolume { get; set; }
        /// <summary>
        /// 成交筆數
        /// </summary>
        public string DealNums { get; set; }
        /// <summary>
        /// 成交金額
        /// </summary>
        public string DealPrice { get; set; }
        /// <summary>
        /// 最後揭示買價
        /// </summary>
        public string LastBuyPrice { get; set; }
        /// <summary>
        /// 最後揭示賣價
        /// </summary>
        public string LastSellPrice { get; set; }
        /// <summary>
        /// 發行股數
        /// </summary>
        public double NowCapital { get; set; }
        /// <summary>
        /// 次日漲停價
        /// </summary>
        public double MaxPriceT { get; set; }
        /// <summary>
        /// 次日跌停價
        /// </summary>
        public double MinPriceT { get; set; }
        public string TurnoverRate { get; set; }
    }
}