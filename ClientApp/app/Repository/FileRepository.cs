using GestionOffer.Models;
using GestionOffers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv.Internal.Networking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading.Tasks;

namespace GestionOffer.ClientApp.app.Repository
{
    public class FileRepository: BaseRepository<Offer>
    {
        public FileRepository() : base(Context.Create())
        {

        }

        public IEnumerable<FileResult> GetFiles(int id)
        {
            Offer offer = new Offer();
            List<FileResult> files = new List<FileResult>();

            offer = _context.Offer.Include("documents").Where(o => o.id == id).FirstOrDefault();

            foreach (PieceOffer file in offer.documents)
            {

                string filePath = file.pathFile;

                byte[] fileBytes = File.ReadAllBytes(filePath);

                FileResult file_result = new FileContentResult(fileBytes, "application/pdf" );
                file_result.FileDownloadName = file.pathFile;

                files.Add(file_result);

            }

            return files;
        }
    }
}
