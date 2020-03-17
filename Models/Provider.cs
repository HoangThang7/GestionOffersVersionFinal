using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffer.Models
{
    public class Provider
    {
        [ForeignKey("User")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ProviderId { get; set; }

        [Required]
        public string domaine { get; set; }

        [Required]
        public string fax { get; set; }

        [Required]
        public string typeEnterprise { get; set; }


        public Provider()
        {

        }

        public Provider(string domaine, string fax, string type)
        {

            this.domaine = domaine;
            this.fax = fax;
            typeEnterprise = type;
        }
    }
}
