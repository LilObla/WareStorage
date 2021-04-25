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
}
