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

		#endregion
	}
}
