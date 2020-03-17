using GestionOffer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffer.Dto
{
    public class DepouillementDto
    {
        public int id { get; set; }

        public byte noteFinance { get; set; }

        public byte noteTechnical { get; set; }

        public string transCript { get; set; }

        public string comment { get; set; }

        public DateTime dateDepouille { get; set; }

        public int plisId { get; set; }

        public Contract contract { get; set; }

        public DepouillementDto() { }

        public DepouillementDto(int id, byte noteFinance, byte noteTechnic, string transcript, string comment, DateTime dateDepouille)
        {
            this.id = id;
            this.noteFinance = noteFinance;
            this.noteTechnical = noteTechnical;
            this.transCript = transCript;
            this.comment = comment;
            this.dateDepouille = dateDepouille;
        }

    }
}
