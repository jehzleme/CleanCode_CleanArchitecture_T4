using CCCA.Dominio.Entidades;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace CCCA.Dominio.Tests
{
    public class CpfTest
    {
        [TestCase("111.111.111-11")]
        [TestCase("123.456.789-00")]
        [TestCase("123.456.789-000")]
        [TestCase("123.456.7890-00")]
        [TestCase("111.456.789-00")]
        [TestCase("sgdfsdfh")]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Deve_Invalidar_Cpf(string cpf)
        {
            var expected = Assert.Throws<Exception>(() => new Cpf(cpf));

            expected.Message.Should().BeEquivalentTo("CPF inválido.");
        }

        [TestCase("809.054.790-76")]
        [TestCase("448.704.530-45")]
        [TestCase("980.233.230-59")]
        [TestCase("198.998.010-46")]
        public void Deve_Validar_Cpf(string cpf)
        {
            var cpfObj = new Cpf(cpf);

            cpfObj.Numero.Should().BeEquivalentTo(cpf);
        }
    }
}