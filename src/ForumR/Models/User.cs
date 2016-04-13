using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using CodeComb.AspNet.Upload.Models;
using Newtonsoft.Json;

namespace ForumR.Models
{
    public class User : IdentityUser<long>
    {
        public DateTime RegisteryTime { get; set; }

        [ForeignKey("Avatar")]
        public Guid AvatarId { get; set; }

        public virtual File Avatar { get; set; }

        [MaxLength(512)]
        public string Motto { get; set; }
    }
}
