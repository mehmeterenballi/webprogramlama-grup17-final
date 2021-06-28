using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace VeritabaniProjesi.Models
{
    public class Post
    {
        [Key, NotNull] public int Id { get; set; }
        [MaxLength(40), MinLength(2), NotNull, Display(Name = "Başlık"), ForeignKey("Title")]public string PostTitle { get; set; }
        [MaxLength(20), MinLength(2), NotNull, ForeignKey("MyUser")]public string Sender { get; set; }
        public string PeopleWhoLikedString { get; set;}

        [NotMapped]
        public List<string> PeopleWhoLiked
        {
            get
            {
                if (string.IsNullOrEmpty(PeopleWhoLikedString))
                    return new List<string>();

                return PeopleWhoLikedString.Split(';').ToList();
            }
            set
            {
                PeopleWhoLikedString = "";
                foreach (string s in value)
                    PeopleWhoLikedString += s + ';';
                
            }
        }

        [NotNull, Display(Name = "İçerik")]public string Content { get; set; }
        public int Rating { get; set; }
        [DataType(DataType.DateTime)] public DateTime Date { get; set;}
    }
}
