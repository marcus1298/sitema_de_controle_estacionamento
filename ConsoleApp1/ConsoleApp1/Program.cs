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

            const int numVagas = 10;
            Stack<string> estacionamento = new Stack<string>(numVagas);

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Entrar com um carro");
                Console.WriteLine("2 - Retirar um carro");
                Console.WriteLine("3 - Sair");

                string opcaoStr = Console.ReadLine();
                int opcao;

                if (int.TryParse(opcaoStr, out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            if (estacionamento.Count >= numVagas)
                            {
                                Console.WriteLine("Estacionamento lotado. Não há vagas disponíveis.");
                            }
                            else
                            {
                                Console.WriteLine("Digite a placa do carro:");
                                string placa = Console.ReadLine();

                                estacionamento.Push(placa);

                                Console.WriteLine("Carro estacionado com sucesso.");
                            }
                            break;
                        case 2:
                            if (estacionamento.Count == 0)
                            {
                                Console.WriteLine("Não há carros estacionados.");
                            }
                            else
                            {
                                Console.WriteLine("Digite a placa do carro que deseja retirar:");
                                string placa = Console.ReadLine();

                                Stack<string> temp = new Stack<string>(numVagas);

                                while (estacionamento.Count > 0)
                                {
                                    string carro = estacionamento.Pop();
                                    if (carro == placa)
                                    {
                                        Console.WriteLine("Carro retirado com sucesso.");
                                        Console.WriteLine();
                                        Console.Clear();
                                        break;
                                    }
                                    else
                                    {
                                        temp.Push(carro);
                                    }
                                }

                                while (temp.Count > 0)
                                {
                                    estacionamento.Push(temp.Pop());
                                }
                            }
                            break;
                        case 3:
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                }
                
                Console.WriteLine();
                Console.ReadLine();
                Console.Clear();
            }
            
        }
    }
}