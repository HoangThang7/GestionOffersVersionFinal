using GestionOffers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffer.Models
{
    public class Member
    {


        public int userId { get; set; }

        public User user { get; set; }

        public int commissionId { get; set; }

        public Commission commission { get; set; }

        public Member()
        {

        }

        public Member(Commission commis, User user)
        {
            commission = commis;
            this.user = user;
        }
    }
}
