using System;
using tri;

public class Program
{
    public static void Main()
    {
        int qnt_de_mesa = 5, escolha = 0;
        bool libera = false;
        Restaurante r = new Restaurante(qnt_de_mesa);
            
        r.Cadastra_mesa(qnt_de_mesa);

        do
        {
            Console.WriteLine("\n01 - Checar dados do restaurante\n02 - Reservar uma mesa\n03 - Fechar Programa");
            Console.WriteLine("Escolha uma opção: ");
            escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
                case 0:
                    {
                        Console.Clear();
                        Console.WriteLine("Escolha invalida!");
                        break;
                    }
                case 1:
                    {
                        Console.Clear();
                        r.Status_restaurante();
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        r.reserva_de_mesa(qnt_de_mesa);
                        break;
                    }
                case 3:
                    {
                        libera = true;
                        break;
                    }
                default:
                    {
                        Console.Clear();
                        Console.WriteLine("Opção invalida!");
                        break;
                    }

            }

        }while(libera == false);
    }
}
