using System;
using AspNetCoreCurrentRequestContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionOffers.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;
using Microsoft.AspNetCore.Http;
using GestionOffer.Dto;
using GestionOffer.ClientApp.app.Repository;
using System.Net.Http.Headers;
using GestionOffer.Models;
using log4net;
using System.Reflection;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionOffer.ClientApp.app.Api
{
    [Route("api/[controller]")]
    public class OfferController : Controller
    {

        private static OfferRepository offerRepository = new OfferRepository();
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private IHostingEnvironment _hostingEnvironment;

        public OfferController(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<FetchOfferDto> Get()
        {
            
            try
            {
                return offerRepository.GetListOffer().ToList();
               
            }
            catch (Exception e)
            {
                Log.Error("ListUser Get : " + e.Message + "||" + e.StackTrace);
                throw;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public FetchOfferDto Get(int id)
        {
            return offerRepository.GetOffer(id);
        }

        // POST api/<controller>
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Post([FromForm] OfferDto newOffer, ICollection<IFormFile> files)
        {
            try
            {
                Offer offerAdd = new Offer();
                offerAdd.categorie = new Categorie();
                offerAdd.direction = new Direction();
                offerAdd.commission = new Commission();
                offerAdd.documents = new List<PieceOffer>();
                if (files.Count() == 0) throw new Exception("There is not file");

                offerAdd.code = newOffer.code;
                offerAdd.categorie.Id = int.Parse(newOffer.categorieId);
             
                offerAdd.direction.Id = int.Parse(newOffer.directionId);
             
                offerAdd.commission.Id = int.Parse(newOffer.commissionId);
            
                offerAdd.etat = newOffer.etat;
                offerAdd.intitule = newOffer.intitule;
                offerAdd.description = newOffer.description;
                offerAdd.placeDepot = newOffer.placeDepot;
                offerAdd.placeOpened = newOffer.placeOpened;
                offerAdd.dateLimit = DateTime.Parse(newOffer.dateLimit);
                offerAdd.dateOpened = DateTime.Parse(newOffer.dateOpened);
                offerAdd.manager = newOffer.manager;
                offerAdd.dateCreation = DateTime.Now;

                string pth = _hostingEnvironment.ContentRootPath;
      
                string folder = pth + "\\ClientApp\\app\\components\\Images";
                
                PieceOffer document = new PieceOffer();

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string filePath = Path.Combine(folder, file.FileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        document.name = file.FileName;
                        document.type = file.ContentType;
                        document.dateCreation = DateTime.Now;
                        document.pathFile = filePath;
                        offerAdd.documents.Add(document);
                    }
                }

                offerRepository.AddOffer(offerAdd);
                return Ok(true);

            } catch (Exception e)
            {
                Log.Debug(e.Message + e.StackTrace);
                throw;
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public FetchOfferDto Put(int id, [FromBody]Offer offer)
        {         
            return offerRepository.UpdateOffer(offer);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {           
            return offerRepository.DeleteOffer(id);
        }


    }
}
