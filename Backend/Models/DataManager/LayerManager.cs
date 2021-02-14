using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayoutWebAPi.Data;
using LayoutWebAPi.Models;
using LayoutWebAPi.Models.Repository;

namespace LayoutWebAPi.Models.DataManager
{
    public class LayerManager : IDataRepository<Layer>
    {
        private DataContext _context = null;
        public LayerManager(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Layer> GetAll()
        {
            return _context.layers.ToList();
        }
        public Layer Get(long id)
        {
            return _context.layers
                  .FirstOrDefault(e => e.id == id);
        }
        public void Add(Layer entity)
        {
            _context.layers.Add(entity);
            _context.SaveChanges();
        }
        public void Update(Layer layer, Layer entity)
        {
            layer.id = entity.id;
            layer.layer_level_no = entity.layer_level_no;
            layer.is_active = entity.is_active;
            layer.is_available = entity.is_available;

            _context.SaveChanges();
        }
        public void Delete(Layer layer)
        {
            _context.layers.Remove(layer);
            _context.SaveChanges();
        }
    }
}
