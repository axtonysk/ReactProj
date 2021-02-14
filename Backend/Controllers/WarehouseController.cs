using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayoutWebAPi.Data;
using LayoutWebAPi.Models;
using LayoutWebAPi.Models.Repository;
using LayoutWebAPi.Models.DataManager;

namespace LayoutWebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IDataRepository<Warehouse> _dataRepository;
        public WarehouseController(IDataRepository<Warehouse> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/warehouse
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_dataRepository.GetAll());
        }

        // GET: api/warehouse/1
        [HttpGet("{id}", Name = "GetWarehouse")]
        public ActionResult Get(int id)
        {
            Warehouse warehouse = _dataRepository.Get(id);
            if (warehouse == null)
            {
                return NotFound("The Warehouse record couldn't be found.");
            }
            return Ok(warehouse);
        }

        // POST: api/warehouse
        [HttpPost]
        public IActionResult Post([FromBody] Warehouse warehouse)
        {
            if (warehouse == null)
            {
                return BadRequest("Warehouse is null.");
            }
            _dataRepository.Add(warehouse);
            return CreatedAtRoute(
                  "GetWarehouse",
                  new { Id = warehouse.id },
                  warehouse);
        }

        // PUT: api/warehouse/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Warehouse warehouse)
        {
            if (warehouse == null)
            {
                return BadRequest("Warehouse is null.");
            }
            Warehouse warehouseToUpdate = _dataRepository.Get(id);
            if (warehouseToUpdate == null)
            {
                return NotFound("The Warehouse record couldn't be found.");
            }
            _dataRepository.Update(warehouseToUpdate, warehouse);
            return NoContent();
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Warehouse warehouse = _dataRepository.Get(id);
            if (warehouse == null)
            {
                return NotFound("The Warehouse record couldn't be found.");
            }
            _dataRepository.Delete(warehouse);
            return NoContent();
        }
    }
}
