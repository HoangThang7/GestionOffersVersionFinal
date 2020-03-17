using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffer.Dto
{
    public class OfferDto
    { 
        public string code { get; set; }
        public string categorieId { get; set; }
        public string codeCateg { get; set; }
        public string categorie { get; set; }
        public string directionId { get; set; }
        public string codeDirect { get; set; }
        public string direction { get; set; }
        public string commissionId { get; set; }
        public string codeCommis { get; set; }
        public string commission { get; set; }
        public string etat { get; set; }
        public string intitule { get; set; }
        public string description { get; set; }
        public string placeDepot { get; set; }
        public string dateLimit { get; set; }
        public string placeOpened { get; set; }
        public string dateOpened { get; set; }
        public string manager { get; set; }

        public OfferDto()
        {

        }
    }
}
