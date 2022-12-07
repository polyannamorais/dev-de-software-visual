//Escreva uma algoritmo que receba uma string representando um número inteiro e devolva um valor do tipo int que corresponda a este número. Exemplo: se a entrada for a string “13”, o algoritmo deve retornar o número 13. Lembre-se de que: (1) uma string é um array de valores do tipo char, podendo ser percorrida por um laço; (2) um número em base decimal equivale à soma de cada um de seus dígitos multiplicados pela potência de dez correspondente à casa em que tal dígito se encontra, por exemplo: 1987 = 1000 + 900 + 80 + 7 = 1×10³ + 9×10² + 8×10¹ + 7×10⁰


using System;

namespace ProgVisual
{
	class Program
	{
		static double ConverteParaIntIngenuo(string valor)
		{
			double numero = 0.0;
			for(int i = 0; i < valor.Length; i++)
			{
				int digito = 0;
				int potencia = (valor.Length - 1) - i;
				if(valor[i] == '0') digito = 0;
				else if(valor[i] == '1') digito = 1;
				else if(valor[i] == '2') digito = 2;
				else if(valor[i] == '3') digito = 3;
				else if(valor[i] == '4') digito = 4;
				else if(valor[i] == '5') digito = 5;
				else if(valor[i] == '6') digito = 6;
				else if(valor[i] == '7') digito = 7;
				else if(valor[i] == '8') digito = 8;
				else if(valor[i] == '9') digito = 9;
				else throw new Exception("valor inválido");
				numero += digito * Math.Pow(10, potencia);
			}
			return numero;
		}
		
		static double ConverteParaIntEsperto(string valor)
		{
			double numero = 0.0;
			for(int i = 0, j = valor.Length - 1; i < valor.Length; i++, j--)
			{
				if(valor[i] < 48 || valor[i] > 57)
				{
					throw new Exception("valor inválido");
				}
				numero += (valor[i] - 48) * Math.Pow(10, j);
			}
			return numero;
		}
		
		public static void Main(string[] args)
		{
			Console.WriteLine("Insira um número inteiro: ");
			string valorEmString = Console.ReadLine();
			double valorEmInt = ConverteParaIntEsperto(valorEmString);
			Console.WriteLine("O número inserido foi: " + valorEmInt);
			Console.Write("Pressione 'enter' para sair.");
			Console.ReadLine();
		}
	}
}
