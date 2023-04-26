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
                        // Sorting by Power
                        if (_Autos[i].Price > _Autos[i + 1].Price)
                        {
                            var buf = _Autos[i];
                            _Autos[i] = _Autos[i + 1];
                            _Autos[i + 1] = buf;
                        }

                        // Sorting by Price
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