using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Storage
{
    public class WareStorage
    {
        readonly Boolean enabled = true;
        private readonly object locker = new object();
        readonly Random r = new Random();
        List<string> Goods = new List<string>();
        private int SizeOfGoods;
        private int goods = 0;
        private int maxCapacity;
        List<string> tovar = new List<string> { "Сыр", "Колбаса", "Хлеб", "Квас", "Вода", "Конфеты", "Пиво" };
        List<string> proiz = new List<string> { "XAV", "DEV", "FED", "SAD", "VOF", "GG", "ASD" };
        List<string> pokup = new List<string> { "Mr. V", "Mr. Wick", "Mr. John", "Mr. Fen", "Mr. Pan", "Mr. Dan", "Mr. Sam" };

        public WareStorage(bool enabled, int goods, int maxCapacity)
        {
            this.enabled = enabled;
            this.goods = goods;
            this.maxCapacity = maxCapacity;
        }

        public void NewGoods()
        {
            while (enabled)
            {
                if (goods <= maxCapacity)
                {
                    for (int i = 0; i < r.Next(1, 5); i++)
                    {
                        lock (locker)
                        {
                            SizeOfGoods = r.Next(1, 6);
                            goods += SizeOfGoods; 
                            string NameOfGoods = (tovar[r.Next(7)]) + " от компании " + (proiz[r.Next(7)]);
                            Goods.Add(NameOfGoods);
                            Console.WriteLine("Поставлен на склад: " + NameOfGoods + "  Количество занимаемого места: " + SizeOfGoods);
                        }
                    }
                    Thread.Sleep(1000);
                }
            }
        }
        public void LostGoods()
        {
            while (enabled)
            {
                lock (locker)
                {
                    for (int i = 0; i < r.Next(1, 5); i++)
                    {
                        SizeOfGoods = r.Next(1, 6);
                        string NameOfGoods = (tovar[r.Next(7)]) + " от компании " + (proiz[r.Next(7)]);
                        if (Goods.Contains(NameOfGoods) == true)
                        {
                            goods -= SizeOfGoods;
                            Goods.Remove(NameOfGoods);
                            Console.WriteLine("Покупатель: " + (pokup[r.Next(7)]) + "\nЗабран со склада: " + NameOfGoods + "  Количество занимаемого места: " + SizeOfGoods);
                        }
                    }
                }
                Thread.Sleep(1000);
            }
        }
        public void LostGoodsCount()
        {
            while (enabled)
            {
                lock (locker)
                {
                    if (goods > maxCapacity)
                    {
                        Console.WriteLine("Склад перегружен!  " + "Загруженность склада: " + goods);
                    }
                    else
                    {
                        Console.WriteLine("Загруженность склада: " + goods);
                    }               
                }
                Thread.Sleep(5000);
            }
        }
        public void CountGoods()
        {
            while (enabled)
            {
                lock(locker)
                {
                    foreach (string val in Goods.Distinct())
                    {
                        Console.WriteLine(val + " - " + Goods.Where(x => x == val).Count() + " штук");
                    }
                }
                Thread.Sleep(5000);
            }
                
        }
    }
}

