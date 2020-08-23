using Flunt.Notifications;
using Imposto.Core.Entities;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Imposto.Core.Service
{
    public class NotaFiscalService : Notifiable
    {
        public string PathXml { get; private set; }

        public NotaFiscalService(string pathXml)
        {
            this.PathXml = pathXml;
        }

        public void GravarXml(NotaFiscal notaFiscal)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(NotaFiscal));
            //DataContractSerializer serializador = new DataContractSerializer(typeof(NotaFiscal));
            
            StreamWriter stream = new StreamWriter(PathXml + $"NotaFiscal_{notaFiscal.NomeCliente}_{DateTime.Now.Ticks}.xml");
            
            //FileStream writer = new FileStream(PathXml + $"NotaFiscal_{notaFiscal.NomeCliente}_{DateTime.Now.Ticks}.xml", FileMode.Create);

            serializador.Serialize(stream, notaFiscal);
            //serializador.WriteObject(writer, notaFiscal);
            stream.Close();
            //writer.Close();
        }
    }
}
