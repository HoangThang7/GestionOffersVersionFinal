using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GestionOffer.ClientApp.app.Repository;
using GestionOffer.Dto;
using GestionOffer.Models;
using log4net;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionOffer.ClientApp.app.Api
{
    [Route("api/[controller]")]
    public class BidderController : Controller
    {
        private static BidderRepository bidderRepository = new BidderRepository();
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<BidderDto> Get()
        {
            try
            {
                return bidderRepository.GetListBidder();
            } catch(Exception e)
            {
                Log.Debug(e.Message + e.StackTrace);
                throw;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public BidderDto Get(int id)
        {
            try
            {
                return bidderRepository.GetBidder(id);

            }
            catch (Exception e)
            {
                Log.Debug(e.Message + e.StackTrace);
                throw;
            }
        }

        // POST api/<controller>
        [HttpPost]
        public int Post([FromBody]BidderDto bid)
        {
           
                Console.WriteLine(bid);
                return bidderRepository.PostBidder(bid);

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public BidderDto Put(int id, [FromBody]BidderDto bidder)
        {
            Console.WriteLine(bidder);
            return bidderRepository.UpdateBidder(bidder);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
