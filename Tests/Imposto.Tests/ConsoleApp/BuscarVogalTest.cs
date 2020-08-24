using ConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imposto.Tests.ConsoleApp
{
    [TestClass]
    public class BuscarVogalTest
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow("")]
        [DataRow("eeeeeeeeeee")]
        [DataRow("aaaaaaaaaaa")]
        public void ShouldReturnErrorWhenbuscarVogalUnicaAposConsoanteIsInvalid(string imput)
        {
            var buscarVogal = new BuscarVogal();
            var resultado = buscarVogal.UnicaAposConsoante(new Stream(imput));

            Assert.AreEqual("Caractere não encontrado", resultado);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("aAbBABacfe")]
        [DataRow("aoAbBABacfe")]
        [DataRow("aoAbBABacfeu")]
        public void ShouldReturnSuccessWhenVogalUnicaAposConsoanteIsValid(string imput)
        {
            var buscarVogal = new BuscarVogal();
            var resultado = buscarVogal.UnicaAposConsoante(new Stream(imput));

            Assert.AreEqual("e", resultado);
        }

    }
}
