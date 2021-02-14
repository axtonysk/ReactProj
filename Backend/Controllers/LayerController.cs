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
    public class LayerController : ControllerBase
    {
        private readonly IDataRepository<Layer> _dataRepository;
        public LayerController(IDataRepository<Layer> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/layer
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_dataRepository.GetAll());
        }

        // GET: api/layer/1
        [HttpGet("{id}", Name = "GetLayer")]
        public ActionResult Get(int id)
        {
            Layer layer = _dataRepository.Get(id);
            if (layer == null)
            {
                return NotFound("The Layer record couldn't be found.");
            }
            return Ok(layer);
        }

        // POST: api/layer
        [HttpPost]
        public IActionResult Post([FromBody] Layer layer)
        {
            if (layer == null)
            {
                return BadRequest("Layer is null.");
            }
            _dataRepository.Add(layer);
            return CreatedAtRoute(
                  "GetLayer",
                  new { Id = layer.id },
                  layer);
        }

        // PUT: api/layer/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Layer layer)
        {
            if (layer == null)
            {
                return BadRequest("Layer is null.");
            }
            Layer layerToUpdate = _dataRepository.Get(id);
            if (layerToUpdate == null)
            {
                return NotFound("The Layer record couldn't be found.");
            }
            _dataRepository.Update(layerToUpdate, layer);
            return NoContent();
        }

        // DELETE: api/layer/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Layer layer = _dataRepository.Get(id);
            if (layer == null)
            {
                return NotFound("The Layer record couldn't be found.");
            }
            _dataRepository.Delete(layer);
            return NoContent();
        }
    }
}
