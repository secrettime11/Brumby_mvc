using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Brumby_mvc.cs.Stock
{
    public class OTC
    {
        function function = new function();

        /// <summary>
        /// Parse OTC turnover data
        /// </summary>
        /// <param name="date">Example : 109/08/24 </param>
        /// <returns></returns>
        public Dictionary<string, string> ParseOTCTurnoverInfo(string date)
        {
            //List<Models.otcTurnoverate> result = new List<Models.otcTurnoverate>();
            Dictionary<string, string> result = new Dictionary<string, string>();
            HtmlWeb webClient = new HtmlWeb();
            var doc = webClient.Load($"https://www.tpex.org.tw/web/stock/aftertrading/daily_turnover/trn_result.php?l=zh-tw&t=D&d={date}&s=0,asc,1&o=htm");
            var table = doc.DocumentNode.SelectSingleNode("/html/body//td[contains(text(),'上櫃股票個股')]");
            if (table != null)
            {
                table = function.FindTable(table);
                var tbody = table.SelectNodes(".//tbody//tr");
                if (tbody != null)
                {
                    foreach (var tr in tbody)
                    {
                        //Models.otcTurnoverate otc = new Models.otcTurnoverate();
                        List<string> Info = new List<string>();
                        foreach (var td in tr.SelectNodes(".//td"))
                        {
                            Info.Add(td.InnerText.Trim());
                        }
                        result.Add(Info[1], Info[5]);
                        //otc.s_date = date;
                        //otc.s_rank = Convert.ToInt32(Info[0]);
                        //otc.s_id = Info[1];
                        //otc.s_name = Info[2];
                        //otc.s_deal = Info[3];
                        //otc.s_market = Info[4];
                        //otc.s_turnoverate = Convert.ToDouble(Info[5]);
                        //  0=> 排行 1=> 股票代號  5=> 周轉率
                        //result.Add(otc);
                    }
                    return result;
                }
            }
            return null;
        }

        /// <summary>
        /// Parse OTC data
        /// </summary>
        /// <param name="date">Example : 109/08/24 </param>
        /// <returns></returns>
        public List<Models.otc> ParseOTCInfo(string date)
        {
            List<Models.otc> result = new List<Models.otc>();
            try
            {
                // 抓取周轉率
                Dictionary<string, string> turnOver = ParseOTCTurnoverInfo(date);
                HtmlWeb webClient = new HtmlWeb();
                var doc = webClient.Load($"https://www.tpex.org.tw/web/stock/aftertrading/otc_quotes_no1430/stk_wn1430_result.php?l=zh-tw&o=htm&d={date}&se=EW&s=0,asc,0");
                var table = doc.DocumentNode.SelectSingleNode("/html/body//th[contains(text(),'上櫃股票每日收盤行情')]");

                if (table != null)
                {
                    table = function.FindTable(table);
                    var tbody = table.SelectNodes(".//tbody//tr");
                    if (tbody != null)
                    {
                        foreach (var tr in tbody)
                        {
                            List<string> Info = new List<string>();
                            Models.otc data = new Models.otc();
                            foreach (var td in tr.SelectNodes(".//td"))
                            {
                                Info.Add(td.InnerText.Trim());
                            }
                            

                            // 僅加入股票部分
                            if (Info[0].Length < 5)
                            {
                                data.Date = function.SolarToVids(date, false);
                                data.Id = Convert.ToInt32(Info[0].ToString());
                                data.Type = "櫃";
                                data.Name = Info[1];
                                data.Close = Convert.ToDouble(Info[2]);
                                data.UpDown = Info[3];
                                data.Open = Convert.ToDouble(Info[4]);
                                data.High = Convert.ToDouble(Info[5]);
                                data.Low = Convert.ToDouble(Info[6]);
                                data.DealVolume = Info[7];
                                data.DealPrice = Info[8];
                                data.DealNums = Info[9];
                                data.LastBuyPrice = Info[10];
                                if (turnOver.ContainsKey(Info[0]))
                                    data.TurnoverRate = turnOver[Info[0]];
                                else
                                    data.TurnoverRate = "N";

                                // 2020-04-30多出買量賣量
                                if (DateTime.Compare(DateTime.Parse(function.SolarToVidsDash(date)), DateTime.Parse("2020-04-29")) > 0)
                                {
                                    data.LastSellPrice = Info[12];
                                    data.NowCapital = Convert.ToDouble(Info[14]);
                                    data.MaxPriceT = Convert.ToDouble(Info[15]);
                                    data.MinPriceT = Convert.ToDouble(Info[16]);
                                }
                                else
                                {
                                    data.LastSellPrice = Info[11];
                                    data.NowCapital = Convert.ToDouble(Info[12]);
                                    data.MaxPriceT = Convert.ToDouble(Info[13]);
                                    data.MinPriceT = Convert.ToDouble(Info[14]);
                                }

                                result.Add(data);
                            }
                        }

                    }
                }
            }
            catch (Exception) { }
            return result;
        }
    }
}