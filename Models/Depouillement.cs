using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffer.Models
{
    public class Depouillement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        public byte? noteFinance { get; set; }

        public byte? noteTechnical { get; set; }

        public string transCript { get; set; }
   
        public string comment { get; set; }

        public DateTime? dateDepouille { get; set; }

        [ForeignKey("plisId")]
        public int? plisId { get; set; }
        public Plis plis { get; set; }

        public virtual Contract contract { get; set;}

        public Depouillement()
        {

        }

        public Depouillement(int id, byte noteFinance, byte noteTechnical,string transcript, string comment, DateTime date)
        {
            this.Id = id;
            this.noteFinance = noteFinance;
            this.noteTechnical = noteTechnical;
            transCript = transcript;
            this.comment = comment;
            dateDepouille = date;
        }


        public Depouillement(int? id, byte? noteFinance, byte? noteTechnical, string transcript, string comment, DateTime? date)
        {
            this.Id = id;
            this.noteFinance = noteFinance;
            this.noteTechnical = noteTechnical;
            transCript = transcript;
            this.comment = comment;
            dateDepouille = date;
        }

    }
}
