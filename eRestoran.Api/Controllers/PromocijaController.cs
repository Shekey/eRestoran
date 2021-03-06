﻿using eRestoran.Api.Infrastructure;
using eRestoran.Data.DAL;
using eRestoran.Data.Models;
using eRestoran.PCL.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace eRestoran.Api.Controllers
{
    public class PromocijaController : ApiController
    {
        private MyContext db = new MyContext();

        public List<Promocija> GetPromocije()
        {
            return db.Promocije.ToList();
        }

        // POST: api/Skladiste
        [ResponseType(typeof(Promocija))]
        [HttpPost]
        [Route("api/promocija/promovisi", Name = "PromovisiProizvod")]
        public IHttpActionResult PostPromocija(PromocijaVM model)
        {
            if (model.ProizvodId.HasValue)
            {
                var promotionsService = new PromotionsService();
                promotionsService.endPromotions(proizvodId: model.ProizvodId.Value);
            }
            else
            {
                var promotionsService = new PromotionsService();
                promotionsService.endPromotions(jeloId: model.JeloId.Value);
            }

            var promocija = new Promocija()
            {
                DatumDo = model.DatumDo,
                DatumOd = model.DatumOd,
                PromotivnaCijena = model.PromotivnaCijena,
                JeloId = model.JeloId,
                ProizvodId = model.ProizvodId,
                StaraCijena = model.StaraCijena
            };

            db.Promocije.Add(promocija);
            db.SaveChanges();

            if (promocija.DatumOd.Date == DateTime.Now.Date)
            {
                var promotionsService = new PromotionsService();
                promotionsService.CheckPromotions();
            }

            return CreatedAtRoute("PromovisiProizvod", new { Id = promocija.Id }, promocija);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
