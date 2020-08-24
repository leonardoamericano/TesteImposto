using Imposto.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Imposto.Tests.MOCK
{
    public class FakeConnection : IObterConexaoBD
    {
        public IDbConnection Conectar()
        {
            throw new NotImplementedException();
        }

        public void Desconectar()
        {
            throw new NotImplementedException();
        }

        public IDbConnection ObterConexaoDB()
        {
            throw new NotImplementedException();
        }
    }
}
