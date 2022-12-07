//Escreva um algoritmo que receba um array de números do tipo double e imprima na tela sua média, sua mediana e sua moda. Lembre-se de que: (1) a média de n números corresponde à soma destes números dividida por n; (2) a mediana de n números corresponde ao valor que está no meio quando estes números estão ordenados (ou à media dos dois valores do meio caso n seja par); e (3) a moda de n números corresponde ao número que mais se repete entre eles (caso haja empate entre mais de um valor, basta imprimir qualquer um deles).


using System;

namespace ProgVisual
{
	class Calculadora
	{
		double[] valores;
		
		public void setValores(double[] v)
		{
			valores = v;
		}
		
		public double getMedia()
		{
			double soma = 0;
			foreach(double valor in valores)
			{
				soma += valor;
			}
			return soma / valores.Length;
		}
		
		public double getMediana()
		{
			Array.Sort(valores);
			int meio = valores.Length / 2;
			if(valores.Length % 2 != 0)
			{
				return valores[meio];
			}
			else
			{
				return (valores[meio] + valores[meio-1]) / 2;
			}
		}
		
		public double getModaIngenuo()
		{
			double[] repeticoes = new double[valores.Length];
			for(int i = 0; i < valores.Length; i++)
			{
				repeticoes[i] = 0;
				for(int j = 0; j < valores.Length; j++)
				{
					if(valores[i] == valores[j])
					{
						repeticoes[i]++;
					}
				}
			}
			int indiceDoMaisRepetido = 0;
			for(int i = 0; i < repeticoes.Length; i++)
			{
				if(repeticoes[i] > repeticoes[indiceDoMaisRepetido])
				{
					indiceDoMaisRepetido = i;
				}
			}
			return valores[indiceDoMaisRepetido];
		}
		
		public double getModaEsperto()
		{
			double maisRepetido = 0.0;
			int indiceDoMaisRepetido = 0;
			for(int i = 0; i < valores.Length; i++)
			{
				int numRepeticoes = 0;
				for(int j = i + 1; j < valores.Length; j++)
				{
					if(valores[i] == valores[j])
					{
						numRepeticoes++;
					}
				}
				if(numRepeticoes > maisRepetido)
				{
					maisRepetido = numRepeticoes;
					indiceDoMaisRepetido = i;
				}
			}
			return valores[indiceDoMaisRepetido];
		}
	}
	
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Quantos valores você gostaria de inserir?");
			int numValores = int.Parse(Console.ReadLine());
			double[] valores = new double[numValores];
			Console.WriteLine("Aperte 'enter' após inserir cada valor.");
			for(int i = 0; i < valores.Length; i++)
			{
				valores[i] = double.Parse(Console.ReadLine());
			}
			
			Calculadora calculadora = new Calculadora();
			calculadora.setValores(valores);
			
			Console.WriteLine("A media é "   + calculadora.getMedia());
            Console.WriteLine("A moda é "    + calculadora.getModaEsperto());
			Console.WriteLine("A mediana é " + calculadora.getMediana());
			
			Console.Write("Pressione 'enter' para sair.");
			Console.ReadLine();
		}
	}
}
