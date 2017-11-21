using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Percpetron
{
    public class Entrada
    {
		#region Atributos e propriedades

		public List<int> valores { get; set; }

		#endregion

		#region Construtores

		public Entrada()
		{
			this.valores = new List<int>();
		}

		#endregion

		#region Métodos

		public static List<Entrada> inicializarEntradas(string nomeArquivo)
		{
			List<Entrada> entradas = new List<Entrada>();
			

			using (StreamReader reader = new StreamReader(VariaveisGlobais.caminhoArquivos + nomeArquivo))
			{

				string[] arquivo = reader.ReadToEnd().Split("\r\n");

				for (var i = 0; i < arquivo.Length; i++)
				{
					entradas.Add(new Entrada());

					string[] caracteres = arquivo[i].Split(' ');

					//INCLUIR VIÉS
					entradas[i].valores.Add(1);

					foreach (string item in caracteres)
					{
						entradas[i].valores.Add(Convert.ToInt16(item));
					}

				}

			}

			return entradas;
		}

		public static int[,] inicializaValoresDesejados(string nomeArquivo, int quantidadeEntradas)
		{
			int[,] listaValores = new int[VariaveisGlobais.N_NEURONIOS,quantidadeEntradas];

			using (StreamReader reader = new StreamReader(VariaveisGlobais.caminhoArquivos + nomeArquivo))
			{

				string[] arquivo = reader.ReadToEnd().Split("\r\n");

				for (var i = 0; i < arquivo.Length; i++)
				{
					string[] caracteres = arquivo[i].Split(' ');

					for (var j = 0; j < caracteres.Length; j++)
					{
						listaValores[i, j] = Convert.ToInt16(caracteres[j]);
					}
				}

			}

			return listaValores;
		}

		#endregion
	}
}
