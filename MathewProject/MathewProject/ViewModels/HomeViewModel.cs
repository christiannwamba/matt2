using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MathewProject.Models;

namespace MathewProject.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Cathedral> HomeCath { get; set; }
        public IEnumerable<Info> HomeNews { get; set; }
        public IEnumerable<Info> HomeAnnouncement { get; set; }
        public IEnumerable<Info> HomeEvent { get; set; }
        
    }
}