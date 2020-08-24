using Flunt.Notifications;
using Flunt.Validations;
using Imposto.Core.Entities;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Imposto.Core.Service
{
    public class XMLService : Notifiable
    {
        public string PathXml { get; private set; }

        public XMLService(string pathXml)
        {
            this.PathXml = pathXml;

            AddNotifications(new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(this.PathXml, "XMLService.PathXml", "Path obrigatório para geração do XML")
                );
        }

        public bool Gravar(NotaFiscal notaFiscal)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(notaFiscal, "XMLService.NotaFiscal", "NotaFiscal obrigatório para geração do XML")
            );

            if (this.Invalid)
                return false;

            XmlSerializer serializador = new XmlSerializer(typeof(NotaFiscal));
            
            StreamWriter stream = new StreamWriter(PathXml + $"NotaFiscal_{notaFiscal.NomeCliente}_{DateTime.Now.Ticks}.xml");

            serializador.Serialize(stream, notaFiscal);

            stream.Close();

            return true;
        }
    }
}
