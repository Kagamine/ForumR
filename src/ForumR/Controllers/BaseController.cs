using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.SignalR;
using CodeComb.Net.EmailSender;
using CodeComb.Security.Aes;
using ForumR.Models;
using ForumR.Hubs;

namespace ForumR.Controllers
{
    public class BaseController : BaseController<ForumContext, User, long>
    {
        public override void Prepare()
        {
            base.Prepare();
            ViewBag.Announcements = DB.Threads
                .Where(x => x.IsAnnouncement)
                .OrderByDescending(x => x.CreationTime)
                .Take(5)
                .ToList();
        }

        [FromServices]
        public IHubContext<ForumHub> ForumHub { get; set; }

        [FromServices]
        public IEmailSender Mail { get; set; }

        [FromServices]
        public AesCrypto Aes { get; set; }
    }
}
