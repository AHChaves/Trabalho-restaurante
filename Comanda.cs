using System;


namespace tri
{
    public class Comanda
    {
        public string consumo { get; private set; }
        public double preco { get; private set; }

        public Comanda()
        {
            consumo = "";
            preco = 0.0;
        }

        public void pedido()
        {
            Console.WriteLine("Qual o pedido?");
            consumo = Console.ReadLine();
            Console.WriteLine("Qual o preço?");
            preco = preco + double.Parse(Console.ReadLine());
        }

        public void Listar_Consumo(double valor)
        {
            Console.WriteLine("O total da comanda é: R$" + (preco+valor));
        }

        public double calcular_10_porcento(double valor)
        {
            return ((preco + valor)*0.10);
        }

        public double dividir_conta(int dividi,int qnt_pessoas, double valor)
        {
            if (dividi < qnt_pessoas && dividi > 0)
            {
                return ((valor+preco)/qnt_pessoas);
            }
            else
            {
                Console.WriteLine("Numero invalido");
                return 0;
            }
        }

    }

    public class Comanda_Bebida : Comanda
    {
    }

    public class Comanda_Comida : Comanda
    {
    }
}
