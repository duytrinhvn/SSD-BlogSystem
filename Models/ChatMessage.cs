using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystem.Models
{
    public class ChatMessage
    {
        [Required]
        public string SenderName { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Text { get; set; }

        [DataType(DataType.DateTime)]
        public DateTimeOffset SentAt { get; set; }
    }
}
