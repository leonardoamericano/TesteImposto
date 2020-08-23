using Flunt.Notifications;
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
        }

        public void Gravar(NotaFiscal notaFiscal)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(NotaFiscal));
            
            StreamWriter stream = new StreamWriter(PathXml + $"NotaFiscal_{notaFiscal.NomeCliente}_{DateTime.Now.Ticks}.xml");

            serializador.Serialize(stream, notaFiscal);

            stream.Close();
        }
    }
}
