using System.Web.Mvc;
using WebUI.MvcProjectService;

namespace WebUI.Controllers
{
    public class BaseController : Controller
    {
        private WcfServiceClient _projectService;
        public WcfServiceClient ProjectService
        {
            get
            {
                if (_projectService is null)
                {
                    _projectService = new WcfServiceClient();
                }
                return _projectService;
            }
        }
    }
}