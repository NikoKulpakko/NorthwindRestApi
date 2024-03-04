using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthwindRestApi.Models;

namespace NorthwindRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentationsController : ControllerBase
    {
        private readonly NorthwindOriginalContext _context;

        public DocumentationsController(NorthwindOriginalContext context)
        {
            _context = context;
        }

        // GET: api/Documentations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Documentation>> GetDocumentation(int id)
        {
          if (_context.Documentation == null)
          {
              return NotFound();
          }
            var documentation = await _context.Documentation.FindAsync(id);

            if (documentation == null)
            {
                return NotFound();
            }

            return documentation;
        }

    }
}
