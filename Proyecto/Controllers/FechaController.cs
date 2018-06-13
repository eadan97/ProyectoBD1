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
    public class FechaController : Controller
    {
        private Entities db = new Entities();

        // GET: Fecha
        public async Task<ActionResult> Index()
        {
            var fecha = db.Fecha.Include(f => f.Torneo).Include(f => f.Usuario).Include(f => f.Usuario1);
            return View(await fecha.ToListAsync());
        }

        // GET: Fecha/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fecha fecha = await db.Fecha.FindAsync(id);
            if (fecha == null)
            {
                return HttpNotFound();
            }
            return View(fecha);
        }

        // GET: Fecha/Create
        public ActionResult Create()
        {
            ViewBag.codTorneo = new SelectList(db.Torneo, "codTorneo", "usuarioCreador");
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login");
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login");
            return View();
        }

        // POST: Fecha/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "codFecha,codTorneo,fecha1,usuarioCreador,usuarioModificador,fechaCreacion,fechaModificacion")] Fecha fecha)
        {
            if (ModelState.IsValid)
            {
                db.Fecha.Add(fecha);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.codTorneo = new SelectList(db.Torneo, "codTorneo", "usuarioCreador", fecha.codTorneo);
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login", fecha.usuarioCreador);
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login", fecha.usuarioModificador);
            return View(fecha);
        }

        // GET: Fecha/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fecha fecha = await db.Fecha.FindAsync(id);
            if (fecha == null)
            {
                return HttpNotFound();
            }
            ViewBag.codTorneo = new SelectList(db.Torneo, "codTorneo", "usuarioCreador", fecha.codTorneo);
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login", fecha.usuarioCreador);
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login", fecha.usuarioModificador);
            return View(fecha);
        }

        // POST: Fecha/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "codFecha,codTorneo,fecha1,usuarioCreador,usuarioModificador,fechaCreacion,fechaModificacion")] Fecha fecha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fecha).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.codTorneo = new SelectList(db.Torneo, "codTorneo", "usuarioCreador", fecha.codTorneo);
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login", fecha.usuarioCreador);
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login", fecha.usuarioModificador);
            return View(fecha);
        }

        // GET: Fecha/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fecha fecha = await db.Fecha.FindAsync(id);
            if (fecha == null)
            {
                return HttpNotFound();
            }
            return View(fecha);
        }

        // POST: Fecha/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            Fecha fecha = await db.Fecha.FindAsync(id);
            db.Fecha.Remove(fecha);
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
