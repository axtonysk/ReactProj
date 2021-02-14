using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayoutWebAPi.Data;
using LayoutWebAPi.Models;
using LayoutWebAPi.Models.Repository;

namespace LayoutWebAPi.Models.DataManager
{
    public class PropertiesManager : IDataRepository<Properties>
    {
        private DataContext _context = null;
        public PropertiesManager(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Properties> GetAll()
        {
            return _context.properties.ToList();
        }
        public Properties Get(long id)
        {
            return _context.properties
                  .FirstOrDefault(e => e.id == id);
        }
        public void Add(Properties entity)
        {
            _context.properties.Add(entity);
            _context.SaveChanges();
        }
        public void Update(Properties properties, Properties entity)
        {
            properties.id = entity.id;
            properties.name = entity.name;
            properties.width = entity.width;
            properties.height = entity.height;
            properties.x_axis = entity.x_axis;
            properties.y_axis = entity.y_axis;
            properties.max_width = entity.max_width;
            properties.max_height = entity.max_height;
            properties.min_width = entity.min_width;
            properties.min_height = entity.min_height;

            _context.SaveChanges();
        }
        public void Delete(Properties properties)
        {
            _context.properties.Remove(properties);
            _context.SaveChanges();
        }
    }
}
