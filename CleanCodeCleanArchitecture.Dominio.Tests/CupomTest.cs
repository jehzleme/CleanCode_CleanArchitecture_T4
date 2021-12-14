using CCCA.Dominio.Entidades;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace CCCA.Dominio.Tests
{
    public class CupomTest
    {
        [Test]
        public void Nao_Deve_Aplicar_Cupom_Expirado()
        {
            var cpf = "821.369.750-21";
            var pedido = new Pedido(cpf);
            var desconto = new Cupom("BLACK40", DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1));    
            pedido.AdicionarItem(new Item("Caneta", 1.50, 15, 3, 1, 0.01), 2);
            
            pedido.AdicionarCupom(desconto);

            pedido.Desconto.Should().BeNull();
        }
        
        [Test]
        public void Deve_Aplicar_Cupom_Vigente()
        {
            var cpf = "821.369.750-21";
            var pedido = new Pedido(cpf);
            var desconto = new Cupom("5off", DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
            pedido.AdicionarItem(new Item("Caneta", 1.50, 15, 3, 1, 0.01), 2);
            
            pedido.AdicionarCupom(desconto);

            pedido.Desconto.Should().Be(desconto);
        }
        
        [Test]
        public void Deve_Aplicar_Cupom_Sem_Data_Vigencia()
        {
            var cpf = "821.369.750-21";
            var pedido = new Pedido(cpf);
            var desconto = new Cupom("5off", null, null);
            pedido.AdicionarItem(new Item("Caneta", 1.50, 15, 3, 1, 0.01), 2);
            
            pedido.AdicionarCupom(desconto);

            pedido.Desconto.Should().Be(desconto);
        }
    }
}
