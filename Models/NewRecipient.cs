using System;
using System.Collections.Generic;

#nullable disable

namespace HumgNewsAPI.Models
{
    public partial class NewRecipient
    {
        public int Id { get; set; }
        public DateTime? ReceivedTime { get; set; }
        public DateTime? ReadTime { get; set; }
        public string Status { get; set; }
        public int? NewsId { get; set; }
        public string RecipientCode { get; set; }
        public string RecipientType { get; set; }
        public string SelectedGroupCode { get; set; }
        public string SelectedGroupType { get; set; }
        public string ImportantLevel { get; set; }
        public string MarkedAs { get; set; }

        public virtual News News { get; set; }
    }
}
