using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Parking
    {
        private decimal initialPrice = 0;
        private decimal pricePerHour = 0;
        private List<string> vehicles = new List<string>();

        public Parking(decimal initialPrice, decimal pricePerHour)
        {
            this.initialPrice = initialPrice;
            this.pricePerHour = pricePerHour;
        }

        public void AddVehicle()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string plate = Console.ReadLine().ToUpper();
            if(!VerifyPlateRegex(plate))
            {
                Console.WriteLine("A placa do veículo digitado está no formato invalido!");
                return;
            }
            vehicles.Add(plate);
            Console.WriteLine($"Veículo de placa '{plate}' foi cadastrado com sucesso!");
        }

        public void RemoveVehicle()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string plate = Console.ReadLine().ToUpper();
            if (!VerifyPlateRegex(plate))
            {
                Console.WriteLine("A placa do veículo digitado está no formato invalido!");
                return;
            }

            // Verifica se o veículo existe
            if (vehicles.Any(x => x.ToUpper() == plate.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int hours = 0;
                try
                {
                    hours = Convert.ToInt32(Console.ReadLine());
                } catch(FormatException ex)
                {
                    Console.WriteLine("Você digitou o formato de hora invalida!");
                    return;
                }
                decimal totalValue = initialPrice + pricePerHour * hours;
                vehicles.Remove(plate);

                Console.WriteLine($"O veículo {plate} foi removido e o preço total foi de: R$ {totalValue}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListVehicle()
        {
            // Verifica se há veículos no estacionamento
            if (vehicles.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach(string item in vehicles)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
        private bool VerifyPlateRegex(string plate)
        {
            Regex regex = new Regex("[A-Z]{3}[0-9][0-9A-Z][0-9]{2}");
            return regex.IsMatch(plate);
        }
    }
}
