using Microsoft.AspNetCore.Antiforgery;
using SimpleCMS.Controllers;

namespace SimpleCMS.Web.Host.Controllers
{
    public class AntiForgeryController : SimpleCMSControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
