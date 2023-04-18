using System;

namespace Estacionamento
{
    class Program
    {
        static bool[] vagas = new bool[10]; // vetor que representa as vagas do estacionamento

        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao estacionamento!");
      
            string texto = "BEM VINDO AO ESTACIONAMENTO";
       
            char[] caracteres = { '#', '*', '|', '-' };
     
            for (int i = 0; i < 10; i++)
            {
                Console.Clear();

                Console.WriteLine(new string('*', 50 / 2 - texto.Length / 2) + texto + new string('*', 50 / 2 - texto.Length / 2));

                for (int j = 0; j < 50; j++)
                {
                    Console.Write(caracteres[(i + j) % caracteres.Length]);
                }

                Thread.Sleep(100);
            }

            Console.Clear();

            Console.WriteLine(new string('*', 50 / 2 - texto.Length / 2) + texto + new string('*', 50 / 2 - texto.Length / 2));

            while (true) // loop infinito para controlar a entrada e saída de carros
            {
                Console.WriteLine("Digite 'E' para entrar com um carro ou 'S' para sair com um carro:");
                string opcao = Console.ReadLine().ToUpper();

                if (opcao == "E")
                {
                    int vaga = EncontrarVagaDisponivel();

                    if (vaga == -1) // não há vagas disponíveis
                    {
                        Console.WriteLine("Não há vagas disponíveis no momento.");
                    }
                    else
                    {
                        vagas[vaga] = true; // ocupa a vaga disponível
                        Console.WriteLine("O carro foi estacionado na vaga {0}.", vaga + 1);
                    }
                }
                else if (opcao == "S")
                {
                    Console.WriteLine("Digite o número da vaga que o carro está ocupando:");
                    int vaga = int.Parse(Console.ReadLine()) - 1;

                    if (vagas[vaga]) // a vaga está ocupada
                    {
                        vagas[vaga] = false; // libera a vaga
                        ReposicionarCarros(vaga); // reposiciona os carros no estacionamento
                        Console.WriteLine("O carro foi retirado do estacionamento.");
                    }
                    else
                    {
                        Console.WriteLine("A vaga está vazia. Não há carro para retirar.");
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida. Digite 'E' ou 'S'.");
                }
            }
        }

        static int EncontrarVagaDisponivel()
        {
            for (int i = 0; i < vagas.Length; i++)
            {
                if (!vagas[i])
                {
                    return i;
                }
            }

            return -1; // não há vagas disponíveis
        }

        static void ReposicionarCarros(int vagaLiberada)
        {
            for (int i = vagaLiberada + 1; i < vagas.Length; i++)
            {
                if (vagas[i]) // o carro da vaga i bloqueia a saída
                {
                    vagas[i] = false; // remove o carro da vaga i
                    vagas[i - 1] = true; // coloca o carro na vaga i - 1
                }
                else //se não há mais carros bloqueando a saída
                {
                    break;
                }
            }
        }
    }
}