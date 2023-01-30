using System;

namespace tri
{
    public class Mesa
    {
        public int numero_da_mesa { get; private set; }
        public string data { get; private set;}
        public bool reserva {get; private set;}
        
        Random rand = new Random();

        public Mesa(){
            numero_da_mesa = 0;
            data = "xx/xx/xxxx";
            reserva = false;
        }

        public void atribui_mesa(int numero)
        {
            numero_da_mesa = numero;
            reserva = rand.Next(2) == 1;
        }

    }
}