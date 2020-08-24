using Flunt.Notifications;
using Flunt.Validations;
using Imposto.Core.Commands;
using Imposto.Core.Entities;
using Imposto.Core.Repositories;
using Imposto.Core.Service;
using Imposto.Shared.Commands;
using Imposto.Shared.Enums;
using Imposto.Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Handlers
{
    public class NotaFiscalHandler : Notifiable,
        IHandler<EmissaoNotaFiscalCommand>
    {
        private XMLService _XmlService;
        private readonly INotaFiscalRepository _repository;

        public NotaFiscalHandler(INotaFiscalRepository repository, string pathXml)
        {
            _repository = repository;
            this._XmlService = new XMLService(pathXml);
        }

        public ICommandResult Handle(EmissaoNotaFiscalCommand command)
        {
            if (command==null)
                return new CommandResult(false, "Não foi possível gravar a Nota Fiscal");

            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível gravar a Nota Fiscal");
            }

            //Emitir a nota fiscal
            NotaFiscal notaFiscal = this.EmitirNotaFiscal(command);

            //Agrupar as Validações
            AddNotifications(notaFiscal, command);

            //Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível gravar a Nota Fiscal");

            //Gerar XML
            if (_XmlService.Gravar(notaFiscal))
            {
                //Salvar as informações
                //_repository.CreateNotaFiscal(notaFiscal);
            }

            //Retornar informações
            return new CommandResult(true, "Nota Fiscal armazenada com sucesso");
        }

        private NotaFiscal EmitirNotaFiscal(EmissaoNotaFiscalCommand pedido)
        {
            NotaFiscal nota = new NotaFiscal(99999,
                                            new Random().Next(Int32.MaxValue),
                                            pedido.NomeCliente,
                                            pedido.EstadoDestino,
                                            pedido.EstadoOrigem
                                        );

            foreach (PedidoItem itemPedido in pedido.ItensDoPedido)
            {
                NotaFiscalItem notaFiscalItem = new NotaFiscalItem(
                        pedido.EstadoOrigem,
                        pedido.EstadoDestino,
                        itemPedido.ValorItemPedido,
                        itemPedido.Brinde,
                        itemPedido.NomeProduto,
                        itemPedido.CodigoProduto);

                nota.AddItensDaNotaFiscal(notaFiscalItem);
            }

            return nota;
        }
    }
}