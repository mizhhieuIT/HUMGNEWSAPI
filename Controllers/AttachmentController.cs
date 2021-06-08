using HumgNewsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumgNewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        private readonly MyHumgNewsContext _context; 
        public AttachmentController(MyHumgNewsContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Attachment>> GetAll()
        {
            return await _context.Attachments.ToListAsync();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAttachment(Attachment tepdinhkem)
        {
            _context.Attachments.Add(tepdinhkem);
            await _context.SaveChangesAsync();
            return StatusCode(200, tepdinhkem);
        }
    }
}
