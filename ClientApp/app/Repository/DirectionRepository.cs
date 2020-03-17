using GestionOffer.Models;
using GestionOffers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffer.ClientApp.app.Repository
{
    public class DirectionRepository: BaseRepository<Direction>
    {
        public DirectionRepository(): base(Context.Create())
        {

        }

        
    
    }
}
