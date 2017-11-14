using System;
using System.Collections.Generic;
using System.Text;

namespace Percpetron
{
    public class Neuronio
    {
		#region Atributos e propriedades

		List<double> pesos { get; set; }

		#endregion

		#region Construtores

		public Neuronio()
		{
			this.pesos = new List<double>();
		}

		#endregion

		#region Métodos

		public void inicializaPesos()
		{
			Random random = new Random();

			for (var i = 0; i < VariaveisGlobais.N_ENTRADAS; i++)
			{
				double peso = (random.NextDouble());
				this.pesos.Add(peso);
			}
		}

		public void imprimePesos()
		{
			foreach (double item in this.pesos)
			{
				Console.Write(item + " - ");
			}
		}

		public int CalculaNeuronio(Entrada entrada)
		{

			double resultado = 0;

			//FUNÇÃO DE ATIVAÇÃO
			for (var i = 0; i < VariaveisGlobais.N_ENTRADAS; i++)
			{
				resultado += this.pesos[i] * entrada.valores[i];
			}

			//VAMOS UTILIZAR A FUNÇÃO DEGRAU UNITÁRIO
			if (resultado > 0)
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}

		public void AjustaPeso(Entrada entrada, float erro, out bool reajustouPeso)
		{
			reajustouPeso = false;

			for (var i = 0; i < VariaveisGlobais.N_ENTRADAS; i++)
			{
				double novoPeso = this.pesos[i] + (erro * 1 * entrada.valores[i]);

				if (novoPeso != this.pesos[i])
				{
					this.pesos[i] = novoPeso;
					reajustouPeso = true;
				}
			}
		}

		public void treinar(List<Entrada> entradas, List<int> valoresDesejados)
		{
			int epoca = 0;
			bool avancarEpoca = false;
			bool reajustouPeso = false;
			Console.WriteLine("Iniciou Treinamento!");

			do
			{
				avancarEpoca = false;

				for (var i = 0; i < entradas.Count; i++)
				{
					int valor_Obtido = this.CalculaNeuronio(entradas[i]);
					this.AjustaPeso(entradas[i], valoresDesejados[i] - valor_Obtido, out reajustouPeso);

					if (reajustouPeso)
					{
						avancarEpoca = true;
					}
				}

				epoca++;

			} while (avancarEpoca);

			Console.WriteLine("Treinamento concluído em {0} época(s)", epoca);
		}

		#endregion
	}
}
