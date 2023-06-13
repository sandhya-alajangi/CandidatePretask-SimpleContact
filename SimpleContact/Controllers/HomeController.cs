using Microsoft.AspNetCore.Mvc;
using SimpleContact.Models;
using SimpleContact.Services;
using System.Diagnostics;

namespace SimpleContact.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new EmailRequest { });
        }

        /// <summary>
        /// Post Action to send an email Notification
        /// </summary>
        /// <param name="emailRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index([Bind("Name,Email,Message")] EmailRequest emailRequest)
        {
            _emailService.SendContactEmail(emailRequest.Name, emailRequest.Email, emailRequest.Message);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
