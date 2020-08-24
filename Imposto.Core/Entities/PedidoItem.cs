using Flunt.Validations;
using Imposto.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Entities
{
    public class PedidoItem : Entity
    {
        public string NomeProduto { get; set; }
        public string CodigoProduto { get; set; }        
        public double ValorItemPedido { get; set; }
        public bool Brinde { get; set; }

        public PedidoItem()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(NomeProduto, "PedidoItem.NomeProduto", "Campo NomeProduto obrigatório")
                .IsNotNullOrEmpty(CodigoProduto, "PedidoItem.CodigoProduto", "Campo CodigoProduto obrigatório")
                .IsGreaterThan(ValorItemPedido, 0 , "PedidoItem.ValorItemPedido", "Campo ValorItemPedido obrigatório")
            );
        }

        public PedidoItem(  string nomeProduto ,
                            string codigoProduto ,
                            double valorItemPedido ,
                            bool brinde)
        {

            NomeProduto = nomeProduto;
            CodigoProduto = codigoProduto;
            ValorItemPedido = valorItemPedido;
            Brinde = brinde;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(NomeProduto, "PedidoItem.NomeProduto", "Campo NomeProduto obrigatório")
                .IsNotNullOrEmpty(CodigoProduto, "PedidoItem.CodigoProduto", "Campo CodigoProduto obrigatório")
                .IsGreaterThan(ValorItemPedido, 0, "PedidoItem.ValorItemPedido", "Campo ValorItemPedido obrigatório")
            );
        }

    }
}
