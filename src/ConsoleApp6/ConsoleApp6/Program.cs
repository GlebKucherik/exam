using System;
using System.Reflection;
using System.Runtime.ConstrainedExecution;


namespace ThePracticeExam.Program
{
    class Program
    {
        public class Driver
        {
            public Driver(int length)
            {
                _Autos = new Auto[length];
            }
            public Driver(Auto[] Autos)
            {
                _Autos = Autos;
            }

            private Auto[] _Autos;

            public int Legnth => _Autos.Length;

            public Auto this[int i]
            {
                get => _Autos[i];
                set => _Autos[i] = value;
            }

            public void Sort()
            {
                for (int y = 0; y < _Autos.Length - 1; y++)
                {
                    for (int i = 0; i < _Autos.Length - 1; i++)
                    {
                        
                        if (_Autos[i].Price > _Autos[i + 1].Price)
                        {
                            var buf = _Autos[i];
                            _Autos[i] = _Autos[i + 1];
                            _Autos[i + 1] = buf;
                        }

                        
                        else if (_Autos[i].Model == _Autos[i + 1].Model)
                        {
                            if (_Autos[i].Price > _Autos[i + 1].Price)
                            {
                                var buf = _Autos[i];
                                _Autos[i] = _Autos[i + 1];
                                _Autos[i + 1] = buf;
                            }
                        }
                    }
                }
            }

            public string Print()
            {
                string result = String.Empty;
                foreach (var a in _Autos)
                {
                    result = $"{result}{a}";
                }
                return result;
            }

            public string Save()
            {
                string path = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent}/Autos.txt";
                string Autos = this.Print();

                File.WriteAllText(path, Autos);

                return $"The file has been saved in {path}";
            }
        }
        public class Auto
        {

            public string marka { get; set; }
            public string Model { get; set; }

            public int Price { get; set; }

            public override string ToString()
            {
                return $"{Model} {Price} {marka}\n";
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Введите длину массива: ");
            try
            {
                int length = int.Parse(Console.ReadLine());
                Driver Driver = new Driver(length);

                for (int i = 0; i < length; i++)
                {
                    Console.WriteLine($"\nМашина {i + 1}:");
                    var Auto = new Auto();

                    Console.Write("Напишите марку машины: ");
                    Auto.marka = (Console.ReadLine());

                    Console.Write("Напишите модель машины: ");
                    Auto.Model = Console.ReadLine();


                    Console.Write("Напишите цену: ");
                    Auto.Price = int.Parse(Console.ReadLine());

                    Driver[i] = Auto;
                }

                Console.WriteLine("\nПеред сортировкой:");
                Console.WriteLine(Driver.Print());

                Driver.Sort();

                Console.WriteLine("\nПосле сортировки:");
                Console.WriteLine(Driver.Print());

                Console.WriteLine(Driver.Save());
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}