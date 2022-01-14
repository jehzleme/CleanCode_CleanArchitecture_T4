using CCCA.Dominio.Entidades;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace CCCA.Dominio.Tests
{
    public class PedidoCodigoTest
    {
        [Test]
        public void Deve_Criar_Um_Codigo_De_Pedido()
        {
            var data = DateTime.UtcNow;
            var sequencia = 1;
            var pedidoCodigo = new PedidoCodigo(data, sequencia);
            var numeroCodigo = pedidoCodigo.Numero;

            var expected = "20221";

            numeroCodigo.Should().Be(expected);
        }
    }
}