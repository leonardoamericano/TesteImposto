using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Stream stream = new Stream("aoAbBABacfeu");
            BuscarVogal buscarVogal = new BuscarVogal();

            char resultado = buscarVogal.UnicaAposConsoante(stream);

            Console.WriteLine(resultado);

            var resultadoEsperado = 'e';

            Console.WriteLine(resultado == resultadoEsperado ? "CORRETO" : $"INCORRETO {resultado} != {resultadoEsperado}");

            Console.ReadKey();
        }
    }
}
