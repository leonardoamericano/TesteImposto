using Imposto.Core.Entities;
using Imposto.Core.ValueObjects;
using Imposto.Shared.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Imposto.Tests.Entities
{
    [TestClass]
    public class NotaFiscalItemTest
    {
        [TestMethod]
        public void ShouldReturnErrorWhenNotaFiscalItemIsInvalid()
        {
            var obj = new NotaFiscalItem();

            Assert.IsTrue(obj.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenNotaFiscalItemSemEstadoOrigem()
        {
            var obj = new NotaFiscalItem(
                        EEstados.Selecione,
                        new EstadoDestino(EEstados.SP),
                        10,
                        false,
                        "NomeProduto",
                        "CodigoProduto");

            Assert.IsTrue(obj.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenNotaFiscalItemSemEstadoDestino()
        {
            var obj = new NotaFiscalItem(
                        EEstados.SP,
                        new EstadoDestino(EEstados.Selecione),
                        10,
                        false,
                        "NomeProduto",
                        "CodigoProduto");

            Assert.IsTrue(obj.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenNotaFiscalItemSemValor()
        {
            var obj = new NotaFiscalItem(
                        EEstados.SP,
                        new EstadoDestino(EEstados.SP),
                        0,
                        false,
                        "NomeProduto",
                        "CodigoProduto");

            Assert.IsTrue(obj.Invalid);
        }
        [TestMethod]
        public void ShouldReturnErrorWhenNotaFiscalItemSemNome()
        {
            var obj = new NotaFiscalItem(
                        EEstados.SP,
                        new EstadoDestino(EEstados.SP),
                        10,
                        false,
                        "",
                        "CodigoProduto");

            Assert.IsTrue(obj.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenNotaFiscalItemSemCodigo()
        {
            var obj = new NotaFiscalItem(
                        EEstados.SP,
                        new EstadoDestino(EEstados.SP),
                        10,
                        false,
                        "NomeProduto",
                        "");

            Assert.IsTrue(obj.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenNotaFiscalItemIsValid()
        {
            var obj = new NotaFiscalItem(
                        EEstados.SP,
                        new EstadoDestino(EEstados.SP),
                        10,
                        false,
                        "NomeProduto",
                        "CodigoProduto");

            Assert.IsTrue(obj.Valid);
        }
    }
}
