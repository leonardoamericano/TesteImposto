using Imposto.Core.Commands;
using Imposto.Core.ValueObjects;
using Imposto.Shared.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imposto.Tests.Commands
{
    [TestClass]
    public class EmissaoNotaFiscalCommandTest
    {
        [TestMethod]
        public void ShouldReturnErrorWhenEmissaoNotaFiscalCommandIsInvalid()
        {
            var obj = new EmissaoNotaFiscalCommand();
            obj.Validate();

            Assert.AreEqual(false, obj.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenEmissaoNotaFiscalCommandSemNome()
        {
            var obj = new EmissaoNotaFiscalCommand();
            obj.EstadoDestino = new EstadoDestino(EEstados.SP);
            obj.EstadoOrigem = EEstados.SP;
            obj.Validate();

            Assert.AreEqual(false, obj.Valid);
        }
        [TestMethod]
        public void ShouldReturnErrorWhenEmissaoNotaFiscalCommandSemEstadoOrigem()
        {
            var obj = new EmissaoNotaFiscalCommand();
            obj.NomeCliente = "Cliente de teste";
            obj.EstadoDestino = new EstadoDestino(EEstados.SP);
            obj.Validate();

            Assert.AreEqual(false, obj.Valid);
        }
        [TestMethod]
        public void ShouldReturnErrorWhenEmissaoNotaFiscalCommandSemEstadoDestino()
        {
            var obj = new EmissaoNotaFiscalCommand();
            obj.NomeCliente = "Cliente de teste";
            obj.EstadoOrigem = EEstados.SP;
            obj.Validate();

            Assert.AreEqual(false, obj.Valid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenEmissaoNotaFiscalCommandIsValid()
        {
            var obj = new EmissaoNotaFiscalCommand();
            obj.NomeCliente = "Cliente de teste";
            obj.EstadoDestino = new EstadoDestino(EEstados.SP);
            obj.EstadoOrigem = EEstados.SP;

            obj.Validate();

            Assert.AreEqual(true, obj.Valid);
        }
    }
}
