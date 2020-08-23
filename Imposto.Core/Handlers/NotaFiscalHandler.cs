using Flunt.Notifications;
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
        private NotaFiscalService _NotaFiscalService;
        private readonly INotaFiscalRepository _repository;

        public NotaFiscalHandler(INotaFiscalRepository repository, string pathXml)
        {
            _repository = repository;
            this._NotaFiscalService = new NotaFiscalService(pathXml);
        }

        public ICommandResult Handle(EmissaoNotaFiscalCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível gravar a Nota Fiscal");
            }

            NotaFiscal notaFiscal = this.EmitirNotaFiscal(command);

            //Agrupar as Validações
            AddNotifications(notaFiscal, command);

            //Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível gravar a Nota Fiscal");

            //Gerar XML
            _NotaFiscalService.GravarXml(notaFiscal);

            //Salvar as informações
            //_repository.CreateNotaFiscal(notaFiscal);

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
                NotaFiscalItem notaFiscalItem = new NotaFiscalItem();
                if ((nota.EstadoOrigem == EEstados.SP) && (nota.EstadoDestino.UF == EEstados.RJ))
                {
                    notaFiscalItem.Cfop = "6.000";
                }
                else if ((nota.EstadoOrigem == EEstados.SP) && (nota.EstadoDestino.UF == EEstados.PE))
                {
                    notaFiscalItem.Cfop = "6.001";
                }
                else if ((nota.EstadoOrigem == EEstados.SP) && (nota.EstadoDestino.UF == EEstados.MG))
                {
                    notaFiscalItem.Cfop = "6.002";
                }
                else if ((nota.EstadoOrigem == EEstados.SP) && (nota.EstadoDestino.UF == EEstados.PB))
                {
                    notaFiscalItem.Cfop = "6.003";
                }
                else if ((nota.EstadoOrigem == EEstados.SP) && (nota.EstadoDestino.UF == EEstados.PR))
                {
                    notaFiscalItem.Cfop = "6.004";
                }
                else if ((nota.EstadoOrigem == EEstados.SP) && (nota.EstadoDestino.UF == EEstados.PI))
                {
                    notaFiscalItem.Cfop = "6.005";
                }
                else if ((nota.EstadoOrigem == EEstados.SP) && (nota.EstadoDestino.UF == EEstados.RO))
                {
                    notaFiscalItem.Cfop = "6.006";
                }
                else if ((nota.EstadoOrigem == EEstados.SP) && (nota.EstadoDestino.UF == EEstados.SE))
                {
                    notaFiscalItem.Cfop = "6.007";
                }
                else if ((nota.EstadoOrigem == EEstados.SP) && (nota.EstadoDestino.UF == EEstados.TO))
                {
                    notaFiscalItem.Cfop = "6.008";
                }
                else if ((nota.EstadoOrigem == EEstados.SP) && (nota.EstadoDestino.UF == EEstados.SE))
                {
                    notaFiscalItem.Cfop = "6.009";
                }
                else if ((nota.EstadoOrigem == EEstados.SP) && (nota.EstadoDestino.UF == EEstados.PA))
                {
                    notaFiscalItem.Cfop = "6.010";
                }
                else if ((nota.EstadoOrigem == EEstados.MG) && (nota.EstadoDestino.UF == EEstados.RJ))
                {
                    notaFiscalItem.Cfop = "6.000";
                }
                else if ((nota.EstadoOrigem == EEstados.MG) && (nota.EstadoDestino.UF == EEstados.PE))
                {
                    notaFiscalItem.Cfop = "6.001";
                }
                else if ((nota.EstadoOrigem == EEstados.MG) && (nota.EstadoDestino.UF == EEstados.MG))
                {
                    notaFiscalItem.Cfop = "6.002";
                }
                else if ((nota.EstadoOrigem == EEstados.MG) && (nota.EstadoDestino.UF == EEstados.PB))
                {
                    notaFiscalItem.Cfop = "6.003";
                }
                else if ((nota.EstadoOrigem == EEstados.MG) && (nota.EstadoDestino.UF == EEstados.PR))
                {
                    notaFiscalItem.Cfop = "6.004";
                }
                else if ((nota.EstadoOrigem == EEstados.MG) && (nota.EstadoDestino.UF == EEstados.PI))
                {
                    notaFiscalItem.Cfop = "6.005";
                }
                else if ((nota.EstadoOrigem == EEstados.MG) && (nota.EstadoDestino.UF == EEstados.RO))
                {
                    notaFiscalItem.Cfop = "6.006";
                }
                else if ((nota.EstadoOrigem == EEstados.MG) && (nota.EstadoDestino.UF == EEstados.SE))
                {
                    notaFiscalItem.Cfop = "6.007";
                }
                else if ((nota.EstadoOrigem == EEstados.MG) && (nota.EstadoDestino.UF == EEstados.TO))
                {
                    notaFiscalItem.Cfop = "6.008";
                }
                else if ((nota.EstadoOrigem == EEstados.MG) && (nota.EstadoDestino.UF == EEstados.SE))
                {
                    notaFiscalItem.Cfop = "6.009";
                }
                else if ((nota.EstadoOrigem == EEstados.MG) && (nota.EstadoDestino.UF == EEstados.PA))
                {
                    notaFiscalItem.Cfop = "6.010";
                }

                //Correção do bug Execício 5
                if ((nota.EstadoOrigem == EEstados.SP) || (nota.EstadoDestino.UF == EEstados.RO))
                {
                    notaFiscalItem.Cfop = "6.006";
                }

                if (nota.EstadoDestino.UF == nota.EstadoOrigem)
                {
                    notaFiscalItem.TipoIcms = "60";
                    notaFiscalItem.AliquotaIcms = 0.18;
                }
                else
                {
                    notaFiscalItem.TipoIcms = "10";
                    notaFiscalItem.AliquotaIcms = 0.17;
                }
                if (notaFiscalItem.Cfop == "6.009")
                {
                    notaFiscalItem.BaseIcms = itemPedido.ValorItemPedido * 0.90; //redução de base
                }
                else
                {
                    notaFiscalItem.BaseIcms = itemPedido.ValorItemPedido;
                }
                notaFiscalItem.ValorIcms = notaFiscalItem.BaseIcms * notaFiscalItem.AliquotaIcms;

                if (itemPedido.Brinde)
                {
                    notaFiscalItem.TipoIcms = "60";
                    notaFiscalItem.AliquotaIcms = 0.18;
                    notaFiscalItem.ValorIcms = notaFiscalItem.BaseIcms * notaFiscalItem.AliquotaIcms;
                    notaFiscalItem.ValorIpi = 0;
                }
                else
                {
                    notaFiscalItem.ValorIpi = itemPedido.ValorItemPedido * 0.10;
                }

                notaFiscalItem.NomeProduto = itemPedido.NomeProduto;
                notaFiscalItem.CodigoProduto = itemPedido.CodigoProduto;
                
                //Exercício 7
                notaFiscalItem.ValorDesconto = (nota.EstadoDestino.IsDestinoSudeste())?itemPedido.ValorItemPedido * 0.10:0.0;

                nota.AddItensDaNotaFiscal(notaFiscalItem);
            }

            return nota;
        }
    }
}