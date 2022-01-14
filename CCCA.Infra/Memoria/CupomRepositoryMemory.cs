using CCCA.Dominio.Entidades;
using CCCA.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCCA.Infra.Memoria
{
    public class CupomRepositoryMemory : ICupomRepository
    {
        public List<Cupom> Cupons { get; set; }

        public CupomRepositoryMemory()
        {
            Cupons = new List<Cupom>
            {
                new Cupom("40off", DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1)),
                new Cupom("vale20", DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-5)),
            };
        }

        public async Task<Cupom> ObterPorDescricao(string descricaoCupom)
        {
            return await Task.FromResult(Cupons.FirstOrDefault(cupom => cupom.Descricao == descricaoCupom));
        }
    }
}