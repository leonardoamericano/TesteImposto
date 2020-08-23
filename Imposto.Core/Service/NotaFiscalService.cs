using Flunt.Notifications;
using Imposto.Core.Commands;
using Imposto.Core.Data;
using Imposto.Core.Domain;
using Imposto.Core.Repositories;
using Imposto.Shared.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Imposto.Core.Service
{
    public class NotaFiscalService : Notifiable
    {
        public string PathXml { get; private set; }
        private readonly INotaFiscalRepository _repository;

        public NotaFiscalService(INotaFiscalRepository repository, string pathXml)
        {
            _repository = repository;
            this.PathXml = pathXml;
        }

        public ICommandResult GerarNotaFiscal(Domain.Pedido pedido)
        {
            //Fail Fast Validation
            pedido.Validate();
            if (pedido.Invalid)
            {
                AddNotifications(pedido);
                return new CommandResult(false, "Não foi possível gravar a Nota Fiscal");
            }

            NotaFiscal notaFiscal = new NotaFiscal();
            notaFiscal.EmitirNotaFiscal(pedido);

            //Agrupar as Validações
            AddNotifications(notaFiscal, pedido);

            //Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível gravar a Nota Fiscal");

            //Gerar XML
            GravarXml(notaFiscal);
            //Salvar as informações
            //_repository.CreateNotaFiscal(notaFiscal);

            //Retornar informações
            return new CommandResult(true, "Nota Fiscal armazenada com sucesso");

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
