using CCCA.Dominio.Entidades;
using CCCA.Dominio.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCCA.Infra.Memoria
{
    public class PedidoRepositoryMemory : IPedidoRepository
    {
        public List<Pedido> Pedidos { get; set; }

        public PedidoRepositoryMemory()
        {
            Pedidos = new List<Pedido>();
        }

        public async Task Salvar(Pedido pedido)
        {
            Pedidos.Add(pedido);
            await Task.CompletedTask;
        }

        public int ObterUltimoCodigoSequencia()
        {
             return Pedidos.Count();
        }
    }
}