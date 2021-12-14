using CCCA.Dominio.Entidades;
using System.Threading.Tasks;

namespace CCCA.Dominio.Interfaces
{
    public interface IPedidoRepository
    {
        Task Salvar(Pedido pedido);
    }
}
