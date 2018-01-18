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
    [EnableCors(origins: "*", methods: "*", headers: "*")]

    public class MobilesController : ApiController
    {
        private Cyber_ShopEntities db = new Cyber_ShopEntities();

        // GET: api/Mobiles
        public IQueryable<Mobile> GetMobiles()
        {
            return db.Mobiles;
        }

        // GET: api/Mobiles/5
        [ResponseType(typeof(Mobile))]
        public IHttpActionResult GetMobile(int id)
        {
            Mobile mobile = db.Mobiles.Find(id);
            if (mobile == null)
            {
                return NotFound();
            }

            return Ok(mobile);
        }

        // PUT: api/Mobiles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMobile(int id, Mobile mobile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mobile.Id)
            {
                return BadRequest();
            }

            db.Entry(mobile).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MobileExists(id))
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

        // POST: api/Mobiles
        [ResponseType(typeof(Mobile))]
        public IHttpActionResult PostMobile(Mobile mobile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mobiles.Add(mobile);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MobileExists(mobile.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mobile.Id }, mobile);
        }

        // DELETE: api/Mobiles/5
        [ResponseType(typeof(Mobile))]
        public IHttpActionResult DeleteMobile(int id)
        {
            Mobile mobile = db.Mobiles.Find(id);
            if (mobile == null)
            {
                return NotFound();
            }

            db.Mobiles.Remove(mobile);
            db.SaveChanges();

            return Ok(mobile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MobileExists(int id)
        {
            return db.Mobiles.Count(e => e.Id == id) > 0;
        }
    }
}