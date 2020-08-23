using Imposto.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Repositories
{
    public interface INotaFiscalRepository
    {
        void CreateNotaFiscal(NotaFiscal notaFiscal);
    }
}
