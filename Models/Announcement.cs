using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VeritabaniProjesi.Models
{
    public class Announcement
    {
        [Key, NotNull, MaxLength(40), Required]
        public string Title { get; set; }
        public string Content { get; set; }
        [Display(Name = "Linkler(\";\" sembolu ile ayirin.)")]public string SourceListString { get; set; }

        [NotMapped]
        public List<string> SourceList
        {
            get
            {
                if (SourceListString == null)
                    return new List<string>();

                return SourceListString.Split(';').ToList();
            }

            set
            {
                SourceListString = "";
                foreach (string s in value)
                    SourceListString += s + ';';
                
            }
        }

        [DataType(DataType.DateTime)] public DateTime Date { get; set; }
    }
}
