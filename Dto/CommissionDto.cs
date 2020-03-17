using GestionOffers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffer.Dto
{
    public class CommissionDto
    {
        public CommissionDto() { }

        public int Id { get; set; }
        public string code { get; set; }
        public string libelle { get; set; }
        public ICollection<User> members { get; set; }

        public CommissionDto(int id, string code, string libelle)
        {
            this.Id = id;
            this.code = code;
            this.libelle = libelle;
            this.members = new List<User>();
        }
    }
}
