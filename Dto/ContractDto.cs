using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffer.Dto
{
    public class ContractDto
    {
        public int Id { get; set; }

        public string code { get; set; }

        public string name { get; set; }

        public DateTime dateContract { get; set; }

        public string payment { get; set; }

        public int depouilleId { get; set; }

        public ContractDto()
        {

        }
    }
}
