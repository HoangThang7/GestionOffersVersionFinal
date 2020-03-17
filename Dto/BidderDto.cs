using GestionOffer.Models;
using GestionOffers.Models;
using System.Collections.Generic;

namespace GestionOffer.Dto
{
    public class BidderDto
    {
        public int Id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string email { get; set; }

        public int tel { get; set; }

        public string fax { get; set; }

        public string domaine { get; set; }

        public string typeEnterprise { get; set; }

        public Address address { get; set; }

        public Offer offer { get; set; }

        public ICollection<PlisDto> plis { get; set; }

        public BidderDto()
        {

        }

        public BidderDto (int id, string firstName, string lastName, string email, int tel, string fax, string domaine, string typeEnterprise, Address address)
        {
            this.Id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.tel = tel;
            this.fax = fax;
            this.domaine = domaine;
            this.typeEnterprise = typeEnterprise;
            this.address = new Address(address.street, address.zip, address.city, address.region, address.country);
 
        }

        public BidderDto(int id, string firstName, string lastName, string email, int tel, string fax, string domaine, string typeEnterprise)
        {
            this.Id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.tel = tel;
            this.fax = fax;
            this.domaine = domaine;
            this.typeEnterprise = typeEnterprise;
            this.address = new Address();

        }
    }
}
