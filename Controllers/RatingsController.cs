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
using RecipeStorageAPI.Models.ViewModel;

namespace RecipeStorageAPI.Controllers
{
    public class RatingsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Ratings
        public IQueryable<Rating> GetRatings()
        {
            return db.Ratings;
        }

        // GET: api/Ratings/Recipe/5
        [Route("api/Ratings/Recipe/{recipeId:int}")]
        [ResponseType(typeof(RatingValue))]
        public IHttpActionResult GetRatingValueForRecipe(int recipeId)
        {
            List<Rating> ratings = db.Ratings.Where(r => r.RecipeID == recipeId).ToList();
            double value = 0.0;
            if (ratings.Count > 0)
                value = (double)ratings.Sum(r => r.Value) / (double)ratings.Count;
            RatingValue rv = new RatingValue(recipeId, value);
            return Ok(rv);
        }

        // GET: api/Ratings/5
        [ResponseType(typeof(Rating))]
        public IHttpActionResult GetRating(int id)
        {
            Rating rating = db.Ratings.Find(id);
            if (rating == null)
            {
                return NotFound();
            }

            return Ok(rating);
        }

        // POST: api/Ratings
        [ResponseType(typeof(Rating))]
        public IHttpActionResult PostRating(Rating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ratings.Add(rating);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rating.ID }, rating);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RatingExists(int id)
        {
            return db.Ratings.Count(e => e.ID == id) > 0;
        }
    }
}