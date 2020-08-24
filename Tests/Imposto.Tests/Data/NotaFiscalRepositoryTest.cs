using Imposto.Core.Data;
using Imposto.Core.Repositories;
using Imposto.Tests.MOCK;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imposto.Tests.Data
{
    [TestClass]
    public class NotaFiscalRepositoryTest
    {
        IObterConexaoBD _conexaoBD;

        public NotaFiscalRepositoryTest()
        {
            _conexaoBD = new FakeConnection();
        }

        [TestMethod]
        public void ShouldReturnErrorWhenNotaFiscalRepositoryIsInvalid()
        {
            var obj = new NotaFiscalRepository(null);

            Assert.IsTrue(obj.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenNotaFiscalItemIsValid()
        {
            var obj = new NotaFiscalRepository(_conexaoBD);

            Assert.IsTrue(obj.Valid);
        }
    }
}
