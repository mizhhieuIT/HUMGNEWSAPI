using System;
using System.Collections.Generic;

#nullable disable

namespace HumgNewsAPI.Models
{
    public partial class Attachment
    {
        public int AttachmentId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string ModifiedBy { get; set; }
        public string Status { get; set; }
        public string DisplayName { get; set; }
        public string FileName { get; set; }
        public int? FileSize { get; set; }
        public DateTime? ExpiredTime { get; set; }
        public int? NewsId { get; set; }

        public virtual News News { get; set; }
    }
}
