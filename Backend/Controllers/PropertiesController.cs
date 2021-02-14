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
    public class PropertiesController : ControllerBase
    {
        private readonly IDataRepository<Properties> _dataRepository;
        public PropertiesController(IDataRepository<Properties> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/properties
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_dataRepository.GetAll());
        }

        // GET: api/properties/1
        [HttpGet("{id}", Name = "GetProperties")]
        public ActionResult Get(int id)
        {
            Properties properties = _dataRepository.Get(id);
            if (properties == null)
            {
                return NotFound("The Properties record couldn't be found.");
            }
            return Ok(properties);
        }

        // POST: api/properties
        [HttpPost]
        public IActionResult Post([FromBody] Properties properties)
        {
            if (properties == null)
            {
                return BadRequest("Properties is null.");
            }
            _dataRepository.Add(properties);
            return CreatedAtRoute(
                  "GetProperties",
                  new { Id = properties.id },
                  properties);
        }

        // PUT: api/properties/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Properties properties)
        {
            if (properties == null)
            {
                return BadRequest("Properties is null.");
            }
            Properties propertiesToUpdate = _dataRepository.Get(id);
            if (propertiesToUpdate == null)
            {
                return NotFound("The Properties record couldn't be found.");
            }
            _dataRepository.Update(propertiesToUpdate, properties);
            return NoContent();
        }

        // DELETE: api/properties/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Properties properties = _dataRepository.Get(id);
            if (properties == null)
            {
                return NotFound("The Properties record couldn't be found.");
            }
            _dataRepository.Delete(properties);
            return NoContent();
        }
    }
}
