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
                new Item("Caneta", 1.50, 15, 3, 1, 0.01) { Id = Guid.Parse("55ab9ea8-7266-11ec-90d6-0242ac120003") },
                new Item("Bicicleta", 2000.0, 70, 150, 40, 2.5) { Id = Guid.Parse("80fbfab2-7266-11ec-90d6-0242ac120003") },
                new Item("Mouse", 50.50, 4, 6, 8, 0.02) { Id = Guid.Parse("89d5e378-7266-11ec-90d6-0242ac120003") },
                new Item("Geladeira", 3500.0, 200, 100, 50, 40) { Id = Guid.Parse("aaaab30d-43f7-4ba0-babd-fc4f21eacc9c") },
                new Item("Camera", 1240.0, 20, 15, 10, 1) { Id = Guid.Parse("888b12ef-40d9-41fb-bd7f-e9140e0f3f92") }
            };
        }

        public async Task<Item> ObterPorId(Guid itemId)
        {
            return await Task.FromResult(Itens.FirstOrDefault(item => item.Id == itemId));
        }
    }
}