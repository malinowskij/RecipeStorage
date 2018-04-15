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
    public class RecipeStepsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/RecipeSteps
        public IQueryable<RecipeStep> GetRecipeSteps()
        {
            return db.RecipeSteps.OrderBy(a => a.ID);
        }

        // GET: api/RecipeSteps/5
        [ResponseType(typeof(RecipeStep))]
        public IHttpActionResult GetRecipeStep(int id)
        {
            RecipeStep recipeStep = db.RecipeSteps.Find(id);
            if (recipeStep == null)
            {
                return NotFound();
            }

            return Ok(recipeStep);
        }

        // PUT: api/RecipeSteps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecipeStep(int id, RecipeStep recipeStep)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipeStep.ID)
            {
                return BadRequest();
            }

            db.Entry(recipeStep).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeStepExists(id))
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

        // POST: api/RecipeSteps
        [Authorize]
        [ResponseType(typeof(RecipeStep))]
        public IHttpActionResult PostRecipeStep(RecipeStep recipeStep)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RecipeSteps.Add(recipeStep);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recipeStep.ID }, recipeStep);
        }

        // DELETE: api/RecipeSteps/5
        [ResponseType(typeof(RecipeStep))]
        public IHttpActionResult DeleteRecipeStep(int id)
        {
            RecipeStep recipeStep = db.RecipeSteps.Find(id);
            if (recipeStep == null)
            {
                return NotFound();
            }

            db.RecipeSteps.Remove(recipeStep);
            db.SaveChanges();

            return Ok(recipeStep);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecipeStepExists(int id)
        {
            return db.RecipeSteps.Count(e => e.ID == id) > 0;
        }
    }
}