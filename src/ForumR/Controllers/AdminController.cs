using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Mvc;
using ForumR.Models;

namespace ForumR.Controllers
{
    public class AdminController : BaseController
    {
        [AnyRoles("Root")]
        public IActionResult Forum()
        {
            var ret = DB.Forums
                .Include(x => x.SubForums)
                .Where(x => x.ParentId == null)
                .OrderBy(x => x.PRI)
                .ToList();
            return View(ret);
        }

        [HttpGet]
        [AnyRoles("Root")]
        public IActionResult EditForum(string id)
        {
            return View(DB.Forums.Single(x => x.Id == id));
        }

        [HttpPost]
        [AnyRoles("Root")]
        [ValidateAntiForgeryToken]
        public IActionResult EditForum(string id, int pri, string title)
        {
            var forum = DB.Forums.Single(x => x.Id == id);
            forum.Title = title;
            forum.PRI = pri;
            DB.SaveChanges();
            return Prompt(x =>
            {
                x.Title = "修改成功";
                x.Details = "论坛板块信息保存成功！";
                x.RedirectText = "返回论坛管理";
                x.RedirectUrl = Url.Action("Forum", "Admin");
            });
        }

        [HttpGet]
        [AnyRoles("Root")]
        public IActionResult CreateForum()
        {
            return View();
        }

        [HttpPost]
        [AnyRoles("Root")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateForum(string parentid, string title, int pri)
        {
            var forum = new Forum { ParentId = parentid, Title = title, PRI = pri };
            DB.Forums.Add(forum);
            DB.SaveChanges();
            return Prompt(x =>
            {
                x.Title = "创建成功";
                x.Details = "新的论坛版块已经创建成功";
                x.RedirectText = "返回论坛版块管理";
                x.RedirectUrl = Url.Action("Forum", "Admin");
            });
        }
    }
}
