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

namespace Proyecto.Views.Consulta
{
    public class PartidoController : Controller
    {
        private Entities db = new Entities();

        // GET: Partido
        public async Task<ActionResult> Index()
        {
            var partido = db.Partido.Include(p => p.Equipo).Include(p => p.Equipo1).Include(p => p.Fecha).Include(p => p.Usuario).Include(p => p.Usuario1);
            return View(await partido.ToListAsync());
        }

        // GET: Partido/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partido partido = await db.Partido.FindAsync(id);
            if (partido == null)
            {
                return HttpNotFound();
            }
            return View(partido);
        }

        // GET: Partido/Create
        public ActionResult Create()
        {
            ViewBag.codEquipo1 = new SelectList(db.Equipo, "codEquipo", "nombreEquipo");
            ViewBag.codEquipo2 = new SelectList(db.Equipo, "codEquipo", "nombreEquipo");
            ViewBag.codFecha = new SelectList(db.Fecha, "codFecha", "usuarioCreador");
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login");
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login");
            return View();
        }

        // POST: Partido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "codPartido,codFecha,codEquipo1,codEquipo2,golesEquipo1,golesEquipo2,usuarioCreador,usuarioModificador,fechaCreacion,fechaModificacion")] Partido partido)
        {
            if (ModelState.IsValid)
            {
                db.Partido.Add(partido);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.codEquipo1 = new SelectList(db.Equipo, "codEquipo", "nombreEquipo", partido.codEquipo1);
            ViewBag.codEquipo2 = new SelectList(db.Equipo, "codEquipo", "nombreEquipo", partido.codEquipo2);
            ViewBag.codFecha = new SelectList(db.Fecha, "codFecha", "usuarioCreador", partido.codFecha);
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login", partido.usuarioCreador);
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login", partido.usuarioModificador);
            return View(partido);
        }

        // GET: Partido/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partido partido = await db.Partido.FindAsync(id);
            if (partido == null)
            {
                return HttpNotFound();
            }
            ViewBag.codEquipo1 = new SelectList(db.Equipo, "codEquipo", "nombreEquipo", partido.codEquipo1);
            ViewBag.codEquipo2 = new SelectList(db.Equipo, "codEquipo", "nombreEquipo", partido.codEquipo2);
            ViewBag.codFecha = new SelectList(db.Fecha, "codFecha", "usuarioCreador", partido.codFecha);
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login", partido.usuarioCreador);
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login", partido.usuarioModificador);
            return View(partido);
        }

        // POST: Partido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "codPartido,codFecha,codEquipo1,codEquipo2,golesEquipo1,golesEquipo2,usuarioCreador,usuarioModificador,fechaCreacion,fechaModificacion")] Partido partido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partido).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.codEquipo1 = new SelectList(db.Equipo, "codEquipo", "nombreEquipo", partido.codEquipo1);
            ViewBag.codEquipo2 = new SelectList(db.Equipo, "codEquipo", "nombreEquipo", partido.codEquipo2);
            ViewBag.codFecha = new SelectList(db.Fecha, "codFecha", "usuarioCreador", partido.codFecha);
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login", partido.usuarioCreador);
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login", partido.usuarioModificador);
            return View(partido);
        }

        // GET: Partido/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partido partido = await db.Partido.FindAsync(id);
            if (partido == null)
            {
                return HttpNotFound();
            }
            return View(partido);
        }

        // POST: Partido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            Partido partido = await db.Partido.FindAsync(id);
            db.Partido.Remove(partido);
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
