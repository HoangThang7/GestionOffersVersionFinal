
using GestionOffer.Dto;
using GestionOffer.Models;
using GestionOffers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;

namespace GestionOffer.ClientApp.app.Repository
{
    public class OfferRepository : BaseRepository<Offer>
    {
        public OfferRepository() : base(Context.Create())
        {

        }

        public bool AddOffer(Offer offer)
        {
            try
            {
                var a = _context.Categorie.Include("Offers").Where(ca => ca.Id == offer.categorie.Id).FirstOrDefault();
                a.Offers.Add(offer);
                var b = _context.Direction.Include("DirectOffers").Where(d => d.Id == offer.direction.Id).FirstOrDefault();
                b.DirectOffers.Add(offer);
                var c = _context.Commission.Include("offers").Where(co => co.Id == offer.commission.Id).FirstOrDefault();
                c.offers.Add(offer);

                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                throw;
            }
        }



        public IEnumerable<FetchOfferDto> GetListOffer()
        {
            List<Offer> listOffers = new List<Offer>();
            List<FetchOfferDto> listFetchOffers = new List<FetchOfferDto>();
            FetchOfferDto fetchOffer;
            Categorie categorie = new Categorie();
            Direction direction = new Direction();
            Commission commission = new Commission();

            listOffers = _context.Offer.Include("documents").ToList();

            foreach (Offer offer in listOffers)
            {
                categorie = _context.Categorie.Find(offer.categorieId);
                direction = _context.Direction.Find(offer.directionId);
                commission = _context.Commission.Find(offer.commissionId);

                fetchOffer = new FetchOfferDto(offer.id, offer.code, offer.etat, offer.intitule, offer.description, offer.placeDepot, offer.dateLimit, offer.placeOpened, offer.dateOpened, offer.manager, offer.publish);
                fetchOffer.categorie.Id = categorie.Id;
                fetchOffer.categorie.code = categorie.code;
                fetchOffer.categorie.libelle = categorie.libelle;
                fetchOffer.direction.Id = direction.Id;
                fetchOffer.direction.code = direction.code;
                fetchOffer.direction.libelle = direction.libelle;
                fetchOffer.commission.Id = commission.Id;
                fetchOffer.commission.code = commission.code;
                fetchOffer.commission.libelle = commission.libelle;
                foreach (Member member in commission.memberCommis) {
                    fetchOffer.commission.memberCommis.Add(member);
                        }               
             
                listFetchOffers.Add(fetchOffer);
            }

            return listFetchOffers;
        }

        public bool DeleteOffer(int id)
        {
            try
            {
                var a = _context.Offer.Include("documents").Where(o => o.id == id).FirstOrDefault();

                _context.Offer.Remove(a);

                _context.SaveChanges();

                return true;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                throw;
            }
        }

        public FetchOfferDto UpdateOffer(Offer offer)
        {
            try
            {
                var entity = _context.Offer.Include("categorie").Include("direction").Include("commission").Where(o => o.id == offer.id).FirstOrDefault();

                entity.code = offer.code;
                entity.intitule = offer.intitule;
                entity.etat = offer.etat;
                entity.description = offer.description;
                entity.dateOpened = offer.dateOpened;
                entity.dateLimit = offer.dateLimit;
                entity.placeOpened = offer.placeOpened;
                entity.placeDepot = offer.placeDepot;
                entity.publish = offer.publish;

                var categorie = _context.Categorie.Find(offer.categorie.Id);
                if (!entity.categorie.Equals(categorie))
                {               
                    entity.categorie = offer.categorie;
                }

                var direction = _context.Direction.Find(offer.direction.Id);
                if (!entity.direction.Equals(direction))
                {
                    entity.direction = offer.direction;
                }

                var commission = _context.Commission.Find(offer.commission.Id);
                if (!entity.commission.Equals(commission))
                {
                    entity.commission = offer.commission;
                }

                _context.SaveChanges();

                FetchOfferDto fetchOffer = new FetchOfferDto(offer.id, offer.code, offer.etat, offer.intitule, offer.description, offer.placeDepot, offer.dateLimit, offer.placeOpened, offer.dateOpened, offer.manager, offer.publish);

                fetchOffer.categorie.code = offer.categorie.code;
                fetchOffer.categorie.libelle = offer.categorie.libelle;
                fetchOffer.direction.code = offer.direction.code;
                fetchOffer.direction.libelle = offer.direction.libelle;
                fetchOffer.commission.code = offer.commission.code;
                fetchOffer.commission.libelle = offer.commission.libelle;

                return fetchOffer;

            } catch (Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                throw;
            }
        }

        public FetchOfferDto GetOffer(int offerId)
        {
            try
            {

                FetchOfferDto fetchOffer;
                List<Diffusion> diffusions = new List<Diffusion>();
                List<Bidder> bidders = new List<Bidder>();
                BidderDto bidderDto;

                var offer = _context.Offer.Include("categorie").Include("direction").Include("commission").Where(o => o.id == offerId).FirstOrDefault();
                diffusions = _context.Diffusion.Include("bidder").ToList();
                bidders = _context.Bidder.Include("address").Include("plis").ToList();


                fetchOffer = new FetchOfferDto(offer.id, offer.code, offer.etat, offer.intitule, offer.description, offer.placeDepot, offer.dateLimit, offer.placeOpened, offer.dateOpened, offer.manager, offer.publish);

                fetchOffer.categorie.code = offer.categorie.code;
                fetchOffer.categorie.libelle = offer.categorie.libelle;
                fetchOffer.direction.code = offer.direction.code;
                fetchOffer.direction.libelle = offer.direction.libelle;
                fetchOffer.commission.code = offer.commission.code;
                fetchOffer.commission.libelle = offer.commission.libelle;

                foreach (Diffusion diffusion in diffusions)
                {
                    foreach (Bidder bidder in bidders)
                    {
                        if (diffusion.offerId == offerId && diffusion.bidderId == bidder.Id)
                        {
                            bidderDto = new BidderDto(bidder.Id, bidder.firstName, bidder.lastName, bidder.email, bidder.tel, bidder.fax, bidder.domaine, bidder.typeEnterprise, bidder.address);
                           
                            fetchOffer.bidders.Add(bidderDto);
                        }
                                            
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

