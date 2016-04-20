using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumR.Models
{
    public class Message
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public DateTime Time { get; set; }

        [ForeignKey("Sender")]
        public long SenderId { get; set; }

        public virtual User Sender { get; set; }

        [ForeignKey("Receiver")]
        public long ReceiverId { get; set; }

        public virtual User Receiver { get; set; }
    }
}
