using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Repositories
{
    public interface IObterConexaoBD
    {
        IDbConnection ObterConexaoDB();
        IDbConnection Conectar();
        void Desconectar();
    }
}
