using GestionOffers.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffer.Dto
{
    public class MailDto
    {
        public string author { get; set; }

        public ICollection<string> destinations { get; set; }

        public Offer offer { get; set; }

        public string password { get; set; }

        public ICollection<string> documents { get; set; }

       public MailDto()
        {

        }
    }
}
