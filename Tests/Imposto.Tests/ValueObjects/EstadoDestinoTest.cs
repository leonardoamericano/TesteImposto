using Imposto.Core.ValueObjects;
using Imposto.Shared.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imposto.Tests.ValueObjects
{
    [TestClass]
    public class EstadoDestinoTest
    {
        [TestMethod]
        public void ShouldReturnErrorWhenEstadoDestinoIsInvalid()
        {
            var obj = new EstadoDestino();
            Assert.IsTrue(obj.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(EEstados.Selecione)]
        public void ShouldReturnErrorWhenEstadoDestinoIsInvalid(EEstados estados)
        {
            var obj = new EstadoDestino(estados);
            Assert.IsTrue(obj.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenEstadoDestinoIsValid()
        {
            var obj = new EstadoDestino(EEstados.SP);
            Assert.IsTrue(obj.Valid);
        }
    }
}
