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
    public class TemporadaController : Controller
    {
        private Entities db = new Entities();

        // GET: Temporada
        public async Task<ActionResult> Index()
        {
            var temporada = db.Temporada.Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(await temporada.ToListAsync());
        }

        // GET: Temporada/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temporada temporada = await db.Temporada.FindAsync(id);
            if (temporada == null)
            {
                return HttpNotFound();
            }
            return View(temporada);
        }

        // GET: Temporada/Create
        public ActionResult Create()
        {
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login");
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login");
            return View();
        }

        // POST: Temporada/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "codTemporada,fechaInicio,fechaFin,usuarioCreador,usuarioModificador,fechaCreacion,fechaModificacion")] Temporada temporada)
        {
            if (ModelState.IsValid)
            {
                db.Temporada.Add(temporada);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login", temporada.usuarioCreador);
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login", temporada.usuarioModificador);
            return View(temporada);
        }

        // GET: Temporada/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temporada temporada = await db.Temporada.FindAsync(id);
            if (temporada == null)
            {
                return HttpNotFound();
            }
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login", temporada.usuarioCreador);
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login", temporada.usuarioModificador);
            return View(temporada);
        }

        // POST: Temporada/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "codTemporada,fechaInicio,fechaFin,usuarioCreador,usuarioModificador,fechaCreacion,fechaModificacion")] Temporada temporada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(temporada).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login", temporada.usuarioCreador);
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login", temporada.usuarioModificador);
            return View(temporada);
        }

        // GET: Temporada/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temporada temporada = await db.Temporada.FindAsync(id);
            if (temporada == null)
            {
                return HttpNotFound();
            }
            return View(temporada);
        }

        // POST: Temporada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            Temporada temporada = await db.Temporada.FindAsync(id);
            db.Temporada.Remove(temporada);
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
