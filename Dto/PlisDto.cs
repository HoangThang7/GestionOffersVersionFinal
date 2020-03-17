using System;
using GestionOffer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffer.Dto
{
    public class PlisDto
    {
        public int Id { get; set; }

        public string code { get; set; }

        public string libelle { get; set; }

        public DateTime dateDepot { get; set; }

        public string typeDepot { get; set; }

        public int offerId { get; set; }

        public int bidderId { get; set; }

        public Depouillement depouille { get; set; }

        public PlisDto()
        {

        }

        public PlisDto(int id,string code, string libelle, DateTime dateDepot, string typeDepot)
        {
            this.Id = id;
            this.code = code;
            this.libelle = libelle;
            this.dateDepot = dateDepot;
            this.typeDepot = typeDepot;
            depouille = new Depouillement();
        }
    }
}
