using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.SignalR;
using ForumR.Models;
using ForumR.Hubs;

namespace ForumR.Controllers
{
    public class BaseController : BaseController<ForumContext, User, long>
    {
        [FromServices]
        public IHubContext<ForumHub> ForumHub { get; set; }
    }
}
