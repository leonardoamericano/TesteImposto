using System;

namespace ConsoleApp
{
    public class Stream : IStream
    {
        public String stream;

        private int indexOf = 0;

        public Stream(String stream)
        {
            this.stream = stream;
        }

        //Retorna próximo caracter do stream
        public char getNext()
        {
            return this.stream[indexOf++];
        }

        //Valida se existem mais caracteres
        public Boolean hasNext()
        {
            return (this.stream.Length > indexOf);
        }
    }
}
