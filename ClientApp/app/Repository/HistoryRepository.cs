using GestionOffer.Dto;
using GestionOffer.Models;
using GestionOffers.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffer.ClientApp.app.Repository
{
    public class HistoryRepository : BaseRepository<Offer>
    {
        public HistoryRepository() : base(Context.Create())
        {

        }


        public FetchOfferDto GetOffer(int offerId)
        {
            try
            {

                FetchOfferDto fetchOffer;
                BidderDto bidderDto;

                var offer = _context.Offer.Include("categorie").Include("direction").Include("commission").Where(o => o.id == offerId).FirstOrDefault();
                var plis = _context.Plis.Include("bidder").Include("depouillement").ToList();

                fetchOffer = new FetchOfferDto(offer.id, offer.code, offer.etat, offer.intitule, offer.description, offer.placeDepot, offer.dateLimit, offer.placeOpened, offer.dateOpened, offer.manager, offer.publish);

                fetchOffer.categorie.code = offer.categorie.code;
                fetchOffer.categorie.libelle = offer.categorie.libelle;
                fetchOffer.direction.code = offer.direction.code;
                fetchOffer.direction.libelle = offer.direction.libelle;
                fetchOffer.commission.code = offer.commission.code;
                fetchOffer.commission.libelle = offer.commission.libelle;

                foreach (Plis pli in plis)
                {
                    if (pli.depouillement.transCript == "Accepted" && pli.offerId == offerId)
                    {
                        bidderDto = new BidderDto(pli.bidder.Id, pli.bidder.firstName, pli.bidder.lastName, pli.bidder.email, pli.bidder.tel, pli.bidder.fax, pli.bidder.domaine, pli.bidder.typeEnterprise);
                        fetchOffer.bidders.Add(bidderDto);
                    }
                }

                return fetchOffer;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                throw;
            }
        }
    }
}

