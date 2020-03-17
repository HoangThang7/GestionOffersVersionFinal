using GestionOffer.Dto;
using GestionOffer.Models;
using GestionOffers.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffer.ClientApp.app.Repository
{
    public class ContractRepository: BaseRepository<Contract>
    {

        public ContractRepository() : base(Context.Create())
        {

        }

        public Contract getContract(int id)
        {
            
            try
            {
                Contract newContract;
                var contract = _context.Contract.Where(c => c.Id == id).FirstOrDefault();

                newContract = new Contract(contract.Id, contract.code, contract.name, contract.dateContract, contract.payment);
               
                               
                return newContract;

            } catch (Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                throw;
            }
        }

        public int PostContract(ContractDto contract)
        {
            try
            {
                var depouille = _context.Depouillement.Find(contract.depouilleId);
                depouille.contract = new Contract(contract.code, contract.name, contract.dateContract, contract.payment);

                _context.SaveChanges();

                int? Id = _context.Contract.Where(c => c.depouilleId == contract.depouilleId).FirstOrDefault().Id;

                return (int)Id;

            } catch (Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                throw;
            }
        }

        public bool UpdateContract(int Id, Contract contract)
        {
            try
            {
                var depouille = _context.Depouillement.Find(Id);

                depouille.contract.code = contract.code;
                depouille.contract.name = contract.name;
                depouille.contract.dateContract = contract.dateContract;
                depouille.contract.payment = contract.payment;

                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                throw;
            }

        }
    }
}
