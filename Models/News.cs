using System;
using System.Collections.Generic;

#nullable disable

namespace HumgNewsAPI.Models
{
    public partial class News
    {
        public News()
        {
            Attachments = new HashSet<Attachment>();
            NewRecipients = new HashSet<NewRecipient>();
        }

        public int NewsId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string CreateBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string ModifiedBy { get; set; }
        public string Status { get; set; }
        public int? CategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public string PublishedBy { get; set; }
        public DateTime? ExpiredTime { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<NewRecipient> NewRecipients { get; set; }
    }
}
