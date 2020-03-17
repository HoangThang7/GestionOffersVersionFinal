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
    public class DepouillementRepository : BaseRepository<Depouillement>
    {
        public DepouillementRepository() : base(Context.Create())
        {

        }

        public int PostDepouille(DepouillementDto depouillement)
        {
            try
            {
                var depouille = _context.Depouillement.Where(p => p.plisId == depouillement.plisId).FirstOrDefault();
                depouille.noteFinance = depouillement.noteFinance;
                depouille.noteTechnical = depouillement.noteTechnical;
                depouille.transCript = depouillement.transCript;
                depouille.comment = depouillement.comment;
                depouille.dateDepouille = depouillement.dateDepouille;

                _context.SaveChanges();

                int? Id = _context.Depouillement.Where(d => d.plisId == depouillement.plisId).FirstOrDefault().Id;

                return  (int)Id;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                throw;
            }
        }

        public bool UpdateDepouille(int Id, Depouillement depouillement)
        {
            try
            {
                var depouille = _context.Depouillement.Find(Id);

                depouille.noteFinance = depouillement.noteFinance;
                depouille.noteTechnical = depouillement.noteTechnical;
                depouille.transCript = depouillement.transCript;
                depouille.comment = depouillement.comment;
                depouille.dateDepouille = depouillement.dateDepouille;

                _context.SaveChanges();
                return true;
            } catch (Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                throw;
            }

        }

        public Depouillement GetDepouille(int id)
        {
            try
            {
                var depouille = _context.Depouillement.Include("contract").Where(d => d.plisId == id).FirstOrDefault();

                Depouillement newDepouille = new Depouillement(depouille.Id, depouille.noteFinance,depouille.noteTechnical, depouille.transCript, depouille.comment,depouille.dateDepouille);

                if(depouille.contract != null)
                {
                    newDepouille.contract = new Contract(depouille.contract.Id, depouille.contract.code, depouille.contract.name, depouille.contract.dateContract, depouille.contract.payment);
                }

                if (newDepouille.transCript != null)
                {
                    return newDepouille;
                } else
                {
                    Depouillement depouillement = new Depouillement(0, 0, 0, "En attente", "En attendant dépouille", DateTime.Now);
                    depouillement.contract = new Contract();
                    return depouillement;
                }

            } catch (Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                throw;
            }
        }
    }
}
