using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using AnaliseVendas.Entities;

namespace Course
{
    class program
    {
        static void Main(string[] arg)
        {
            Console.Write("Entre o caminho do arquivo: ");
            string path = Console.ReadLine();
            Console.WriteLine();

            List <Sale> list = new List<Sale>();
            
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] fields = sr.ReadLine().Split(',');
                        int month = int.Parse(fields[0]);
                        int year = int.Parse(fields[1]);
                        string seller = fields[2];
                        int items = int.Parse(fields[3]);
                        double total = double.Parse(fields[4],CultureInfo.InvariantCulture);
                        list.Add(new Sale(month, year, seller, items, total));
                    }

                    var maior5vendas = list.Where(obj => obj.Year == 2016).OrderByDescending(obj => obj.AveragePrice()).Take(5);
                    var sumLogan = list.Where(obj => (obj.Month == 1 || obj.Month == 7) && obj.Seller == "Logan").Sum(obj=>obj.Total);
                    
                    Console.WriteLine("Cinco primeiras vendas de 2016 de maior preço médio");
                    
                    foreach (Sale obj in maior5vendas)
                    {
                        Console.WriteLine(obj);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Valor total vendido pelo vendedor Logan nos meses 1 e 7 = "+sumLogan);
                }
            }
            catch (Exception e) 
            {
                Console.Write("error: ");
                Console.Write(e.Message);
            }
            
        }
    }
}