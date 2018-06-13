using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class TorneoController : Controller
    {
        private Entities db = new Entities();

        // GET: Torneo
        public async Task<ActionResult> Index()
        {
            var torneo = db.Torneo.Include(t => t.Competicion).Include(t => t.Temporada);
            return View(await torneo.ToListAsync());
        }

        // GET: Torneo/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneo torneo = await db.Torneo.FindAsync(id);
            if (torneo == null)
            {
                return HttpNotFound();
            }
            return View(torneo);
        }

        // GET: Torneo/Create
        public ActionResult Create()
        {
            ViewBag.codCompeticion = new SelectList(db.Competicion, "codCompeticion", "nbrCompeticion");
            ViewBag.codTemporada = new SelectList(db.Temporada, "codTemporada", "usuarioCreador");
            return View();
        }

        // POST: Torneo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "codTorneo,codCompeticion,codTemporada,usuarioCreador,usuarioModificador,fechaCreacion,fechaModificacion")] Torneo torneo)
        {
            if (ModelState.IsValid)
            {
                db.Torneo.Add(torneo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.codCompeticion = new SelectList(db.Competicion, "codCompeticion", "nbrCompeticion", torneo.codCompeticion);
            ViewBag.codTemporada = new SelectList(db.Temporada, "codTemporada", "usuarioCreador", torneo.codTemporada);
            return View(torneo);
        }

        // GET: Torneo/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneo torneo = await db.Torneo.FindAsync(id);
            if (torneo == null)
            {
                return HttpNotFound();
            }
            ViewBag.codCompeticion = new SelectList(db.Competicion, "codCompeticion", "nbrCompeticion", torneo.codCompeticion);
            ViewBag.codTemporada = new SelectList(db.Temporada, "codTemporada", "usuarioCreador", torneo.codTemporada);
            return View(torneo);
        }

        // POST: Torneo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "codTorneo,codCompeticion,codTemporada,usuarioCreador,usuarioModificador,fechaCreacion,fechaModificacion")] Torneo torneo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(torneo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.codCompeticion = new SelectList(db.Competicion, "codCompeticion", "nbrCompeticion", torneo.codCompeticion);
            ViewBag.codTemporada = new SelectList(db.Temporada, "codTemporada", "usuarioCreador", torneo.codTemporada);
            return View(torneo);
        }

        // GET: Torneo/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneo torneo = await db.Torneo.FindAsync(id);
            if (torneo == null)
            {
                return HttpNotFound();
            }
            return View(torneo);
        }

        // POST: Torneo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            Torneo torneo = await db.Torneo.FindAsync(id);
            db.Torneo.Remove(torneo);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
