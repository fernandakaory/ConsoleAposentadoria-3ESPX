using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAposentadoria
{
    internal class Program
    {
        static void Main()
        {
            // Chama o método que verifica o login
            VerificaLogin();
        }
        static void VerificaLogin()
        {
            // Verifica se as informações de login estão corretas
            string usuarioValido = "rm551104@fiap.com.br";
            string senhaValida = "551104";

            Console.WriteLine("----- LOGIN ----");
            Console.Write("Digite o usuário: ");
            string usuarioDigitado = Console.ReadLine();

            Console.Write("Digite a senha: ");
            string senhaDigitada = Console.ReadLine();

            if (usuarioDigitado == usuarioValido && senhaDigitada == senhaValida)
            {
                Console.WriteLine("\nBem-Vindo!!!!");
                CalculaAposentadoria();

            }
            else
            {
                Console.WriteLine("\nEmail e/ou senha inválidos!");
                Console.WriteLine("\nPressione qualquer tecla para sair do console. ");
                Console.ReadKey();

            }

        }

        static void CalculaAposentadoria()
        {
            // Calcula o tempo restante para aposentadoria a partir dos três parâmetros básicos: pontos (idade + tempo contribuido), idade e contribuição.
            try
            {
                int idadeHomens = 65;
                int idadeMulheres = 62;
                int contribuicaoHomens = 35;
                int contribuicaoMulheres = 30;
                int pontosHomens = 102;
                int pontosMulheres = 92;
                int contribuicaoMinGeral = 15;

                Console.WriteLine("\n***** Cálculo de Aposentadoria *****\n");

                Console.Write("Informa sua idade: ");
                int idade = int.Parse(Console.ReadLine());

                Console.Write("Informa o tempo de contribuição: ");
                int contribuicao = int.Parse(Console.ReadLine());

                Console.Write("\nDigite:\n(H) se for homem\n(M) se for mulher: ");
                string sexo = Console.ReadLine().ToUpper();

                if (sexo == "H" || sexo == "M")
                {
                    int idadeMinima = (sexo == "H") ? idadeHomens : idadeMulheres;
                    int contribuicaoMinima = (sexo == "H") ? contribuicaoHomens : contribuicaoMulheres;
                    int pontuacaoMinima = (sexo == "H") ? pontosHomens : pontosMulheres;

                    int pontuacao = idade + contribuicao;

                    if ((idade >= idadeMinima && contribuicao >= 15) || (pontuacao >= pontuacaoMinima && contribuicao >= contribuicaoMinima))
                    {
                        Console.WriteLine("\nVocê já pode se aposentar!!");
                    }
                    else
                    {
                        int idadeRestante = idadeMinima - idade;
                        int pontuacaoRestante = pontuacaoMinima - pontuacao;

                        Console.WriteLine("\n***** Cálculo por Idade *****\n");
                        Console.WriteLine($"Tempo restante para se aposentar por idade: {idadeRestante}");
                        Console.WriteLine($"Tempo restante  de contribuição: {contribuicaoMinGeral - contribuicao}");

                        Console.WriteLine("\n***** Cálculo por Pontuação *****\n");
                        Console.WriteLine($"Pontos necessários: {pontuacaoRestante}");
                        Console.WriteLine($"Tempo restante  de contribuição: {contribuicaoMinima - contribuicao}");

                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida! Tente novamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
