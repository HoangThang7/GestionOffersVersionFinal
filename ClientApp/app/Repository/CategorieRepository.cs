using GestionOffer.Models;
using GestionOffers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffer.ClientApp.app.Repository
{
    public class CategorieRepository: BaseRepository<Categorie>
    {
        public CategorieRepository(): base(Context.Create())
        {

        }
        

    }
}
