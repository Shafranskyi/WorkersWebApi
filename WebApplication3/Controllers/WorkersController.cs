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
using WebApplication3;

namespace WebApplication3.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("Api/Workers")]
    public class WorkersController : ApiController
    {
        private readonly Factory db = new Factory();

        // GET: api/Workers
        /// <summary>
        /// Get Workers
        /// </summary>
        /// <returns>Get Workers</returns>
        [HttpGet]
        [Route("ReadAllWorkersInfo")]
        public IQueryable<Worker> GetWorkers()
        {
            return db.Workers;
        }

        // GET: api/Workers/5
        /// <summary>
        /// Get Worker by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Get Worker by Id</returns>
        [ResponseType(typeof(Worker))]
        [Route("ReadWorkerById/{id}")] 
        public IHttpActionResult GetWorker(int id)
        {
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return NotFound();
            }

            return Ok(worker);
        }

        // PUT: api/Workers/5
        /// <summary>
        /// Put Worker
        /// </summary>
        /// <param name="id"></param>
        /// <param name="worker"></param>
        /// <returns>Put Worker</returns>
        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("UpdateWorker/{id}")]
        public IHttpActionResult PutWorker([FromUri]int id, [FromBody]Worker worker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != worker.Id)
            {
                return BadRequest();
            }

            db.Entry(worker).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkerExists(id))
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

        // POST: api/Workers
        /// <summary>
        /// Post Worker
        /// </summary>
        /// <param name="worker"></param>
        /// <returns>Post Worker</returns>
        [HttpPost]
        [ResponseType(typeof(Worker))]
        [Route("CreateWorker")]
        public IHttpActionResult PostWorker(Worker worker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Workers.Add(worker);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = worker.Id }, worker);
        }

        // DELETE: api/Workers/5
        /// <summary>
        /// Del Worker
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Del Worker</returns>
        [HttpDelete]
        [ResponseType(typeof(Worker))]
        [Route("DeleteWorker")]
        public IHttpActionResult DeleteWorker(int id)
        {
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return NotFound();
            }

            db.Workers.Remove(worker);
            db.SaveChanges();

            return Ok(worker);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing">Dispose</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkerExists(int id)
        {
            return db.Workers.Count(e => e.Id == id) > 0;
        }
    }
}