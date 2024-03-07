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
        private const string MySecretKey = "salainenavain"; // Kovakoodattu avainkoodi

        public DocumentationsController(NorthwindOriginalContext context)
        {
            _context = context;
        }

        // GET: api/Documentations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Documentation>> GetDocumentation(int id, string keycode)
        {
            if (keycode != MySecretKey)
            {
                return NotFound("Documentation missing"); // Avainkoodi väärä, palauta "Documentation missing" -viesti
            }

            var documentation = await _context.Documentation.FindAsync(id);

            if (documentation == null)
            {
                return NotFound(); // Dokumentaatiota ei löytynyt
            }

            return documentation;
        }
    }
}