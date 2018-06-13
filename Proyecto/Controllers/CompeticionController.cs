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
    public class CompeticionController : Controller
    {
        private Entities db = new Entities();

        // GET: Competicion
        public async Task<ActionResult> Index()
        {
            var competicion = db.Competicion.Include(c => c.TipoCompeticion).Include(c => c.Usuario).Include(c => c.Usuario1);
            return View(await competicion.ToListAsync());
        }

        // GET: Competicion/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competicion competicion = await db.Competicion.FindAsync(id);
            if (competicion == null)
            {
                return HttpNotFound();
            }
            return View(competicion);
        }

        // GET: Competicion/Create
        public ActionResult Create()
        {
            ViewBag.codTipoCompeticion = new SelectList(db.TipoCompeticion, "codTipoCompeticion", "nbrTipoCompeticion");
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login");
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login");
            return View();
        }

        // POST: Competicion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "codCompeticion,nbrCompeticion,codTipoCompeticion,usuarioCreador,usuarioModificador,fechaCreacion,fechaModificacion")] Competicion competicion)
        {
            if (ModelState.IsValid)
            {
                db.Competicion.Add(competicion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.codTipoCompeticion = new SelectList(db.TipoCompeticion, "codTipoCompeticion", "nbrTipoCompeticion", competicion.codTipoCompeticion);
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login", competicion.usuarioModificador);
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login", competicion.usuarioCreador);
            return View(competicion);
        }

        // GET: Competicion/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competicion competicion = await db.Competicion.FindAsync(id);
            if (competicion == null)
            {
                return HttpNotFound();
            }
            ViewBag.codTipoCompeticion = new SelectList(db.TipoCompeticion, "codTipoCompeticion", "nbrTipoCompeticion", competicion.codTipoCompeticion);
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login", competicion.usuarioModificador);
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login", competicion.usuarioCreador);
            return View(competicion);
        }

        // POST: Competicion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "codCompeticion,nbrCompeticion,codTipoCompeticion,usuarioCreador,usuarioModificador,fechaCreacion,fechaModificacion")] Competicion competicion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competicion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.codTipoCompeticion = new SelectList(db.TipoCompeticion, "codTipoCompeticion", "nbrTipoCompeticion", competicion.codTipoCompeticion);
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login", competicion.usuarioModificador);
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login", competicion.usuarioCreador);
            return View(competicion);
        }

        // GET: Competicion/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competicion competicion = await db.Competicion.FindAsync(id);
            if (competicion == null)
            {
                return HttpNotFound();
            }
            return View(competicion);
        }

        // POST: Competicion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            Competicion competicion = await db.Competicion.FindAsync(id);
            db.Competicion.Remove(competicion);
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
