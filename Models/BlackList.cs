using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace VeritabaniProjesi.Models
{
    public class BlackList
    {
        [Key, NotNull]public int Id { get; set; }
        [NotNull, ForeignKey("Post")]public int PostId { get; set; }
        [MaxLength(20), MinLength(2), NotNull, ForeignKey("MyUser")]public string Sender{ get; set; }
        [DataType(DataType.DateTime)] public DateTime StartDate { get; set;}
        [DataType(DataType.DateTime)] public DateTime EndDate { get; set;}
    }
}
