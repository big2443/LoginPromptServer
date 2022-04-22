using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LoginPromptServer.Models;

namespace LoginPromptServer.Controllers
{
    [Route("api/loginprompt")]
    public class LoginPromptApiController : Controller
    {
        private readonly LoginPromptContext _context;

        public LoginPromptApiController(LoginPromptContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<LoginPrompt> GetAll()
        {
            return _context.LoginPrompts.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            return WrapResult(_context.LoginPrompts.FirstOrDefault(p => p.Id == id));
        }

        [HttpGet("next")]
        public IActionResult GetNext()
        {
            // TODO: 1: Implement this.
            return WrapResult(null);
        }

        [HttpGet("next/{userId}")]
        public IActionResult GetNextForUser(long userId)
        {
            // TODO: 2: Implement this.
            return WrapResult(null);
        }

        private IActionResult WrapResult(LoginPrompt p)
        {
            if (p == null)
            {
                return NotFound();
            }

            return new ObjectResult(p);
        }
    }
}