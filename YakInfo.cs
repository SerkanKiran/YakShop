using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Web;
using System.Xml;

namespace BNG
{
    public class YakInfo
    {
        private XmlNodeList GetYaks()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("E:/yaks/yak.xml");
            XmlNodeList nodes = doc.SelectNodes("herd/labyak");
            return nodes;
        }

        public decimal GetYakMilk(decimal age, int days)
        {
            decimal milk =0;
            decimal startAge = age;
            for(decimal i = 0; i < days; i++)
            {
                age = startAge + (i * (decimal)0.01);
                milk = milk + (50 - (100 * age) * (decimal)0.03);
            }
            return milk;
        }

        public int GetYakWool(decimal age, int days)
        {
            int wool = 1;
            int period;
            decimal startAge = age;
            int elapsedDays = 0;

            for (decimal i = 0; i < days; i++)
            {
                age = startAge + (i * (decimal)0.01);
                if (age >= 1)
                {
                    period = Decimal.ToInt32(8 + ((100 * age) * (decimal)0.01));
                    if (elapsedDays == period+1)
                    {
                        wool++;
                        elapsedDays = 0;
                    }
                    elapsedDays++;
                }

            }
            return wool;
        }

        public Stock YakStock(int days)
        {
            decimal yakAge;
            int wool = 0;
            decimal milk = 0;
            Stock stock = new Stock();
            XmlNodeList yaks = GetYaks();
            foreach (XmlNode yak in yaks)
            {
                yakAge = decimal.Parse(yak.Attributes["age"].Value, System.Globalization.CultureInfo.InvariantCulture);
                milk = milk + GetYakMilk(yakAge, days);
                wool = wool + GetYakWool(yakAge, days);
            }
            stock.milk = Math.Round(milk, 2);
            stock.skins = wool;
            return stock;
        }

        public JObject InitOrder(int days, Stock order)
        {
            Stock orderResp = new Stock();
            Stock stock = YakStock(days);

            JObject JOrder = new JObject();
            if (order.milk <= stock.milk)
            {
                JOrder.Add("milk", order.milk);
            }

            if(order.skins <= stock.skins)
            {
                JOrder.Add("skins", order.skins);
            }


            return JOrder;
        }
    }
}