using CCCA.Dominio.Entidades;
using CCCA.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCCA.Infra.Memoria
{
    public class ItemRepositoryMemory : IItemRepository
    {
        public List<Item> Itens { get; set; }

        public ItemRepositoryMemory()
        {
            Itens = new List<Item>
            {
                new Item("Caneta", 1.50, 15, 3, 1, 0.01) { Id = Guid.Parse("55ab9ea8-7266-11ec-90d6-0242ac120003")},
                new Item("Bicicleta", 2000.0, 70, 150, 40, 2.5) { Id = Guid.Parse("80fbfab2-7266-11ec-90d6-0242ac120003")},
                new Item("Mouse", 50.50, 4, 6, 8, 0.02) { Id = Guid.Parse("89d5e378-7266-11ec-90d6-0242ac120003")}
            };
        }

        public async Task<Item> ObterPorId(Guid itemId)
        {
            return await Task.FromResult(Itens.FirstOrDefault(item => item.Id == itemId));
        }
    }
}