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
    public class AlineacionPartidoController : Controller
    {
        private Entities db = new Entities();

        // GET: AlineacionPartido
        public async Task<ActionResult> Index()
        {
            var alineacionPartido = db.AlineacionPartido.Include(a => a.Partido).Include(a => a.Jugador).Include(a => a.Equipo).Include(a => a.Usuario).Include(a => a.Usuario1);
            return View(await alineacionPartido.ToListAsync());
        }

        // GET: AlineacionPartido/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlineacionPartido alineacionPartido = await db.AlineacionPartido.FindAsync(id);
            if (alineacionPartido == null)
            {
                return HttpNotFound();
            }
            return View(alineacionPartido);
        }

        // GET: AlineacionPartido/Create
        public ActionResult Create()
        {
            ViewBag.codPartido = new SelectList(db.Partido, "codPartido", "usuarioCreador");
            ViewBag.codPersona = new SelectList(db.Jugador, "codPersona", "usuarioCreador");
            ViewBag.codEquipo = new SelectList(db.Equipo, "codEquipo", "nombreEquipo");
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login");
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login");
            return View();
        }

        // POST: AlineacionPartido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "codPartido,codPersona,codEquipo,estado,usuarioCreador,usuarioModificador,fechaCreacion,fechaModificacion")] AlineacionPartido alineacionPartido)
        {
            if (ModelState.IsValid)
            {
                db.AlineacionPartido.Add(alineacionPartido);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.codPartido = new SelectList(db.Partido, "codPartido", "usuarioCreador", alineacionPartido.codPartido);
            ViewBag.codPersona = new SelectList(db.Jugador, "codPersona", "usuarioCreador", alineacionPartido.codPersona);
            ViewBag.codEquipo = new SelectList(db.Equipo, "codEquipo", "nombreEquipo", alineacionPartido.codEquipo);
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login", alineacionPartido.usuarioCreador);
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login", alineacionPartido.usuarioModificador);
            return View(alineacionPartido);
        }

        // GET: AlineacionPartido/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlineacionPartido alineacionPartido = await db.AlineacionPartido.FindAsync(id);
            if (alineacionPartido == null)
            {
                return HttpNotFound();
            }
            ViewBag.codPartido = new SelectList(db.Partido, "codPartido", "usuarioCreador", alineacionPartido.codPartido);
            ViewBag.codPersona = new SelectList(db.Jugador, "codPersona", "usuarioCreador", alineacionPartido.codPersona);
            ViewBag.codEquipo = new SelectList(db.Equipo, "codEquipo", "nombreEquipo", alineacionPartido.codEquipo);
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login", alineacionPartido.usuarioCreador);
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login", alineacionPartido.usuarioModificador);
            return View(alineacionPartido);
        }

        // POST: AlineacionPartido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "codPartido,codPersona,codEquipo,estado,usuarioCreador,usuarioModificador,fechaCreacion,fechaModificacion")] AlineacionPartido alineacionPartido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alineacionPartido).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.codPartido = new SelectList(db.Partido, "codPartido", "usuarioCreador", alineacionPartido.codPartido);
            ViewBag.codPersona = new SelectList(db.Jugador, "codPersona", "usuarioCreador", alineacionPartido.codPersona);
            ViewBag.codEquipo = new SelectList(db.Equipo, "codEquipo", "nombreEquipo", alineacionPartido.codEquipo);
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login", alineacionPartido.usuarioCreador);
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login", alineacionPartido.usuarioModificador);
            return View(alineacionPartido);
        }

        // GET: AlineacionPartido/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlineacionPartido alineacionPartido = await db.AlineacionPartido.FindAsync(id);
            if (alineacionPartido == null)
            {
                return HttpNotFound();
            }
            return View(alineacionPartido);
        }

        // POST: AlineacionPartido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            AlineacionPartido alineacionPartido = await db.AlineacionPartido.FindAsync(id);
            db.AlineacionPartido.Remove(alineacionPartido);
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
