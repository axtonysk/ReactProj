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
    public class ModuleController : ControllerBase
    {
        private readonly IDataRepository<Module> _dataRepository;
        public ModuleController(IDataRepository<Module> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/module
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_dataRepository.GetAll());
        }

        // GET: api/module/1
        [HttpGet("{id}", Name = "GetModule")]
        public ActionResult Get(int id)
        {
            Module module = _dataRepository.Get(id);
            if (module == null)
            {
                return NotFound("The Module record couldn't be found.");
            }
            return Ok(module);
        }

        // POST: api/module
        [HttpPost]
        public IActionResult Post([FromBody] Module module)
        {
            if (module == null)
            {
                return BadRequest("Module is null.");
            }
            _dataRepository.Add(module);
            return CreatedAtRoute(
                  "GetModule",
                  new { Id = module.id },
                  module);
        }

        // PUT: api/module/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Module module)
        {
            if (module == null)
            {
                return BadRequest("Module is null.");
            }
            Module moduleToUpdate = _dataRepository.Get(id);
            if (moduleToUpdate == null)
            {
                return NotFound("The Module record couldn't be found.");
            }
            _dataRepository.Update(moduleToUpdate, module);
            return NoContent();
        }

        // DELETE: api/module/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Module module = _dataRepository.Get(id);
            if (module == null)
            {
                return NotFound("The Module record couldn't be found.");
            }
            _dataRepository.Delete(module);
            return NoContent();
        }
    }
}
