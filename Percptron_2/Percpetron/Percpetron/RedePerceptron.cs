using Percpetron.Uteis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Percpetron
{
    public static class RedePerceptron
    {

		public static bool treinarRede(ref List<Neuronio> neuronios, List<Entrada> entradas, int[,] valoresDesejados)
		{

			try
			{
				Console.WriteLine("Treinamento da rede iniciado...");

				for (var i = 0; i < VariaveisGlobais.N_NEURONIOS; i++)
				{
					Neuronio neuronio = new Neuronio();
					neuronio.inicializaPesos();
					neuronio.treinar(entradas, valoresDesejados.getValuesLines(i));
					neuronios.Add(neuronio);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Erro ao realizar o treinamento da rede! " + ex.Message);
			}

			Console.WriteLine("Rede treinada com sucesso!");

			return true;
		}

		public static int testarRede(ref List<Neuronio> neuronios, Entrada entrada, out string mensagem)
		{
			List<int> saidas = new List<int>();
			mensagem = "";

			//CAPTURAR RETORNO DE CADA NEURÔNIO
			for (var i = 0; i < VariaveisGlobais.N_NEURONIOS; i++)
			{
				saidas.Add(neuronios[i].CalculaNeuronio(entrada));
			}

			if (!saidas.Contains(1))
			{
				mensagem = "A rede não conseguiu reconhecer a entrada informada!";
				return -1;
			}

			int indice = saidas.IndexOf(1);

			return indice;
		}
    }
}
