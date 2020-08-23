using Flunt.Notifications;
using Flunt.Validations;
using Imposto.Core.Entities;
using Imposto.Core.ValueObjects;
using Imposto.Shared.Commands;
using Imposto.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Commands
{
    public class EmissaoNotaFiscalCommand : Notifiable, ICommand
    {
        public EstadoDestino EstadoDestino { get; set; }
        public EEstados EstadoOrigem { get; set; }
        public string NomeCliente { get; set; }

        public List<PedidoItem> ItensDoPedido { get; set; }

        public EmissaoNotaFiscalCommand()
        {
            ItensDoPedido = new List<PedidoItem>();
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(NomeCliente, 3, "Pedido.NomeCliente", "Nome deve conter no mínimo 3 caracteres.")
                .HasMaxLen(NomeCliente, 50, "Pedido.NomeCliente", "Nome deve conter até 50 caracteres.")
            );
        }
    }
}
