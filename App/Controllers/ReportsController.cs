using App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IAuthorizationService _authorizationService;

        public ReportsController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public async Task<IActionResult> Index(int documentId)
        {
            //Mocking getting a Document from a Database

            var document = new Document()
            {
                Id = 1,
                Title = "My Report",
                AuthorName = "Ervis"
            };

            // Checking Wether has access to this service
            var authorized = await _authorizationService.AuthorizeAsync(User, document, "EditPolicy");
            if (authorized.Succeeded) return View(document);
            return Forbid();
        }
    }
}