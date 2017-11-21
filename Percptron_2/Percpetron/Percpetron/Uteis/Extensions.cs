using System;
using System.Collections.Generic;
using System.Text;

namespace Percpetron.Uteis
{
    public static class Extensions
    {
		public static int[] getValuesLines(this int[,] matriz, int line)
		{
			int[] linha = new int[matriz.GetLength(1)];

			for (var i = 0; i < matriz.GetLength(1); i++)
			{
				linha[i] = matriz[line, i];
			}

			return linha;
		}
    }
}
