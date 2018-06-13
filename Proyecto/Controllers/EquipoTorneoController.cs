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
    public class EquipoTorneoController : Controller
    {
        private Entities db = new Entities();

        // GET: EquipoTorneo
        public async Task<ActionResult> Index()
        {
            var equipoTorneo = db.EquipoTorneo.Include(e => e.Equipo).Include(e => e.Torneo).Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(await equipoTorneo.ToListAsync());
        }

        // GET: EquipoTorneo/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoTorneo equipoTorneo = await db.EquipoTorneo.FindAsync(id);
            if (equipoTorneo == null)
            {
                return HttpNotFound();
            }
            return View(equipoTorneo);
        }

        // GET: EquipoTorneo/Create
        public ActionResult Create()
        {
            ViewBag.codEquipo = new SelectList(db.Equipo, "codEquipo", "nombreEquipo");
            ViewBag.codTorneo = new SelectList(db.Torneo, "codTorneo", "usuarioCreador");
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login");
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login");
            return View();
        }

        // POST: EquipoTorneo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "codEquipo,codTorneo,posicion,usuarioCreador,usuarioModificador,fechaCreacion,fechaModificacion")] EquipoTorneo equipoTorneo)
        {
            if (ModelState.IsValid)
            {
                db.EquipoTorneo.Add(equipoTorneo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.codEquipo = new SelectList(db.Equipo, "codEquipo", "nombreEquipo", equipoTorneo.codEquipo);
            ViewBag.codTorneo = new SelectList(db.Torneo, "codTorneo", "usuarioCreador", equipoTorneo.codTorneo);
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login", equipoTorneo.usuarioModificador);
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login", equipoTorneo.usuarioCreador);
            return View(equipoTorneo);
        }

        // GET: EquipoTorneo/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoTorneo equipoTorneo = await db.EquipoTorneo.FindAsync(id);
            if (equipoTorneo == null)
            {
                return HttpNotFound();
            }
            ViewBag.codEquipo = new SelectList(db.Equipo, "codEquipo", "nombreEquipo", equipoTorneo.codEquipo);
            ViewBag.codTorneo = new SelectList(db.Torneo, "codTorneo", "usuarioCreador", equipoTorneo.codTorneo);
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login", equipoTorneo.usuarioModificador);
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login", equipoTorneo.usuarioCreador);
            return View(equipoTorneo);
        }

        // POST: EquipoTorneo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "codEquipo,codTorneo,posicion,usuarioCreador,usuarioModificador,fechaCreacion,fechaModificacion")] EquipoTorneo equipoTorneo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipoTorneo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.codEquipo = new SelectList(db.Equipo, "codEquipo", "nombreEquipo", equipoTorneo.codEquipo);
            ViewBag.codTorneo = new SelectList(db.Torneo, "codTorneo", "usuarioCreador", equipoTorneo.codTorneo);
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login", equipoTorneo.usuarioModificador);
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login", equipoTorneo.usuarioCreador);
            return View(equipoTorneo);
        }

        // GET: EquipoTorneo/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoTorneo equipoTorneo = await db.EquipoTorneo.FindAsync(id);
            if (equipoTorneo == null)
            {
                return HttpNotFound();
            }
            return View(equipoTorneo);
        }

        // POST: EquipoTorneo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            EquipoTorneo equipoTorneo = await db.EquipoTorneo.FindAsync(id);
            db.EquipoTorneo.Remove(equipoTorneo);
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
