using Imposto.Core.Entities;
using Imposto.Core.ValueObjects;
using Imposto.Shared.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Imposto.Tests.Entities
{
    [TestClass]
    public class NotaFiscalTest
    {
        [TestMethod]
        public void ShouldReturnErrorWhenNotaFiscalIsInvalid()
        {
            var obj = new NotaFiscal();

            Assert.IsTrue(obj.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenNotaFiscalSemNumero()
        {
            var obj = new NotaFiscal(0,
                new Random().Next(Int32.MaxValue),
                "Cliente de teste",
                new EstadoDestino(EEstados.SP),
                EEstados.SP);

            Assert.IsTrue(obj.Invalid);
        }
        [TestMethod]
        public void ShouldReturnErrorWhenNotaFiscalSemSerie()
        {
            var obj = new NotaFiscal(99999,
                0,
                "Cliente de teste",
                new EstadoDestino(EEstados.SP),
                EEstados.SP);

            Assert.IsTrue(obj.Invalid);
        }
        [TestMethod]
        public void ShouldReturnErrorWhenNotaFiscalSemNome()
        {
            var obj = new NotaFiscal(99999,
                new Random().Next(Int32.MaxValue),
                "",
                new EstadoDestino(EEstados.SP),
                EEstados.SP);

            Assert.IsTrue(obj.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenNotaFiscalSemEstadoDestino()
        {
            var obj = new NotaFiscal(99999,
                new Random().Next(Int32.MaxValue),
                "teste teste",
                new EstadoDestino(),
                EEstados.SP);

            Assert.IsTrue(obj.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenNotaFiscalSemEstadoOrigem()
        {
            var obj = new NotaFiscal(99999,
                new Random().Next(Int32.MaxValue),
                "teste teste",
                new EstadoDestino(EEstados.SP),
                EEstados.Selecione);

            Assert.IsTrue(obj.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenNotaFiscalIsValid()
        {
            var obj = new NotaFiscal(99999,
                new Random().Next(Int32.MaxValue),
                "Cliente de teste",
                new EstadoDestino(EEstados.SP),
                EEstados.SP);

            Assert.IsTrue(obj.Valid);
        }
    }
}
