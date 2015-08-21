using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class QuestionDisplay
    {
        public string QuestionEn { get; set; }
        public string QuestionHI { get; set; }
    
        public List<QuestionDetail> Options { get; set; }
    }
}