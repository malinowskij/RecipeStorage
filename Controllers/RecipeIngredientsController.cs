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
    public class RecipeIngredientsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/RecipeIngredients
        public IQueryable<RecipeIngredients> GetRecipeIngredients()
        {
            return db.RecipeIngredients;
        }

        // GET: api/RecipeIngredients/5
        [ResponseType(typeof(RecipeIngredients))]
        public IHttpActionResult GetRecipeIngredients(int id)
        {
            RecipeIngredients recipeIngredients = db.RecipeIngredients.Find(id);
            if (recipeIngredients == null)
            {
                return NotFound();
            }

            return Ok(recipeIngredients);
        }

        // PUT: api/RecipeIngredients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecipeIngredients(int id, RecipeIngredients recipeIngredients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipeIngredients.ID)
            {
                return BadRequest();
            }

            db.Entry(recipeIngredients).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeIngredientsExists(id))
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

        // POST: api/RecipeIngredients
        [Authorize]
        [ResponseType(typeof(RecipeIngredients))]
        public IHttpActionResult PostRecipeIngredients(RecipeIngredients recipeIngredients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RecipeIngredients.Add(recipeIngredients);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recipeIngredients.ID }, recipeIngredients);
        }

        // DELETE: api/RecipeIngredients/5
        [ResponseType(typeof(RecipeIngredients))]
        public IHttpActionResult DeleteRecipeIngredients(int id)
        {
            RecipeIngredients recipeIngredients = db.RecipeIngredients.Find(id);
            if (recipeIngredients == null)
            {
                return NotFound();
            }

            db.RecipeIngredients.Remove(recipeIngredients);
            db.SaveChanges();

            return Ok(recipeIngredients);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecipeIngredientsExists(int id)
        {
            return db.RecipeIngredients.Count(e => e.ID == id) > 0;
        }
    }
}