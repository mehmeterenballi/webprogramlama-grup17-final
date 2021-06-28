using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace VeritabaniProjesi.Models
{
    public class Title
    {
        [Key, StringLength(maximumLength:20, ErrorMessage = "Baslik Uzunlugunu Astiniz"), NotNull, DisplayName("Title")]
        [Display(Name = "Başlık Adı")]public string PostTitle { get; set; }
        [NotNull]public Post Question { get; set; }
        [ForeignKey("Post"), NotNull] public int QuestionId { get; set; }
        [DataType(DataType.DateTime), NotNull] public DateTime Date { get; set;}

    }
}
