using System;
using System.Collections.Generic;

namespace Percpetron
{
    class Program
    {
        static void Main(string[] args)
        {
			List<Neuronio> neuronios = new List<Neuronio>();
			List<Entrada> entradas = Entrada.inicializarEntradas("treinar.txt");
			List<int> valoresDesejados = new List<int>();
			valoresDesejados.Add(0);//0
			valoresDesejados.Add(0);//1
			valoresDesejados.Add(0);//2
			valoresDesejados.Add(0);//3
			valoresDesejados.Add(0);//4
			valoresDesejados.Add(0);//5
			valoresDesejados.Add(0);//6
			valoresDesejados.Add(0);//7
			valoresDesejados.Add(0);//8
			valoresDesejados.Add(0);//9

			for (var i = 0; i < VariaveisGlobais.N_NEURONIOS; i++)
			{
				Neuronio neuronio = new Neuronio();
				neuronio.inicializaPesos();
				valoresDesejados[i] = 1;
				neuronio.treinar(entradas, valoresDesejados);
				valoresDesejados[i] = 0;
				neuronios.Add(neuronio);
			}

			//INICIO DOS TESTES
			for (var i = 0; i < VariaveisGlobais.N_NEURONIOS; i++)
			{
				Console.WriteLine("Teste {0}: {1}", i, neuronios[i].CalculaNeuronio(entradas[i]));
			}

			Console.ReadKey();

        }
    }
}
