using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffer.Models
{
    public class Contract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        public string code { get; set; }

        public string name { get; set; }

        public DateTime? dateContract{ get; set; }

        public string payment { get; set; }

        [ForeignKey("depouilleId")]
        public int? depouilleId { get; set; }
        public Depouillement depouille { get; set; }

        public Contract()
        {

        }

        public Contract(string code, string name, DateTime date, string payment)
        {
            this.code = code;
            this.name = name;
            dateContract = date;
            this.payment = payment;
        }

        public Contract(int? id, string code, string name, DateTime? date, string payment)
        {
            Id = id;
            this.code = code;
            this.name = name;
            dateContract = date;
            this.payment = payment;
        }
    }
}
