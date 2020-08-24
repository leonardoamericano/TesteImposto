using Flunt.Notifications;
using Flunt.Validations;
using Imposto.Core.ValueObjects;
using Imposto.Shared.Entities;
using Imposto.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Imposto.Core.Entities
{
    public class NotaFiscal : Entity
    {
        public int NumeroNotaFiscal { get; set; }
        public int Serie { get; set; }
        public string NomeCliente { get; set; }
        public EstadoDestino EstadoDestino { get; set; }
        public EEstados EstadoOrigem { get; set; }

        public List<NotaFiscalItem> ItensDaNotaFiscal { get; set; }

        //construtor sem parametros exigido pelo serialize
        public NotaFiscal() {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(NumeroNotaFiscal, 0, "NotaFiscal.NumeroNotaFiscal", "O Numero da Nota Fiscal deve ser maior que 0")
                .IsGreaterThan(Serie, 0, "NotaFiscal.Serie", "O Numero da Nota Fiscal deve ser maior que 0")
                .HasMinLen(NomeCliente, 3, "NotaFiscal.NomeCliente", "O Nome do Cliente não pode ter menos de 3 caracteres")
                .IsNotNull(EstadoOrigem, "NotaFiscal.EstadoOrigem", "O Campo EstadoOrigem é obrigatório")
            );
        }

        public NotaFiscal(
            int numeroNotaFiscal,
            int serie,
            string nomeCliente,
            EstadoDestino estadoDestino,
            EEstados estadoOrigem
            )
        {
            NumeroNotaFiscal = numeroNotaFiscal;
            Serie = serie;
            NomeCliente = nomeCliente;
            EstadoDestino = estadoDestino;
            EstadoOrigem = estadoOrigem;

            AddNotifications(estadoDestino);

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(NumeroNotaFiscal, 0, "NotaFiscal.NumeroNotaFiscal", "O Numero da Nota Fiscal deve ser maior que 0")
                .IsGreaterThan(Serie, 0,"NotaFiscal.Serie", "O Numero da Nota Fiscal deve ser maior que 0")
                .HasMinLen(NomeCliente, 3, "NotaFiscal.NomeCliente", "O Nome do Cliente não pode ter menos de 3 caracteres")
                .IsNotNull(estadoOrigem, "NotaFiscal.EstadoOrigem", "O Campo EstadoOrigem é obrigatório")
                .AreNotEquals(estadoOrigem.ToString(), EEstados.Selecione.ToString(),"NotaFiscal.EstadoOrigem", "O Campo EstadoOrigem Precisa ser um estado válido")
            );

            ItensDaNotaFiscal = new List<NotaFiscalItem>();
        }

        public void AddItensDaNotaFiscal(NotaFiscalItem item)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(item.CodigoProduto, 3, "Notafiscal.ItensDaNotaFiscal", "O Codigo do Produto não pode ter menos de 3 caracteres")
          );

            ItensDaNotaFiscal.Add(item);
        }

    }
}
