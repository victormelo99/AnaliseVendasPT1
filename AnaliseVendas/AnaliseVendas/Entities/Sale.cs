using System;
using System.Globalization;

namespace AnaliseVendas.Entities
{
    internal class Sale
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public string Seller { get; set; }
        public int Items { get; set; }
        public double Total { get; set; }

        public Sale(int month, int year, string seller, int items, double total)
        {
            Month = month;
            Year = year;
            Seller = seller;
            Items = items;
            Total = total;
        }

        public  double AveragePrice()
        {
            return Total / Items;
        }

        public override string ToString()
        {
            return Month
                   + "/"
                   + Year
                   + ","
                   + Seller
                   + ","
                   + Items
                   + ","
                   + Total.ToString("f2", CultureInfo.InvariantCulture)
                   + ", pm = "
                   + AveragePrice().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
