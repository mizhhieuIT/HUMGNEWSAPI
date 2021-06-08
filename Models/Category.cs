using System;
using System.Collections.Generic;

#nullable disable

namespace HumgNewsAPI.Models
{
    public partial class Category
    {
        public Category()
        {
            News = new HashSet<News>();
        }

        public int CategoryId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string ModifiedBy { get; set; }
        public string Status { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
