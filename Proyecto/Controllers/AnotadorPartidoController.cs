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
    public class AnotadorPartidoController : Controller
    {
        private Entities db = new Entities();

        // GET: AnotadorPartido
        public async Task<ActionResult> Index()
        {
            var anotadorPartido = db.AnotadorPartido.Include(a => a.Partido).Include(a => a.Jugador).Include(a => a.Usuario).Include(a => a.Usuario1);
            return View(await anotadorPartido.ToListAsync());
        }

        // GET: AnotadorPartido/Details/5
        public async Task<ActionResult> Details(decimal codPartido, decimal codPersona, decimal minuto)
        {
            if (codPersona == null || codPartido==null||minuto==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnotadorPartido anotadorPartido = await db.AnotadorPartido.FindAsync(codPartido,codPersona,minuto);
            if (anotadorPartido == null)
            {
                return HttpNotFound();
            }
            return View(anotadorPartido);
        }

        // GET: AnotadorPartido/Create
        public ActionResult Create()
        {
            ViewBag.codPartido = new SelectList(db.Partido, "codPartido", "codPartido");
            ViewBag.codPersona = new SelectList(db.Persona.Where(user => db.Jugador.Select(f => f.codPersona).Contains(user.codPersona)), "codPersona", "nbrPersona");
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login");
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login");
            return View();
        }

        // POST: AnotadorPartido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "codPartido,codPersona,minuto,video,usuarioCreador,usuarioModificador,fechaCreacion,fechaModificacion")] AnotadorPartido anotadorPartido)
        {
            if (ModelState.IsValid)
            {
                db.AnotadorPartido.Add(anotadorPartido);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.codPartido = new SelectList(db.Partido, "codPartido", "codPartido", anotadorPartido.codPartido);
            ViewBag.codPersona = new SelectList(db.Persona.Where(user => db.Jugador.Select(f => f.codPersona).Contains(user.codPersona)), "codPersona", "nbrPersona", anotadorPartido.codPersona);
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login", anotadorPartido.usuarioCreador);
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login", anotadorPartido.usuarioModificador);
            return View(anotadorPartido);
        }

        // GET: AnotadorPartido/Edit/5
        public async Task<ActionResult> Edit(decimal codPartido, decimal codPersona, decimal minuto)
        {
            if (codPersona == null || codPartido == null || minuto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnotadorPartido anotadorPartido = await db.AnotadorPartido.FindAsync(codPartido, codPersona, minuto);
            if (anotadorPartido == null)
            {
                return HttpNotFound();
            }
            ViewBag.codPartido = new SelectList(db.Partido, "codPartido", "codPartido", anotadorPartido.codPartido);
            ViewBag.codPersona = new SelectList(db.Persona.Where(user => db.Jugador.Select(f => f.codPersona).Contains(user.codPersona)), "codPersona", "nbrPersona", anotadorPartido.codPersona);
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login", anotadorPartido.usuarioCreador);
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login", anotadorPartido.usuarioModificador);
            return View(anotadorPartido);
        }

        // POST: AnotadorPartido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "codPartido,codPersona,minuto,video,usuarioCreador,usuarioModificador,fechaCreacion,fechaModificacion")] AnotadorPartido anotadorPartido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anotadorPartido).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.codPartido = new SelectList(db.Partido, "codPartido", "codPartido", anotadorPartido.codPartido);
            ViewBag.codPersona = new SelectList(db.Persona.Where(user => db.Jugador.Select(f => f.codPersona).Contains(user.codPersona)), "codPersona", "nbrPersona", anotadorPartido.codPersona);
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login", anotadorPartido.usuarioCreador);
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login", anotadorPartido.usuarioModificador);
            return View(anotadorPartido);
        }

        // GET: AnotadorPartido/Delete/5
        public async Task<ActionResult> Delete(decimal codPartido, decimal codPersona, decimal minuto)
        {
            if (codPersona == null || codPartido == null || minuto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnotadorPartido anotadorPartido = await db.AnotadorPartido.FindAsync(codPartido, codPersona, minuto);
            if (anotadorPartido == null)
            {
                return HttpNotFound();
            }
            return View(anotadorPartido);
        }

        // POST: AnotadorPartido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal codPartido, decimal codPersona, decimal minuto)
        {
            AnotadorPartido anotadorPartido = await db.AnotadorPartido.FindAsync(codPartido, codPersona, minuto);
            db.AnotadorPartido.Remove(anotadorPartido);
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
