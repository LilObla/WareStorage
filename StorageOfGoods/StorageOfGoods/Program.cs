using System;
using System.Collections.Generic;
using System.Threading;

namespace Storage
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = 100;
            List<Goods> Goods = new List<Goods>();
            WareStorage warestorage = new WareStorage(true, 0, maxCapacity);
            Thread TNewGoods = new Thread(new ThreadStart(warestorage.NewGoods));
            Thread TLostGoods = new Thread(new ThreadStart(warestorage.LostGoods));
            Thread TLostGoodsCount = new Thread(new ThreadStart(warestorage.LostGoodsCount));
            TNewGoods.Start();
            TLostGoods.Start();
            TLostGoodsCount.Start();
        }
    }

    public class Goods : IEquatable<Goods>
    {
        public string NameOfGoods { get; set; }

        public int SizeOfGoods { get; set; }

        public override string ToString()
        {
            return "Name: " + NameOfGoods + "    Volume: " + SizeOfGoods;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Goods objAsPart = obj as Goods;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public int SizeOfLostGoods()
        {
            return SizeOfGoods;
        }
        public bool Equals(Goods other)
        {
            if (other == null) return false;
            return (this.NameOfGoods.Equals(other.NameOfGoods));
        }
    }
}
