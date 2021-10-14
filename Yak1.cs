using System;
using System.Xml;
using BNG;

namespace Yak_1
{
    class Yak1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The XML file to read");
            XmlDocument doc = new XmlDocument();
            string xmlFile = Console.ReadLine();
            doc.Load(xmlFile);
            XmlNodeList yaks = doc.SelectNodes("herd/labyak");
            Console.WriteLine("elapsed days");
            int days = Int32.Parse(Console.ReadLine());

            decimal yakAge;
            int wool = 0;
            decimal milk = 0;
            YakInfo yakInfo = new YakInfo();
            Console.WriteLine("Herd:");
            decimal ageAfter;
            string name;
            Console.WriteLine("Herd:");
            foreach (XmlNode yak in yaks)
            {
                yakAge = decimal.Parse(yak.Attributes["age"].Value, System.Globalization.CultureInfo.InvariantCulture);
                name = yak.Attributes["name"].Value;
                milk = milk + yakInfo.GetYakMilk(yakAge, days);
                wool = wool + yakInfo.GetYakWool(yakAge, days);
                ageAfter = yakAge + ((decimal)0.01 * days);
                Console.WriteLine("{0} {1} years old", name, ageAfter);
            }

            Console.WriteLine("In Stock:");
            Console.WriteLine("{0} liters of milk", milk);
            Console.WriteLine("{0} skins of wool", wool);

        }
    }
}
