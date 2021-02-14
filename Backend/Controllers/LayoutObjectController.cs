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
    public class LayoutObjectController : ControllerBase
    {
        private readonly IDataRepository<LayoutObject> _dataRepository;
        public LayoutObjectController(IDataRepository<LayoutObject> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/layoutobject
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_dataRepository.GetAll());
        }

        // GET: api/layoutobject/1
        [HttpGet("{id}", Name = "GetLayoutObject")]
        public ActionResult Get(int id)
        {
            LayoutObject layoutObject = _dataRepository.Get(id);
            if (layoutObject == null)
            {
                return NotFound("The LayoutObject record couldn't be found.");
            }
            return Ok(layoutObject);
        }

        // POST: api/layoutobject
        [HttpPost]
        public IActionResult Post([FromBody] LayoutObject layoutObject)
        {
            if (layoutObject == null)
            {
                return BadRequest("LayoutObject is null.");
            }
            _dataRepository.Add(layoutObject);
            return CreatedAtRoute(
                  "GetLayoutObject",
                  new { Id = layoutObject.id },
                  layoutObject);
        }

        // PUT: api/layoutobject/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LayoutObject layoutObject)
        {
            if (layoutObject == null)
            {
                return BadRequest("LayoutObject is null.");
            }
            LayoutObject layoutObjectToUpdate = _dataRepository.Get(id);
            if (layoutObjectToUpdate == null)
            {
                return NotFound("The LayoutObject record couldn't be found.");
            }
            _dataRepository.Update(layoutObjectToUpdate, layoutObject);
            return NoContent();
        }

        // DELETE: api/layoutobject/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            LayoutObject layoutObject = _dataRepository.Get(id);
            if (layoutObject == null)
            {
                return NotFound("The LayoutObject record couldn't be found.");
            }
            _dataRepository.Delete(layoutObject);
            return NoContent();
        }
    }
}
