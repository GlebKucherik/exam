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
           