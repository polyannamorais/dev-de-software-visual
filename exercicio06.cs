//Escreva uma algoritmo que receba um numero inteiro entre 0 e 999.999.999 e escreva seu valor por extenso. Exemplo: se a entrada for o número 13 oalgoritmo deve imprimir a string “treze”, se a entrada for o número 256 o algoritmo deve imprimir a string “duzentos e cinquenta e seis”, se a entrada for o número 12345678 o algoritmo deve imprimir a string “doze milhões trezentos e quarenta e cinco mil seiscentos e setenta e oito” e assim por diante.

using System;

namespace Visual
{
	class Program
	{
		static string getUnidade(int numero)
		{
			if(numero == 1) return "um";
			if(numero == 2) return "dois";
			if(numero == 3) return "três";
			if(numero == 4) return "quatro";
			if(numero == 5) return "cinco";
			if(numero == 6) return "seis";
			if(numero == 7) return "sete";
			if(numero == 8) return "oito";
			if(numero == 9) return "nove";
			throw new Exception("número inválido");
		}
		
		static string getDezena(int numero)
		{
			if(numero == 1) return "dez";
			if(numero == 2) return "vinte";
			if(numero == 3) return "trinta";
			if(numero == 4) return "quarenta";
			if(numero == 5) return "cinquenta";
			if(numero == 6) return "sessenta";
			if(numero == 7) return "setenta";
			if(numero == 8) return "oitenta";
			if(numero == 9) return "noventa";
			throw new Exception("número inválido");
		}
		
		static string getCentena(int numero)
		{
			if(numero == 1) return "cento";
			if(numero == 2) return "duzentos";
			if(numero == 3) return "trezentos";
			if(numero == 4) return "quatrocentos";
			if(numero == 5) return "quinhentos";
			if(numero == 6) return "seiscentos";
			if(numero == 7) return "setecentos";
			if(numero == 8) return "oitocentos";
			if(numero == 9) return "novecentos";
			throw new Exception("número inválido");
		}
		
		static string getNomeParcial(int numero)
		{
			if(numero == 100)
			{
				return "cem";
			}
			
			int centena =  numero / 100;
			int dezena  = (numero % 100) / 10;
			int unidade =  numero  % 10;
			
			string nome = "";
			
			if(centena > 0)
			{
				nome = getCentena(centena);
				
				if(dezena > 0 || unidade > 0)
				{
					nome += " e";
				}
			}
			
			if((dezena > 0 || unidade > 0) && nome.Length > 0)
			{
				nome += " ";
			}
			
			int aux = numero % 100;
			if(aux == 10) return nome + "dez";
			if(aux == 11) return nome + "onze";
			if(aux == 12) return nome + "doze";
			if(aux == 13) return nome + "treze";
			if(aux == 14) return nome + "quatorze";
			if(aux == 15) return nome + "quinze";
			if(aux == 16) return nome + "dezesseis";
			if(aux == 17) return nome + "dezessete";
			if(aux == 18) return nome + "dezoito";
			if(aux == 19) return nome + "dezenove";
			
			if(dezena > 0)
			{
				nome += getDezena(dezena);
				
				if(unidade > 0)
				{
					nome += " e ";
				}
			}
			
			if(unidade > 0)
			{
				nome += getUnidade(unidade);
			}
			
			return nome;
		}
		
		static string getNomeCompleto(int numero)
		{
			if(numero < 0 || numero > 999999999)
			{
				throw new Exception("o número deve ser maior ou igual a zero e menor que um bilhão");
			}
			
			int n_milhoes =  numero / 1000000;
			int n_mil     = (numero % 1000000) / 1000;
			int n         =  numero % 1000;
			
			if(numero == 0)
			{
				return "zero";
			}
			
			string nome = "";
			
			if(n_milhoes > 0)
			{
				nome += getNomeParcial(n_milhoes);
				
				if(n_milhoes == 1)
				{
					nome += " milhão";
				}
				else
				{
					nome += " milhões";
				}
				
				if((n == 0 && (n_mil % 100 == 0)) ^ (n_mil == 0 && (n < 20 || (n % 10 == 0))))
				{
					nome += " e";
				}
				else if(n_mil > 0 || n > 0)
				{
					nome += ",";
				}
			}
			
			if(n_mil > 0)
			{
				if(nome.Length > 0)
				{
					nome += " ";
				}
				
				if(n_mil > 1)
				{
					nome += getNomeParcial(n_mil) + " ";
				}
				
				nome += "mil";
				
				if(n > 0)
				{
					if(n < 100 || (n % 100 == 0))
					{
						nome += " e";
					}
					else
					{
						nome += ",";
					}
				}
			}
			
			if(n > 0)
			{
				if(nome.Length > 0)
				{
					nome += " ";
				}
				
				nome += getNomeParcial(n);
			}
			
			return nome;
		}
		
		static void Main(string[] args)
		{
			while(true)
			{
				try
				{
					Console.WriteLine("\nInsira um número inteiro entre 0 e 999,999,999 (ou um valor inválido para sair): ");
					Console.WriteLine(getNomeCompleto(int.Parse(Console.ReadLine())));
				}
				catch(Exception erro)
				{
					//Console.WriteLine(erro.Message);
					break;
				}
			}
		}
	}
}
