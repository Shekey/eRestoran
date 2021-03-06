﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using eRestoran.Api.Util;
//using eRestoran.Api.Util;
using eRestoran.Data.DAL;
using eRestoran.Data.Models;
using eRestoran.PCL.VM;
using static eRestoran.VM.PonudaVM;

namespace eRestoran.Api.Controllers
{
    public class ProizvodiController : ApiController
    {
        private MyContext db = new MyContext();
        string baseUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";

        // GET: api/Proizvodi
        public List<PonudaInfo> GetProizvodi()
        {
            return db.Proizvodi.Select(x => new PonudaInfo
            {
                Cijena = x.Cijena,
                Kolicina = x.Kolicina,
                KolicinaString = x.Kolicina.ToString(),
                Kategorija = x.TipProizvoda.Naziv,
                Naziv = x.Naziv,
                Id = x.Id,
                imageUrl = baseUrl + x.SlikaUrl,

            }).ToList();
        }

        // GET: api/Proizvodi/5
        [ResponseType(typeof(Proizvod))]
        public Proizvod GetProizvod(int id)
        {
            Proizvod proizvod = db.Proizvodi.Find(id);
            if (proizvod == null)
            {
                return null;
            }

            return proizvod;
        }

        //start recomended system

        [HttpGet]
        [Route("api/Proizvodi/RecommendProducts/{productID}/{isJelo}")]
        public List<PonudaInfo> RecommendProducts(int productID, int isJelo)
        {
            Recommender rec = new Recommender();
            return rec.GetSlicneProizvode(productID, isJelo);
        }

        //end recomended system
        public PonudaInfo GetProizvodVM(int id)
        {
            PonudaInfo proizvod = db.Proizvodi.Where(x => x.Id == id).Select(x => new PonudaInfo
            {
                Id = id,
                Naziv = x.Naziv,
                Kolicina = x.Kolicina,
                KolicinaString = x.Kolicina.ToString(),
                Kategorija = x.TipProizvoda.Naziv,
                Cijena = x.Cijena,
                imageUrl = baseUrl + x.SlikaUrl


            }).FirstOrDefault();

            return proizvod;
        }

        // PUT: api/Proizvodi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProizvod(int id, Proizvod proizvod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proizvod.Id)
            {
                return BadRequest();
            }

            var proizvodTrazeni = db.Proizvodi.SingleOrDefault(f => f.Id == id);
            proizvodTrazeni.SkladisteId = proizvod.SkladisteId;
            proizvodTrazeni.TipProizvodaId = proizvod.TipProizvodaId;
            proizvodTrazeni.Naziv = proizvod.Naziv;
            proizvodTrazeni.Cijena = proizvod.Cijena;
            proizvodTrazeni.Kolicina = proizvod.Kolicina;
            proizvodTrazeni.KriticnaKolicina = proizvod.KriticnaKolicina;
            proizvodTrazeni.Menu = proizvod.Menu;
            proizvodTrazeni.Sifra = proizvod.Sifra;
            proizvodTrazeni.SlikaUrl = proizvod.SlikaUrl;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProizvodExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Proizvodi
        [ResponseType(typeof(Proizvod))]
        public IHttpActionResult PostProizvod(Proizvod proizvod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Proizvodi.Add(proizvod);
            try
            {
                db.SaveChanges();

            }
            catch (Exception e)
            {
                var x = e.Message;
            }
            return CreatedAtRoute("DefaultApi", new { id = proizvod.Id }, proizvod);
        }

        // DELETE: api/Proizvodi/5
        [ResponseType(typeof(Proizvod))]
        public IHttpActionResult DeleteProizvod(int id)
        {
            Proizvod proizvod = db.Proizvodi.Find(id);
            if (proizvod == null)
            {
                return NotFound();
            }

            db.Proizvodi.Remove(proizvod);
            db.SaveChanges();

            return Ok(proizvod);
        }

        [ResponseType(typeof(void))]
        [HttpPost]
        [Route("api/Proizvodi/OcjeniProizvod")]
        public IHttpActionResult OcjeniProizvod(OcjeneVM ocjene)
        {

            var proslaOcjena = db.Ocjene.Where(x => x.KupacId == ocjene.KupacId && x.IsJelo == ocjene.IsJelo && x.ProizvodId == ocjene.ProizvodId).SingleOrDefault();
            if (proslaOcjena != null)
            {
                proslaOcjena.Ocjena = ocjene.Ocjena;
            }
            else
            {
                var ocjena = new Ocjene();
                ocjena.KupacId = ocjene.KupacId;
                ocjena.ProizvodId = ocjene.ProizvodId;
                ocjena.Ocjena = ocjene.Ocjena;
                ocjena.IsJelo = ocjene.IsJelo;

                db.Ocjene.Add(ocjena);
            }

            db.SaveChanges();

            return StatusCode(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProizvodExists(int id)
        {
            return db.Proizvodi.Count(e => e.Id == id) > 0;
        }

      }
}