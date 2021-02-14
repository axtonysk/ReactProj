using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayoutWebAPi.Data;
using LayoutWebAPi.Models;
using LayoutWebAPi.Models.Repository;

namespace LayoutWebAPi.Models.DataManager
{
    public class WarehouseManager : IDataRepository<Warehouse>
    {
        private DataContext _context = null;
        public WarehouseManager(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Warehouse> GetAll()
        {
            return _context.warehouses.ToList();
        }
        public Warehouse Get(long id)
        {
            return _context.warehouses
                  .FirstOrDefault(e => e.id == id);
        }

        public void Add(Warehouse entity)
        {
            _context.warehouses.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Warehouse warehouse, Warehouse entity)
        {
            warehouse.id = entity.id;
            warehouse.name = entity.name;
            warehouse.address = entity.address;
            warehouse.display_value = entity.display_value;
            warehouse.is_active = entity.is_active;
            warehouse.is_available = entity.is_available;

            _context.SaveChanges();
        }

        public void Delete(Warehouse warehouse)
        {
            _context.warehouses.Remove(warehouse);
            _context.SaveChanges();
        }
    }
}
