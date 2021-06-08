using HumgNewsAPI.intermediary;
using HumgNewsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HumgNewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        public MyHumgNewsContext _context; 
        public NewsController (MyHumgNewsContext context)
        {
            _context = context; 
        }
        [HttpPost]
        public async Task<IActionResult> CreateNews([FromForm] List<IFormFile>fileDinhKem, [FromForm] string newsCline)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var tintuc = JsonConvert.DeserializeObject<TinTuc>(newsCline);
            //var tintuc = JsonConvert.DeserializeObject<TinTuc>(newsCline);
             var news = tintuc.SentNews;
            _context.News.Add(news);
            await _context.SaveChangesAsync();
            var listFile = new List<Attachment>();
            foreach (var x in fileDinhKem)
            {
                // Lấy tên file và kích thước
                var temp = new Attachment();
                temp.CreatedBy = "admin";
                temp.CreatedTime = DateTime.Now;
                temp.NewsId = news.NewsId;
                temp.FileName = x.FileName;
                temp.FileSize = (int?)x.Length;
                string[] DuoiFile = x.FileName.Split('.');
                if(DuoiFile[DuoiFile.Length -1] != "exe")
                {
                    // Lưu file 
                    listFile.Add(temp);
                    // thư Mục gốc
                    string startupPath = System.IO.Directory.GetCurrentDirectory();
                    var f = Path.Combine(startupPath, "UploadedFiles", temp.FileName);
                    using var fs = new FileStream(f, FileMode.Create);
                    x.CopyTo(fs); 
                }
            }

            _context.Attachments.AddRange(listFile);
            var NewRecipients = tintuc.ThongBao;
            foreach(var y in NewRecipients)
            {
                y.NewsId = news.NewsId;
            }
            _context.NewRecipients.AddRange(NewRecipients);
            return StatusCode(201, news);
        }
    }
}
