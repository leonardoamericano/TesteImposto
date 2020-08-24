using Imposto.Core.Entities;
using Imposto.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imposto.Tests.MOCK
{
    public class FakeRepository : INotaFiscalRepository
    {
        public void CreateNotaFiscal(NotaFiscal notaFiscal)
        {
            throw new NotImplementedException();
        }
    }
}
