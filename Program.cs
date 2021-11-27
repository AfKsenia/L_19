using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_19
{
    class Computer
    {
        public int Code { get; set; }
        public string Mark { get; set; }
        public string ProcTipe { get; set; }
        public double CPU { get; set; }
        public int Ram { get; set; }
        public int DiskVol { get; set; }
        public int CardMem { get; set; }
        public double Cost { get; set; }
        public int Count { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Computer> listComputer = new List<Computer>()
            {
                new Computer(){Code=123456, Mark="Asus", ProcTipe="Core i7", CPU=1.8, Ram=16, DiskVol=512, CardMem=4, Cost=899.56, Count=30},
                new Computer(){Code=987654, Mark="Aser", ProcTipe="Core i9", CPU=2.1, Ram=8, DiskVol=512, CardMem=4, Cost=995.52, Count=8},
                new Computer(){Code=654468, Mark="Apple", ProcTipe="M1 Pro", CPU=1.8, Ram=16, DiskVol=512, CardMem=4, Cost=1589.99, Count=10},
                new Computer(){Code=126897, Mark="HP", ProcTipe="Athlon", CPU=2.4, Ram=16, DiskVol=128, CardMem=4, Cost=427.45, Count=40},
                new Computer(){Code=578463, Mark="Dell", ProcTipe="Pentium", CPU=1.8, Ram=8, DiskVol=256, CardMem=4, Cost=687.23, Count=5},
                new Computer(){Code=852963, Mark="Lenovo", ProcTipe="Core i7", CPU=1.9, Ram=8, DiskVol=512, CardMem=4, Cost=842.77, Count=20},
                new Computer(){Code=741258, Mark="HP", ProcTipe="Core i5", CPU=1.8, Ram=16, DiskVol=512, CardMem=4, Cost=843.88, Count=26},
                new Computer(){Code=853941, Mark="Asus", ProcTipe="Core i9", CPU=2.6, Ram=16, DiskVol=512, CardMem=4, Cost=853.25, Count=3},
            };
            Console.WriteLine("Группировка по типу процессора");

            Console.WriteLine("Выберите тип процессора \nCore i7 \nCore i9 \nM1 Pro \nAthlon \nPentium \nCore i5 ");
            Console.WriteLine();
            string prtype = Console.ReadLine();

            List<Computer> computers1 = (from d in listComputer
                                         where d.ProcTipe == prtype
                                         select d).ToList();

            foreach (var d in computers1)
            {
                Console.WriteLine($"{d.Mark,8} {d.ProcTipe,8} {d.Count,4} шт.");
            }
            Console.WriteLine();

            Console.WriteLine("Группировка по объему ОЗУ");

            Console.WriteLine("Выберите объем ОЗУ \n8 \n16 ");
            Console.WriteLine();
            int ramtype = Convert.ToInt32(Console.ReadLine());

            List<Computer> computers2 = (from d in listComputer
                                         where d.Ram == ramtype
                                         select d).ToList();

            foreach (var d in computers2)
            {
                Console.WriteLine($"{d.Mark,8} объем ОЗУ{d.Ram,3} {d.Count,4} шт.");
            }
            Console.WriteLine();


            Console.WriteLine("Сортировка по стоимости");
            List<Computer> computers = listComputer
                .OrderBy(c => c.Cost)
                .ToList();
            foreach (var c in computers)
            {
                Console.WriteLine($"{c.Mark,8} {c.ProcTipe,8} {c.CPU,4} {c.Ram,3} {c.DiskVol,4} {c.CardMem,3} {c.Cost,7} {c.Count,3} шт.");
            }
            Console.WriteLine();

            Console.WriteLine("Группировка по типу процессора");
            var compGrup = from g in listComputer
                           group g by g.ProcTipe;
            foreach (IGrouping<string, Computer> g in compGrup)
            {
                Console.WriteLine(g.Key);
                foreach (var i in g)
                {
                    Console.WriteLine($"{i.Mark,8} {i.Cost,7} {i.Count,3}шт.");
                }
            }
            Console.WriteLine();

            Console.WriteLine("Самый дорогой и самый бюджетный");
            double min = listComputer.Min(m => m.Cost);

            double max = listComputer.Max(m => m.Cost);

            List<Computer> computers3 = (from d in listComputer
                                         where d.Cost == min || d.Cost == max
                                         select d).ToList();
            foreach (var i in computers3)
            {
                Console.WriteLine($"{i.Mark,8} {i.Cost,7} {i.Count,3}шт.");
            }
            Console.WriteLine();

            Console.WriteLine("Количество не менее 30 шт.");
            var computers4 = (from s in listComputer
                              where s.Count > 29
                              select s).Count();
            Console.WriteLine($"количество позиций больше 30 шт. - {computers4}");

            Console.ReadKey();
        }
    }
}
