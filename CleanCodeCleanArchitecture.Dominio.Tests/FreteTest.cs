using CleanCodeCleanArchitecture.Dominio.Entidades;
using FluentAssertions;
using NUnit.Framework;

namespace CleanCodeCleanArchitecture.Dominio.Tests
{
    public class FreteTest
    {
        [Test]
        public void Deve_Calcular_Frete_Maior_Que_Valor_Minimo()
        {
            var cpf = "821.369.750-21";
            var pedido = new Pedido(cpf);
            double distancia = 100;
            pedido.AdicionarItem(new Item("Geladeira", 3500.0, 200, 100, 50, 40), 1);

            pedido.CalcularFrete(distancia);

            pedido.Frete.Should().BeGreaterThan(10);
        }
        
        [Test]
        public void Deve_Calcular_Frete_Menor_Que_Valor_Minimo()
        {
            var cpf = "821.369.750-21";
            var pedido = new Pedido(cpf);
            double distancia = 5;
            pedido.AdicionarItem(new Item("Camera", 1240.0, 20, 15, 10, 1), 1);
           
            pedido.CalcularFrete(distancia);

            pedido.Frete.Should().Be(10);
        }
    }
}
