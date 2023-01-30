using System;
using tri;

namespace tri
{
    public class Restaurante
    {
        public string nome_do_restaurante { get; private set; }
        public string endereco { get; private set; }
        
        private bool liberado;
        private int escolha, numero_de_pessoas, dividir;
        private double valor;
        private string nome_do_cliente;
        private string email_do_cliente;

        Mesa[] mesa;
        Cliente cliente;
        Comanda_Bebida bebida;
        Comanda_Comida comida;
        Random rand = new Random();

        public Restaurante(int quantidade_de_mesa)
        {
            nome_do_restaurante = "Buchinho Cheio";
            endereco = "Rua das Abobrinhas 777";
            liberado = false;
            escolha = 0;
            numero_de_pessoas = 0;
            dividir = 0;
            valor = 0.0;
            nome_do_cliente = "";
            email_do_cliente = "";
            mesa = new Mesa[quantidade_de_mesa];
            cliente = new Cliente();
            bebida = new Comanda_Bebida();
            comida = new Comanda_Comida();
        }

        public void Status_restaurante()
        {
            System.Console.WriteLine("Nome do Restaurante: {0}\nEndereço: {0}", nome_do_restaurante, endereco);
        }

        public void Cadastra_mesa(int quantidade_de_mesa)
        {
            for (int i = 0; i < quantidade_de_mesa; i++)
            {
                mesa[i] = new Mesa();
                mesa[i].atribui_mesa(i);
            }
        }

        public void Imprime_situacao(int quantidade_de_mesa)
        {
            for(int i = 0; i < quantidade_de_mesa; i++){
                System.Console.WriteLine("Mesa nº " + i + "\nEstado: " + mesa[i].reserva +"\n");
            }
        }

        public void reserva_de_mesa( int quantidade_de_mesa)
        {
            do
            {
                Console.WriteLine("Qual mesa o usuario deseja escolher: \n");
                Imprime_situacao(quantidade_de_mesa);
                escolha = int.Parse(Console.ReadLine());
                if (escolha < quantidade_de_mesa && mesa[escolha].reserva == false)
                {
                    Console.WriteLine("A mesa foi reservada!");
                    liberado = true;

                    Console.Write("Digite seu nome: ");
                    nome_do_cliente = Console.ReadLine();
                    Console.Write("\nDigite seu email: ");
                    email_do_cliente = Console.ReadLine();
                    Console.WriteLine("\nPara quantas pessoas deve ser a mesa: ");
                    numero_de_pessoas = int.Parse(Console.ReadLine());

                    cliente.Cadastra_Usuario(nome_do_cliente, email_do_cliente, numero_de_pessoas);

                    fazer_pedido();
                }
                else if (escolha < quantidade_de_mesa && mesa[escolha].reserva == true)
                {
                    Console.Clear();
                    Console.WriteLine("A mesa já esta reservada. Por favor escolha outra.\n");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Mesa inexistente, favor escolhar uma mesa valida.\n");
                }

            } while (liberado == false);
        }

        public void fazer_pedido()
        {
            liberado = false;
            do
            {
                Console.WriteLine("\n01 - Pedir bebida\n02 - Pedir comida\n03 - Checar o valor atual da comanda\n04 - Calcular 10% do garçom\n05 - Fechar a conta (para 1 pessoa)\n06 - Dividir a conta");
                escolha = 0;
                Console.WriteLine("\nEscolha uma opção: ");
                escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {

                    case 0:
                        {
                            Console.WriteLine("Opção invalida!");
                            break;
                        }
                    case 1:
                        {
                            Console.Clear();
                            bebida.pedido();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            comida.pedido();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            bebida.Listar_Consumo(comida.preco);
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("A porcentagem do garçom é R$" + bebida.calcular_10_porcento(comida.preco));
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            bebida.Listar_Consumo(comida.preco);
                            liberado = true;
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            Console.WriteLine("Quantas pessoas irão dividir a conta?");
                            dividir = int.Parse(Console.ReadLine());
                            valor = bebida.dividir_conta(dividir, numero_de_pessoas, comida.preco);
                            if (valor != 0)
                            {
                                Console.WriteLine("O valor fica de R$" + valor + " para cada");
                                liberado = true;
                            }
                            else
                            {
                                Console.WriteLine("Numero de pessoas que irão dividir esta invalido");
                            }
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Você escolheu uma opção invalida!");
                            break;
                        }

                        
                }
            } while (liberado == false);
        }

    }
}