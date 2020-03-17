using GestionOffers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffer.ClientApp.app.Repository
{
    public class AddressRepository : BaseRepository<Address>
    {
        public AddressRepository(): base(Context.Create())
        {

        }
    }
}
