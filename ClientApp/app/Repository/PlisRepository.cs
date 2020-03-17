using GestionOffer.Models;
using GestionOffers.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GestionOffer.Dto;

namespace GestionOffer.ClientApp.app.Repository
{
    public class PlisRepository: BaseRepository<Plis>
    {
        public PlisRepository() : base(Context.Create())
        {

        }

        public int PostPlis(PlisDto plis)
        {
            try
            {
                Plis newPlis = new Plis(plis.code, plis.libelle, plis.dateDepot, plis.typeDepot);

                var bidder = _context.Bidder.Include("plis").Where(b => b.Id == plis.bidderId).FirstOrDefault();
                Console.WriteLine(bidder);

                var offer = _context.Offer.Include("plis").Where(o => o.id == plis.offerId).FirstOrDefault();
                Console.WriteLine(offer);

                bidder.plis.Add(newPlis);
                offer.plis.Add(newPlis);

                _context.SaveChanges();

                int newId = _context.Plis.Where(p => p.code == newPlis.code).FirstOrDefault().Id;
                return newId;

            } catch (Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                throw;
            }

        }

        public bool updatePlis(int id, PlisDto plisDto)
        {
            try
            {
                var plis = _context.Plis.Find(id);

                plis.code = plisDto.code;
                plis.libelle = plisDto.libelle;
                plis.dateDepot = plisDto.dateDepot;
                plis.typeDepot = plisDto.typeDepot;

                _context.SaveChanges();

                var plisModif = _context.Plis.Find(id);

                return true;
            } catch(Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                throw;
            }
        }

        public PlisDto getPlis(int id)
        {
            try
            {
                var plis = _context.Plis.Find(id);
                PlisDto plisDto = new PlisDto(plis.Id, plis.code, plis.libelle, plis.dateDepot, plis.typeDepot);

                return plisDto;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                throw;
            }
        }
    }
}
