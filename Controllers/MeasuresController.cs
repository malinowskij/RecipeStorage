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
    public class MeasuresController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Measures
        public IQueryable<Measure> GetMeasures()
        {
            return db.Measures;
        }

        // GET: api/Measures/5
        [ResponseType(typeof(Measure))]
        public IHttpActionResult GetMeasure(int id)
        {
            Measure measure = db.Measures.Find(id);
            if (measure == null)
            {
                return NotFound();
            }

            return Ok(measure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MeasureExists(int id)
        {
            return db.Measures.Count(e => e.ID == id) > 0;
        }
    }
}