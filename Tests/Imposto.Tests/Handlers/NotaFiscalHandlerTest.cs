using Imposto.Core.Commands;
using Imposto.Core.Data;
using Imposto.Core.Entities;
using Imposto.Core.Handlers;
using Imposto.Core.Repositories;
using Imposto.Core.Service;
using Imposto.Core.ValueObjects;
using Imposto.Shared.Enums;
using Imposto.Tests.MOCK;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Imposto.Tests.Handlers
{
    [TestClass]
    public class NotaFiscalHandlerTest
    {
        private NotaFiscal _nota;
        private NotaFiscalItem _notaFiscalItem;
        private INotaFiscalRepository _repository;
        private EmissaoNotaFiscalCommand _pedido = new EmissaoNotaFiscalCommand();

        public NotaFiscalHandlerTest()
        {
            _pedido.EstadoOrigem = EEstados.SP;
            _pedido.EstadoDestino = new EstadoDestino(EEstados.SP);
            _pedido.NomeCliente = "textBoxNomeCliente";

            _pedido.ItensDoPedido.Add(
                    new PedidoItem()
                    {
                        Brinde = false,
                        CodigoProduto = "123456",
                        NomeProduto = "Nome do produto",
                        ValorItemPedido = 10
                    });

            _repository = new FakeRepository();
        }

        [TestMethod]
        public void ShouldReturnErrorWhenNotaFiscalRepositoryIsInvalid()
        {
            var obj = new NotaFiscalHandler(_repository, @"C:\Temp\");
            var retorno = obj.Handle(null);

            Assert.IsFalse(retorno.Success);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenNotaFiscalRepositoryIsValid()
        {
            var obj = new NotaFiscalHandler(_repository, @"C:\Temp\");
            var retorno = obj.Handle(_pedido);

            Assert.IsTrue(retorno.Success);
        }
    }
}
