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
    public class CommissionRepository : BaseRepository<Commission>
    {

        public CommissionRepository() : base(Context.Create())
        {

        }

        public bool addCommission(CommissionDto commission)
        {
            try
            {
                Commission newCommission = new Commission(commission.code, commission.libelle);
                Console.WriteLine(newCommission);

                foreach (User member in commission.members)
                {
                    _context.User.Find(member.Id).member.Add(new Member(newCommission, member));
                }

                _context.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                throw;
            }
        }


        public IEnumerable<CommissionDto> GetCommissions()
        {
            try
            {
                List<Commission> commissions = new List<Commission>();
                List<CommissionDto> commisionDto = new List<CommissionDto>();
                List<Member> members = new List<Member>();
                CommissionDto commis;
                Address address = new Address();

                commissions = _context.Commission.ToList();
                members = _context.Member.Include("user").ToList();

                foreach (Commission co in commissions)
                {
                    commis = new CommissionDto(co.Id, co.code, co.libelle);
                    foreach (Member member in members)
                    {
                        if (co.Id == member.commissionId)
                        {
                            commis.members.Add(new User(member.user.firstName, member.user.lastName, member.user.date, member.user.mail, member.user.numberTel, member.user.password, member.user.type, address ));
                        }
                    }
                    commisionDto.Add(commis);
                }

                return commisionDto;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                throw;
            }
        }

       
    }
}
