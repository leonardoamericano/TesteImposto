using Imposto.Core.Entities;
using Imposto.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Data
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private SqlConnection db = null;

        public NotaFiscalRepository(IObterConexaoBD conexaoBD)
        {
            this.db = conexaoBD.ObterConexaoDB();
        }

        public void CreateNotaFiscal(NotaFiscal notaFiscal)
        {
            var id = Salvar(notaFiscal);
            if (id == -1)
                return;

            SalvarItens(notaFiscal.ItensDaNotaFiscal.ToList(), id);
        }

        private int Salvar(NotaFiscal notaFiscal)
        {
            int id = -1;

            DbCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "[dbo].[P_NOTA_FISCAL]";
            command.Connection = db;

            SqlParameter param1 = new SqlParameter("@pId", 0);
            command.Parameters.Add(param1);
            command.Parameters.Add(new SqlParameter("@pNumeroNotaFiscal", notaFiscal.NumeroNotaFiscal));
            command.Parameters.Add(new SqlParameter("@pSerie", notaFiscal.Serie));
            command.Parameters.Add(new SqlParameter("@pNomeCliente", notaFiscal.NomeCliente));
            command.Parameters.Add(new SqlParameter("@pEstadoDestino", notaFiscal.EstadoDestino));
            command.Parameters.Add(new SqlParameter("@pEstadoOrigem", notaFiscal.EstadoOrigem));

            SqlParameter returnValue = new SqlParameter("@pId", id);
            returnValue.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(returnValue);

            command.Connection.Open();
            command.ExecuteNonQuery();
            int result = (int)command.Parameters["pId"].Value;
            command.Connection.Close();

            notaFiscal.Id = id;
            return id;
        }

        private void SalvarItens(List<NotaFiscalItem> notaFiscalItem, int id)
        {
            foreach (var item in notaFiscalItem)
            {
                SqlCommand command = new SqlCommand("[dbo].[P_NOTA_FISCAL_ITEM]", db);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@pId", SqlDbType.Int)).Value = 0;
                command.Parameters.Add(new SqlParameter("@pIdNotaFiscal", SqlDbType.Int)).Value = item.IdNotaFiscal;
                command.Parameters.Add(new SqlParameter("@pCfop", SqlDbType.VarChar)).Value = item.Cfop;
                command.Parameters.Add(new SqlParameter("@pTipoIcms", SqlDbType.VarChar)).Value = item.TipoIcms;
                command.Parameters.Add(new SqlParameter("@pBaseIcms", SqlDbType.Decimal)).Value = item.BaseIcms;
                command.Parameters.Add(new SqlParameter("@pAliquotaIcms", SqlDbType.Decimal)).Value = item.AliquotaIcms;
                command.Parameters.Add(new SqlParameter("@pValorIcms", SqlDbType.Decimal)).Value = item.ValorIcms;
                command.Parameters.Add(new SqlParameter("@pNomeProduto", SqlDbType.VarChar)).Value = item.NomeProduto;
                command.Parameters.Add(new SqlParameter("@pCodigoProduto", SqlDbType.VarChar)).Value = item.CodigoProduto;
                command.Parameters.Add(new SqlParameter("@ValorIpi", SqlDbType.Decimal)).Value = item.ValorIpi;
                command.Parameters.Add(new SqlParameter("@ValorDesconto", SqlDbType.Decimal)).Value = item.ValorDesconto;
                command.ExecuteNonQuery();
            }
        }
    }
}
