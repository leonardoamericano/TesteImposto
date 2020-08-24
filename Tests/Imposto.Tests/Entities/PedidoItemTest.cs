using Imposto.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imposto.Tests.Entities
{
    [TestClass]
    public class PedidoItemTest
    {
        [TestMethod]
        public void ShouldReturnErrorWhenPedidoItemIsInvalid()
        {
            var obj = new PedidoItem();

            Assert.IsTrue(obj.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenPedidoItemIsValid()
        {
            var obj = new PedidoItem(
                "Nome do produto",
                "123456",
                10,
                false);

            Assert.IsTrue(obj.Valid);
        }
    }
}
