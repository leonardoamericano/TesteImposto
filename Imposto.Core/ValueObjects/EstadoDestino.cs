using Flunt.Validations;
using Imposto.Shared.Enums;
using Imposto.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.ValueObjects
{
    public class EstadoDestino : ValueObject
    {
        private string _match = "(AC|AL|AP|AM|BA|CE|DF|GO|ES|MA|MT|MS|MG|PA|PB|PR|PE|PI|RJ|RN|RS|RO|RR|SP|SC|SE|TO)";
        public EstadoDestino()
        {
            AddNotifications(new Contract()
                .Requires()
                .Matchs(UF.ToString(), _match, "EstadoDestino.UF", "")
            );
        }

        public EstadoDestino(EEstados estado)
        {
            UF = estado;

            AddNotifications(new Contract()
                .Requires()
                .Matchs(UF.ToString(), _match, "EstadoDestino.UF", "")
            );
        }


        public EEstados UF { get; set; }

        public bool IsDestinoSudeste()
        {
            string[] sudeste = { "SP", "RJ", "ES", "MG" };

            return (Array.Exists(sudeste, element => element == this.UF.ToString()));
        }
    }
}
