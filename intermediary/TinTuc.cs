using HumgNewsAPI.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumgNewsAPI.intermediary
{
    public class TinTuc
    {
        public News SentNews { get; set; }
        //public IEnumerable<IFormFile> TepTin { get; set; }
        public List<NewRecipient> ThongBao { get; set; }
    }
}
