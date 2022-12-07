//Crie um algoritmo que permita fazer três conversões monetárias. O algoritmo deve receber o valor em real (R$) e apresentar os valores convertidos em:
//a) Dólar (1 dólar = 5,17 reais)
//b) Euro (1 euro = 6,14 reais)
//c) Peso argentino (1 peso argentino = 0,05 reais)

using System;

namespace ProgVisual
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Conversor de moedas");
			double valor = 0.0;
			while(true)
			{
				try
				{
					Console.WriteLine("Insira um valor em reais: ");
					valor = double.Parse(Console.ReadLine());
					break;
				}
				catch(Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			Console.WriteLine("Valor em reais: "   + valor);
			Console.WriteLine("Valor em dólares: " + (valor / 5.17));
			Console.WriteLine("Valor em euros: "   + (valor / 6.14));
			Console.WriteLine("Valor em pesos: "   + (valor / 0.05));
			Console.Write("Pressione 'enter' para sair.");
			Console.ReadLine();
		}
	}
}
