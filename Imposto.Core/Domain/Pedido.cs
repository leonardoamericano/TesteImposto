using Flunt.Notifications;
using Flunt.Validations;
using Imposto.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Domain
{
    public class Pedido : Notifiable, ICommand
    {
        public string EstadoDestino { get; set; }
        public string EstadoOrigem { get; set; }

        public string NomeCliente { get; set; }

        public List<PedidoItem> ItensDoPedido { get; set; }

        public Pedido()
        {
            ItensDoPedido = new List<PedidoItem>();
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(EstadoDestino, 2, "Pedido.EstadoDestino", "EstadoDestino deve conter pelo menos 2 caracteres.")
                .HasMinLen(EstadoOrigem, 2, "Pedido.EstadoOrigem", "EstadoOrigem deve conter pelo menos 2 caracteres.")
                .HasMinLen(NomeCliente, 3, "Pedido.NomeCliente", "Nome deve conter no mínimo 3 caracteres.")
                .HasMaxLen(NomeCliente, 50, "Pedido.NomeCliente", "Nome deve conter até 50 caracteres.")
            );
        }
    }
}
