using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using GestionOffer.Dto;
using GestionOffer.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionOffer.ClientApp.app.Api
{
    [Route("api/[controller]")]
    public class MailController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public bool Post([FromBody]MailDto email)
        {
            try
            {
                
                MailMessage objmail = new MailMessage();
                MailAddressCollection mails = new MailAddressCollection();
                foreach (string mail in email.destinations) {

                         mails.Add(new MailAddress(mail));
                   }
                    

                    objmail.Subject = "Appel D'Offres";
                    objmail.From = new MailAddress(email.author);

                foreach (string fi in email.documents)
                {
                    Attachment fichier = new Attachment(fi);
                    objmail.Attachments.Add(fichier);

                }

                foreach (MailAddress destinator in mails) {
                    objmail.To.Add(destinator);
                }
                    objmail.Body = "Code:" + email.offer.code + "<br/>" +
                                   "Intitule:" + email.offer.intitule + "<br/>" +
                                   "Libelle:" + email.offer.categorie.libelle + "<br/>" +
                                   "Description:" + email.offer.description + "<br/>" +
                                   "Date Limit:" + email.offer.dateLimit + "<br/>" +
                                   "Place Of Depot:" + email.offer.placeDepot;
                    objmail.IsBodyHtml = true;

               


                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("caohoangthang7@gmail.com", email.password);
                 
                client.Send(objmail);

                return true;
                
            } catch (Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                throw;
            } 

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
