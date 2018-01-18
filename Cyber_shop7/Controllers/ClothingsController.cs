using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Cors;
using Cyber_shop7;

namespace Cyber_shop7.Controllers
{
    public class ClothingsController : ApiController
    {
        private Cyber_ShopEntities db = new Cyber_ShopEntities();

        // GET: api/Clothings
        public IQueryable<Clothing> GetClothings()
        {
            return db.Clothings;
        }

        // GET: api/Clothings/5
        [ResponseType(typeof(Clothing))]
        public IHttpActionResult GetClothing(int id)
        {
            Clothing clothing = db.Clothings.Find(id);
            if (clothing == null)
            {
                return NotFound();
            }

            return Ok(clothing);
        }

        // PUT: api/Clothings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClothing(int id, Clothing clothing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clothing.Id)
            {
                return BadRequest();
            }

            db.Entry(clothing).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClothingExists(id))
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

        // POST: api/Clothings
        [ResponseType(typeof(Clothing))]
        public IHttpActionResult PostClothing(Clothing clothing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clothings.Add(clothing);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ClothingExists(clothing.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = clothing.Id }, clothing);
        }

        // DELETE: api/Clothings/5
        [ResponseType(typeof(Clothing))]
        public IHttpActionResult DeleteClothing(int id)
        {
            Clothing clothing = db.Clothings.Find(id);
            if (clothing == null)
            {
                return NotFound();
            }

            db.Clothings.Remove(clothing);
            db.SaveChanges();

            return Ok(clothing);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClothingExists(int id)
        {
            return db.Clothings.Count(e => e.Id == id) > 0;
        }
    }
}