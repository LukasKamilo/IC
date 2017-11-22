using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Percpetron
{
    class Program
    {
        static void Main(string[] args)
        {
			string mensagem;
			List<Neuronio> neuronios = new List<Neuronio>();
			List<Entrada> entradas = Entrada.inicializarEntradas("treinar.txt");
			List<Entrada> entradasTeste = Entrada.inicializarEntradas("entradasTeste.txt");
			int[,] valoresDesejados = Entrada.inicializaValoresDesejados("valoresDesejados.txt", entradas.Count);

			DateTime t_inicio;
			DateTime t_fim;
			TimeSpan t_diferenca;

			try
			{
				t_inicio = DateTime.Now;
				RedePerceptron.treinarRede(ref neuronios, entradas, valoresDesejados);
				t_fim = DateTime.Now;

				t_diferenca = t_fim.Subtract(t_inicio);

				Console.WriteLine("Rede treinada em {0} segundos!", t_diferenca.TotalSeconds.ToString("0.000000"));

				//RECONHECER PLACA
				int[,] placa = Util.LerPlaca("EntradasPlacas/HHW3481.txt");
				List<Entrada> entradasPlaca = Util.getEntradasPlaca(placa);
				string placaRetorno = "";

				foreach (Entrada entrada in entradasPlaca)
				{
					int retorno = RedePerceptron.testarRede(ref neuronios, entrada, out mensagem);

					if (retorno == -1)
					{
						Console.WriteLine(mensagem);
					}
					else
					{
						placaRetorno += (retorno > 9 ? Convert.ToChar(retorno + 55).ToString() : retorno.ToString());
					}
				}

				Console.WriteLine(placaRetorno);

				//INICIO DOS TESTES
				//foreach (Entrada entrada in entradasTeste)
				//{
				//	int retorno = RedePerceptron.testarRede(ref neuronios, entrada, out mensagem);

				//	if (retorno == -1)
				//	{
				//		Console.WriteLine(mensagem);
				//	}
				//	else
				//	{
				//		Console.WriteLine("A rede reconheceu a entrada como sendo o dígito: {0}.", (retorno > 9 ? Convert.ToChar(retorno + 55).ToString() : retorno.ToString()));
				//	}
				//}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				Console.ReadKey();
			}
        }
    }
}
