using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayoutWebAPi.Data;
using LayoutWebAPi.Models;
using LayoutWebAPi.Models.Repository;

namespace LayoutWebAPi.Models.DataManager
{
    public class LayoutObjectManager : IDataRepository<LayoutObject>
    {
        private DataContext _context = null;
        public LayoutObjectManager(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<LayoutObject> GetAll()
        {
            return _context.layout_objects.ToList();
        }
        public LayoutObject Get(long id)
        {
            return _context.layout_objects
                  .FirstOrDefault(e => e.id == id);
        }
        public void Add(LayoutObject entity)
        {
            _context.layout_objects.Add(entity);
            _context.SaveChanges();
        }
        public void Update(LayoutObject layoutObject, LayoutObject entity)
        {
            layoutObject.id = entity.id;
            layoutObject.type = entity.type;
            layoutObject.is_rack = entity.is_rack;
            layoutObject.is_active = entity.is_active;

            _context.SaveChanges();
        }
        public void Delete(LayoutObject layoutObject)
        {
            _context.layout_objects.Remove(layoutObject);
            _context.SaveChanges();
        }
    }
}
