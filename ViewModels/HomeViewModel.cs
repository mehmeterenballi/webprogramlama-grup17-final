using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeritabaniProjesi.Models;

namespace VeritabaniProjesi.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Announcement> Announcement { get; set; }
    }
}
