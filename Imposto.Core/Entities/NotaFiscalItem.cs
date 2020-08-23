using Imposto.Core.ValueObjects;
using Imposto.Shared.Entities;
using Imposto.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Entities
{
    public class NotaFiscalItem: Entity
    {
        public int IdNotaFiscal { get; set; }
        public string Cfop { get; set; }
        public string TipoIcms { get; set; }
        public double BaseIcms { get; set; }
        public double AliquotaIcms { get; set; }
        public double ValorIcms { get; set; }
        public string NomeProduto { get; set; }
        public string CodigoProduto { get; set; }
        public double ValorIpi { get; set; }
        public double ValorDesconto { get; set; }

        public NotaFiscalItem(){}

        private EEstados Origem;
        private EstadoDestino Destino;

        public NotaFiscalItem(EEstados origem, EstadoDestino destino, double valorItemPedido, bool brinde, string nomeProduto, string codigoProduto)
        {
            Origem = origem;
            Destino = destino;
            this.NomeProduto = nomeProduto;
            this.CodigoProduto = codigoProduto;

            this.CalcularAlicotas(valorItemPedido, brinde);
        }

        private void CalcularAlicotas(double valorItemPedido, bool brinde)
        {
            if ((Origem == EEstados.SP) && (Destino.UF == EEstados.RJ))
            {
                this.Cfop = "6.000";
            }
            else if ((Origem == EEstados.SP) && (Destino.UF == EEstados.PE))
            {
                this.Cfop = "6.001";
            }
            else if ((Origem == EEstados.SP) && (Destino.UF == EEstados.MG))
            {
                this.Cfop = "6.002";
            }
            else if ((Origem == EEstados.SP) && (Destino.UF == EEstados.PB))
            {
                this.Cfop = "6.003";
            }
            else if ((Origem == EEstados.SP) && (Destino.UF == EEstados.PR))
            {
                this.Cfop = "6.004";
            }
            else if ((Origem == EEstados.SP) && (Destino.UF == EEstados.PI))
            {
                this.Cfop = "6.005";
            }
            else if ((Origem == EEstados.SP) && (Destino.UF == EEstados.RO))
            {
                //Correção do bug Execício 5
                this.Cfop = "6.006";
            }
            else if ((Origem == EEstados.SP) && (Destino.UF == EEstados.SE))
            {
                this.Cfop = "6.007";
            }
            else if ((Origem == EEstados.SP) && (Destino.UF == EEstados.TO))
            {
                this.Cfop = "6.008";
            }
            else if ((Origem == EEstados.SP) && (Destino.UF == EEstados.SE))
            {
                this.Cfop = "6.009";
            }
            else if ((Origem == EEstados.SP) && (Destino.UF == EEstados.PA))
            {
                this.Cfop = "6.010";
            }
            else if ((Origem == EEstados.MG) && (Destino.UF == EEstados.RJ))
            {
                this.Cfop = "6.000";
            }
            else if ((Origem == EEstados.MG) && (Destino.UF == EEstados.PE))
            {
                this.Cfop = "6.001";
            }
            else if ((Origem == EEstados.MG) && (Destino.UF == EEstados.MG))
            {
                this.Cfop = "6.002";
            }
            else if ((Origem == EEstados.MG) && (Destino.UF == EEstados.PB))
            {
                this.Cfop = "6.003";
            }
            else if ((Origem == EEstados.MG) && (Destino.UF == EEstados.PR))
            {
                this.Cfop = "6.004";
            }
            else if ((Origem == EEstados.MG) && (Destino.UF == EEstados.PI))
            {
                this.Cfop = "6.005";
            }
            else if ((Origem == EEstados.MG) && (Destino.UF == EEstados.RO))
            {
                this.Cfop = "6.006";
            }
            else if ((Origem == EEstados.MG) && (Destino.UF == EEstados.SE))
            {
                this.Cfop = "6.007";
            }
            else if ((Origem == EEstados.MG) && (Destino.UF == EEstados.TO))
            {
                this.Cfop = "6.008";
            }
            else if ((Origem == EEstados.MG) && (Destino.UF == EEstados.SE))
            {
                this.Cfop = "6.009";
            }
            else if ((Origem == EEstados.MG) && (Destino.UF == EEstados.PA))
            {
                this.Cfop = "6.010";
            }

            if (Destino.UF == Origem)
            {
                this.TipoIcms = "60";
                this.AliquotaIcms = 0.18;
            }
            else
            {
                this.TipoIcms = "10";
                this.AliquotaIcms = 0.17;
            }
            if (this.Cfop == "6.009")
            {
                this.BaseIcms = valorItemPedido * 0.90; //redução de base
            }
            else
            {
                this.BaseIcms = valorItemPedido;
            }
            this.ValorIcms = this.BaseIcms * this.AliquotaIcms;

            if (brinde)
            {
                this.TipoIcms = "60";
                this.AliquotaIcms = 0.18;
                this.ValorIcms = this.BaseIcms * this.AliquotaIcms;
                this.ValorIpi = 0;
            }
            else
            {
                this.ValorIpi = valorItemPedido * 0.10;
            }

            //Exercício 7
            this.ValorDesconto = (Destino.IsDestinoSudeste()) ? valorItemPedido * 0.10 : 0.0;
        }
    }
}
