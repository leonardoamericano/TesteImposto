using Imposto.Core.Entities;
using Imposto.Core.Service;
using Imposto.Core.ValueObjects;
using Imposto.Shared.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Imposto.Tests.Service
{
    [TestClass]
    public class XmlServiceTest
    {
        private NotaFiscal _nota;
        private NotaFiscalItem _notaFiscalItem;

        public XmlServiceTest()
        {
            _nota = new NotaFiscal(99999,
                new Random().Next(Int32.MaxValue),
                "Cliente de teste",
                new EstadoDestino(EEstados.SP),
                EEstados.SP);

            _notaFiscalItem = new NotaFiscalItem(
                        _nota.EstadoOrigem,
                        _nota.EstadoDestino,
                        10,
                        false,
                        "NomeProduto",
                        "CodigoProduto");

            _nota.AddItensDaNotaFiscal(_notaFiscalItem);


        }

        [TestMethod]
        public void ShouldReturnErrorWhenXmlServiceIsInvalid()
        {
            var obj = new XMLService("");
            Assert.IsTrue(obj.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenXmlServiceIsValid()
        {
            var obj = new XMLService(@"C:\temp\");
            Assert.IsTrue(obj.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenGravarXmlNull()
        {
            var obj = new XMLService("");
            obj.Gravar(null);

            Assert.IsTrue(obj.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenGravarXmlIsInvalid()
        {
            var obj = new XMLService("");
            obj.Gravar(_nota);

            Assert.IsTrue(obj.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenGravarXmlIsValid()
        {
            var obj = new XMLService(@"C:\temp\");
            obj.Gravar(_nota);

            Assert.IsTrue(obj.Valid);
        }
    }
}

