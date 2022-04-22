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
            var loginPrompt = GetRandomLoginPrompt();
            return WrapResult(loginPrompt);
        }

        [HttpGet("next/{userId}")]
        public IActionResult GetNextForUser(long userId)
        {
            // TODO: 2: Implement this.

            var user = _context.Users.SingleOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return NotFound();
            }

            LoginPrompt loginPrompt = null;

            var currentTime = DateTime.Now;
            var prompts = _context.LoginPrompts.SelectMany
                (
                    prompt => _context.LoginPropmtViews.Where(view => prompt.Id == view.LoginPromptId && view.UserId == user.Id).DefaultIfEmpty(),
                    (prompt, view) =>
                    new
                    {
                        Id = prompt.Id
                        ,
                        Prompt = prompt
                        ,
                        View = view == null ? new LoginPromptView { LoginPromptId = prompt.Id, UserId = user.Id, TimeStamp = DateTime.Now }
                                : view
                        ,
                        ElapstedTime = view == null ? TimeSpan.FromSeconds(0) : (currentTime - view.TimeStamp)
                    }
                ).OrderBy(x => Guid.NewGuid()).ToList();



            foreach (var item in prompts)
            {
                if (loginPrompt == null && (item.Prompt.QuietPeriod == 0 || item.View.Id == 0 || item.ElapstedTime.TotalSeconds >= item.Prompt.QuietPeriod))
                {
                    loginPrompt = item.Prompt;
                    //try

                    if (item.View.Id == 0)
                    {
                        _context.Add(item.View);
                    }
                    else
                    {
                        item.View.TimeStamp = DateTime.Now;
                        _context.Update(item.View);
                    }

                    _context.SaveChanges();

                    break;
                }
            }

            return WrapResult(loginPrompt);
        }

        private IActionResult WrapResult(LoginPrompt p)
        {
            if (p == null)
            {
                return NotFound();
            }

            return new ObjectResult(p);
        }

        private LoginPrompt GetRandomLoginPrompt()
        {
            return _context.LoginPrompts.ToList().OrderBy(x => Guid.NewGuid()).FirstOrDefault();
        }        
    }
}