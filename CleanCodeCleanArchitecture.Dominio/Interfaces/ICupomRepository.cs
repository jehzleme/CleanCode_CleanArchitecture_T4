using CCCA.Dominio.Entidades;
using System.Threading.Tasks;

namespace CCCA.Dominio.Interfaces
{
    public interface ICupomRepository
    {
        Task<Cupom> ObterPorDescricao(string descricaoCupom);
    }
}
