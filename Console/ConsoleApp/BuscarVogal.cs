using System;

namespace ConsoleApp
{
    public class BuscarVogal
    {
        /// <summary>
        /// Questão 2) Dada uma stream, encontre o primeiro caracter Vogal, após uma
        /// consoante e que não se repita no resto da stream. O termino da leitura da stream
        /// deve ser garantido através do método hasNext(), ou seja, retorna falso para o
        /// termino da leitura da stream.Voce tera acesso a leitura da stream através dos
        /// métodos de interface fornecidos ao termino do enunciado.
        /// </summary>
        public char UnicaAposConsoante(Stream input)
        {
            const string vogais = @"AEIOU";
            const string consoantes = @"BCDFGHJKLMNPQRSTVWXYZ";

            char c;
            char cAnterior = new char();

            string vogaisAux = @"AEIOU";
            char vogalUnica = new char();
            bool isConsoante = false;

            while (input.hasNext())
            {
                if ((!char.Equals(cAnterior, new char())) && (consoantes.Contains(cAnterior.ToString().ToUpper())))
                    isConsoante = true;

                c = input.getNext();
                if (vogais.Contains(c.ToString().ToUpper()))
                {
                    if (vogaisAux.Contains(c.ToString().ToUpper()))
                        vogalUnica = (isConsoante) ? c : vogalUnica;
                    else
                        vogalUnica = new char();

                    vogaisAux = vogaisAux.Replace(c.ToString().ToUpper(), "");
                }

                cAnterior = c;
                isConsoante = false;
            }

            return vogalUnica;
        }
    }
}
