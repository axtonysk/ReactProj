using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayoutWebAPi.Data;
using LayoutWebAPi.Models;
using LayoutWebAPi.Models.Repository;

namespace LayoutWebAPi.Models.DataManager
{
    public class ModuleManager : IDataRepository<Module>
    {
        private DataContext _context = null;
        public ModuleManager(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Module> GetAll()
        {
            return _context.modules.ToList();
        }
        public Module Get(long id)
        {
            return _context.modules
                  .FirstOrDefault(e => e.id == id);
        }
        public void Add(Module entity)
        {
            _context.modules.Add(entity);
            _context.SaveChanges();
        }
        public void Update(Module module, Module entity)
        {
            module.id = entity.id;
            module.name = entity.name;
            module.layout_name = entity.layout_name;
            module.width = entity.width;
            module.length = entity.length;
            module.is_active = entity.is_active;
            module.is_available = entity.is_available;

            _context.SaveChanges();
        }
        public void Delete(Module module)
        {
            _context.modules.Remove(module);
            _context.SaveChanges();
        }
    }
}
