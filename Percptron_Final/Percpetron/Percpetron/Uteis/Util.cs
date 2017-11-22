using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Percpetron
{
    public class Util
    {
		public static int[,] LerPlaca(string nomeArquivo)
		{
			int[,] listaValores = new int[10, 47];

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

		public static List<Entrada> getEntradasPlaca(int[,] placaBinaria)
		{
			List<Entrada> lista = new List<Entrada>();

			Entrada Letra_1 = new Entrada();
			Entrada Letra_2 = new Entrada();
			Entrada Letra_3 = new Entrada();
			Entrada Digito_1 = new Entrada();
			Entrada Digito_2 = new Entrada();
			Entrada Digito_3 = new Entrada();
			Entrada Digito_4 = new Entrada();

			//INCLUIR O VIÉS NAS ENTRADAS
			Letra_1.valores.Add(1);
			Letra_2.valores.Add(1);
			Letra_3.valores.Add(1);
			Digito_1.valores.Add(1);
			Digito_2.valores.Add(1);
			Digito_3.valores.Add(1);
			Digito_4.valores.Add(1);

			//LENDO A PRIMEIRA LETRA
			for (var i = 2; i < 8; i++)
			{
				for (var j = 2; j < 7; j++)
				{
					Letra_1.valores.Add(placaBinaria[i, j]);
				}
			}

			//LENDO A SEGUNDA LETRA
			for (var i = 2; i < 8; i++)
			{
				for (var j = 8; j < 13; j++)
				{
					Letra_2.valores.Add(placaBinaria[i, j]);
				}
			}

			//LENDO A TERCEIRA LETRA
			for (var i = 2; i < 8; i++)
			{
				for (var j = 14; j < 19; j++)
				{
					Letra_3.valores.Add(placaBinaria[i, j]);
				}
			}

			//LENDO O PRIMEIRO DÍGITO
			for (var i = 2; i < 8; i++)
			{
				for (var j = 22; j < 27; j++)
				{
					Digito_1.valores.Add(placaBinaria[i, j]);
				}
			}

			//LENDO O SEGUNDO DÍGITO
			for (var i = 2; i < 8; i++)
			{
				for (var j = 28; j < 33; j++)
				{
					Digito_2.valores.Add(placaBinaria[i, j]);
				}
			}

			//LENDO O TERCEIRO DÍGITO
			for (var i = 2; i < 8; i++)
			{
				for (var j = 34; j < 39; j++)
				{
					Digito_3.valores.Add(placaBinaria[i, j]);
				}
			}

			//LENDO O QUARTO DÍGITO
			for (var i = 2; i < 8; i++)
			{
				for (var j = 40; j < 45; j++)
				{
					Digito_4.valores.Add(placaBinaria[i, j]);
				}
			}

			lista.Add(Letra_1);
			lista.Add(Letra_2);
			lista.Add(Letra_3);
			lista.Add(Digito_1);
			lista.Add(Digito_2);
			lista.Add(Digito_3);
			lista.Add(Digito_4);

			return lista;
		}
    }
}
