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
using WebApplication14.Models;

namespace WebApplication14.Controllers
{
    public class WalletBCS153114Controller : ApiController
    {
        private WalletBCS153114Entities db = new WalletBCS153114Entities();

        // GET: api/WalletBCS153114
        public IQueryable<WalletBCS153114> GetWalletBCS153114()
        {
            return db.WalletBCS153114;
        }

        // GET: api/WalletBCS153114/5
        [ResponseType(typeof(WalletBCS153114))]
        public IHttpActionResult GetWalletBCS153114(int id)
        {
            WalletBCS153114 walletBCS153114 = db.WalletBCS153114.Find(id);
            if (walletBCS153114 == null)
            {
                return NotFound();
            }

            return Ok(walletBCS153114);
        }

        // PUT: api/WalletBCS153114/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWalletBCS153114(int id, WalletBCS153114 walletBCS153114)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != walletBCS153114.WalletId)
            {
                return BadRequest();
            }

            db.Entry(walletBCS153114).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WalletBCS153114Exists(id))
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

        // POST: api/WalletBCS153114
        [ResponseType(typeof(WalletBCS153114))]
        public IHttpActionResult PostWalletBCS153114(WalletBCS153114 walletBCS153114)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WalletBCS153114.Add(walletBCS153114);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (WalletBCS153114Exists(walletBCS153114.WalletId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = walletBCS153114.WalletId }, walletBCS153114);
        }

        // DELETE: api/WalletBCS153114/5
        [ResponseType(typeof(WalletBCS153114))]
        public IHttpActionResult DeleteWalletBCS153114(int id)
        {
            WalletBCS153114 walletBCS153114 = db.WalletBCS153114.Find(id);
            if (walletBCS153114 == null)
            {
                return NotFound();
            }

            db.WalletBCS153114.Remove(walletBCS153114);
            db.SaveChanges();

            return Ok(walletBCS153114);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WalletBCS153114Exists(int id)
        {
            return db.WalletBCS153114.Count(e => e.WalletId == id) > 0;
        }
    }
}