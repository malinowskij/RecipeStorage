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
using RecipeStorageAPI.Models;

namespace RecipeStorageAPI.Controllers
{
    public class ImagesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Images
        public IQueryable<Image> GetRecipeImages()
        {
            return db.RecipeImages;
        }

        // GET: api/Images/5
        [ResponseType(typeof(Image))]
        public IHttpActionResult GetImage(int id)
        {
            Image image = db.RecipeImages.Find(id);
            if (image == null)
            {
                return NotFound();
            }

            return Ok(image);
        }

        // PUT: api/Images/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutImage(int id, Image image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != image.ID)
            {
                return BadRequest();
            }

            db.Entry(image).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageExists(id))
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

        // POST: api/Images
        [Authorize]
        [ResponseType(typeof(Image))]
        public IHttpActionResult PostImage(Image image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RecipeImages.Add(image);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = image.ID }, image);
        }

        // DELETE: api/Images/5
        [ResponseType(typeof(Image))]
        public IHttpActionResult DeleteImage(int id)
        {
            Image image = db.RecipeImages.Find(id);
            if (image == null)
            {
                return NotFound();
            }

            db.RecipeImages.Remove(image);
            db.SaveChanges();

            return Ok(image);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImageExists(int id)
        {
            return db.RecipeImages.Count(e => e.ID == id) > 0;
        }
    }
}