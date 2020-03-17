using GestionOffer.Dto;
using GestionOffer.Models;
using GestionOffers.Models;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffer.ClientApp.app.Repository
{
    public class BidderRepository: BaseRepository<Bidder>
    {
        public BidderRepository() : base(Context.Create())
        {

        }

        public int PostBidder(BidderDto bidder)
        {
            try
            {
                Diffusion diffusion = new Diffusion();
             
                var offer = _context.Offer.Include("diffusOffer").Where(o => o.id == bidder.offer.id).FirstOrDefault();
                var oldBidder = _context.Bidder.Where(b => b.email == bidder.email).FirstOrDefault();

                if (oldBidder != null)
                {
                    offer.diffusOffer.Add(new Diffusion(bidder.offer, oldBidder));

                }
                else
                {
                    Bidder newBidder = new Bidder(bidder.firstName, bidder.lastName, bidder.email, bidder.tel, bidder.fax, bidder.domaine, bidder.typeEnterprise, bidder.address);

                    offer.diffusOffer.Add(new Diffusion(bidder.offer, newBidder));

                }

                _context.SaveChanges();

                var bid = _context.Diffusion.Where(d => d.offerId == bidder.offer.id).FirstOrDefault().bidder;

                return bid.Id;

             } catch (Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                throw;
            }

        }

        public BidderDto GetBidder(int biderId)
        {
            try
            {
           
                List<Bidder> bidders = new List<Bidder>();
                BidderDto bidderDto = new BidderDto();
                
                PlisDto plis;
            
                bidders = _context.Bidder.Include("address").Include("plis").ToList();
                
                foreach (Bidder bidder in bidders)
                {
                    if (bidder.Id == biderId)
                    {
                        bidderDto = new BidderDto(bidder.Id, bidder.firstName, bidder.lastName, bidder.email, bidder.tel, bidder.fax, bidder.domaine, bidder.typeEnterprise, bidder.address);
                        foreach (Plis pli in bidder.plis)
                        {
                            
                                plis = new PlisDto(pli.Id, pli.code, pli.libelle, pli.dateDepot, pli.typeDepot);
                                plis.offerId = pli.offerId;
                                bidderDto.plis = new List<PlisDto>();
                                bidderDto.plis.Add(plis);                          
                        }

                    }
                }
                
                return bidderDto;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                throw;
            }

        }



        public IEnumerable<BidderDto> GetListBidder()
        {
            try
            {
                List<BidderDto> bidderDtos = new List<BidderDto>();
                List<Plis> listPlis = new List<Plis>();
                List<Bidder> bidders = new List<Bidder>();
                BidderDto bidderDto;

                bidders = _context.Bidder.Include("address").Include("plis").Distinct().ToList();

                    foreach (Bidder bidder in bidders)
                    {
                        
                            bidderDto = new BidderDto(bidder.Id, bidder.firstName, bidder.lastName, bidder.email, bidder.tel, bidder.fax, bidder.domaine, bidder.typeEnterprise, bidder.address);
                             
                            bidderDtos.Add(bidderDto);
                        
                    }
                
                return bidderDtos;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                throw;
            }

        }

        public BidderDto UpdateBidder(BidderDto newBidder)
        {
            try
            {
                var entity = _context.Bidder.Include("address").Where(b => b.Id == newBidder.Id).FirstOrDefault();


                entity.firstName = newBidder.firstName;
                entity.lastName = newBidder.lastName;
                entity.tel = newBidder.tel;
                entity.email = newBidder.email;
                entity.fax = newBidder.fax;
                entity.domaine = newBidder.domaine;
                entity.typeEnterprise = newBidder.typeEnterprise;
                entity.address.street = newBidder.address.street;
                entity.address.zip = newBidder.address.zip;
                entity.address.city = newBidder.address.city;
                entity.address.region = newBidder.address.region;
                entity.address.country = newBidder.address.country;

                _context.SaveChanges();

                return newBidder;
            }
            catch ( Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                throw;
            }
        }
    }
   

}
