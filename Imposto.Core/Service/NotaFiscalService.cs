using Imposto.Core.Data;
using Imposto.Core.Domain;
using Imposto.Core.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Imposto.Core.Service
{
    public class NotaFiscalService
    {
        public string PathXml { get; private set; }
        private readonly INotaFiscalRepository _repository;

        public NotaFiscalService(INotaFiscalRepository repository, string pathXml)
        {
            _repository = repository;
            this.PathXml = pathXml;
        }

        public void GerarNotaFiscal(Domain.Pedido pedido)
        {
            NotaFiscal notaFiscal = new NotaFiscal();
            notaFiscal.EmitirNotaFiscal(pedido);
            //Gerar XML
            GravarXml(notaFiscal);
            //Salvar as informações
            _repository.CreateNotaFiscal(notaFiscal);
        }

        private void GravarXml(NotaFiscal notaFiscal)
        {
            XmlSerializer serializador = new XmlSerializer(notaFiscal.GetType());
            StreamWriter stream = new StreamWriter(PathXml + $"NotaFiscal_{notaFiscal.NomeCliente}_{DateTime.Now.Ticks}.xml");
            serializador.Serialize(stream, notaFiscal);
            stream.Close();
        }
    }
}
