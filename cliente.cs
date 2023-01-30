using System;

namespace tri
{
    public class Cliente
    {
        public string nome_do_cliente {get; private set;}
        public string email {get; private set;}
        public int qnt_pessoas { get; private set; }

        public void Cadastra_Usuario(string nome, string mail, int num_pessoas)
        {
            nome_do_cliente = nome;
            email = mail;
            qnt_pessoas = num_pessoas;
        }
    }
}