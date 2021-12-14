using CCCA.Dominio.Entidades;
using System;
using System.Threading.Tasks;

namespace CCCA.Dominio.Interfaces
{
    public interface IItemRepository
    {
        Task<Item> ObterPorId(Guid itemId);
    }
}
