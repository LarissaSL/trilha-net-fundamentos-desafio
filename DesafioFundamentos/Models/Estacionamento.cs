namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            string confirmacao = string.Empty;
            string placaVeiculo = string.Empty;

            while (true)
            {
                if (string.IsNullOrEmpty(confirmacao) || confirmacao == "N")
                {
                    Console.Clear();
                    Console.WriteLine("Digite a placa do veículo para estacionar:");
                    placaVeiculo = Console.ReadLine().ToUpper();

                    //Verificando se a Placa é Nula
                    if (string.IsNullOrEmpty(placaVeiculo))
                    {
                        Console.Clear();
                        Console.WriteLine("Não é possível registrar um Veículo com a placa vazia, por favor digite uma placa para o Veículo.");
                        Console.WriteLine("Pressione uma tecla para continuar");
                        Console.ReadLine();
                        continue; 
                    }

                    //Verificando se a Placa já está registrada no Sistema
                    if (veiculos.Contains(placaVeiculo))
                    {
                        Console.Clear();
                        Console.WriteLine($"Veículo de Placa {placaVeiculo} já está registrado no Estacionamento.");
                        break;
                    }

                }

                //Confirmações para Registro da Placa
                Console.WriteLine($"\nDeseja confirmar o registro do Veículo de Placa {placaVeiculo} ? " +
                                "\nS - para Sim e registrar a Placa acima\nN - para Não confirmar e registrar outra Placa\n ");
                confirmacao = Console.ReadLine().ToUpper();

                if (confirmacao == "S")
                {
                    Console.Clear();
                    veiculos.Add(placaVeiculo);
                    Console.WriteLine($"Veiculo de placa {placaVeiculo} registrado com Sucesso!");
                    break;
                }
                else if (confirmacao == "N")
                {
                    continue;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida, por favor digite uma opção válida.");
                    Console.WriteLine("Pressione uma tecla para continuar");
                    Console.ReadLine();
                    continue; 
                }
            }      
        }
        
                

        public void RemoverVeiculo()
        {
            string placaVeiculo = string.Empty;
            string confirmacao = string.Empty;
            
            while (true)
            {
                if (string.IsNullOrEmpty(confirmacao) || confirmacao == "N")
                {
                    Console.Clear();
                    Console.WriteLine("Digite a placa do veículo para remover:");
                    placaVeiculo = Console.ReadLine().ToUpper();

                    //Verificando se a Placa é Nula
                    if (string.IsNullOrEmpty(placaVeiculo))
                    {
                        Console.Clear();
                        Console.WriteLine("Nenhuma placa inserida, por favor digite uma placa.");
                        Console.WriteLine("Pressione uma tecla para continuar");
                        Console.ReadLine();
                        continue; 
                    }

                    //Verificando se a Placa não está registrada no Sistema
                    if (!veiculos.Contains(placaVeiculo))
                    {
                        Console.Clear();
                        Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                        break;
                    }

                }

                //Confirmações para Remoção do Veiculo e Calculo do valor a ser Pago
                Console.WriteLine($"\nDeseja confirmar a retirada do Veículo de Placa {placaVeiculo} ? " +
                                "\nS - para Sim\nN - para Não\n ");
                confirmacao = Console.ReadLine().ToUpper();

                if (confirmacao == "S")
                {
                    Console.Clear();
                    int horas = 0;
                    decimal valorTotal = 0; 

                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    horas = Convert.ToInt16(Console.ReadLine());

                    // Calculo, Resultado e Remoção do Veiculo  
                    Console.Clear();
                    valorTotal = precoInicial + precoPorHora * horas;
                    Console.WriteLine($"O veículo {placaVeiculo} foi removido e o preço total foi de: {valorTotal:C2}");

                    veiculos.Remove(placaVeiculo);
                    break;
                
                }
                else if (confirmacao == "N")
                {
                    continue;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida, por favor digite uma opção válida.");
                    Console.WriteLine("Pressione uma tecla para continuar");
                    Console.ReadLine();
                    continue; 
                }
            }
        }

        public void ListarVeiculos()
        {
            Console.Clear();

            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                for(int contador = 0; contador < veiculos.Count(); contador++) 
                {
                    Console.WriteLine($"{contador + 1} | {veiculos[contador]}");
                }
                Console.WriteLine($"\nTotal de Veículos estacionados: {veiculos.Count()}");
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}