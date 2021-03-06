﻿using System;
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
    public class CambioPartidoController : Controller
    {
        private Entities db = new Entities();

        // GET: CambioPartido
        public async Task<ActionResult> Index()
        {
            var cambioPartido = db.CambioPartido.Include(c => c.Partido).Include(c => c.Jugador).Include(c => c.Jugador1).Include(c => c.Usuario).Include(c => c.Usuario1);
            return View(await cambioPartido.ToListAsync());
        }

        // GET: CambioPartido/Details/5
        public async Task<ActionResult> Details(decimal codPartido, decimal codPersona)
        {
            if (codPartido == null || codPersona==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CambioPartido cambioPartido = await db.CambioPartido.FindAsync(codPartido,codPersona);
            if (cambioPartido == null)
            {
                return HttpNotFound();
            }
            return View(cambioPartido);
        }

        // GET: CambioPartido/Create
        public ActionResult Create()
        {
            ViewBag.codPartido = new SelectList(db.Partido, "codPartido", "codPartido");
            ViewBag.jugadorSale = new SelectList(db.Persona.Where(user => db.Jugador.Select(f => f.codPersona).Contains(user.codPersona)), "codPersona", "nbrPersona");
            ViewBag.jugadorEntra = new SelectList(db.Persona.Where(user => db.Jugador.Select(f => f.codPersona).Contains(user.codPersona)), "codPersona", "nbrPersona");
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login");
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login");
            return View();
        }

        // POST: CambioPartido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "codPartido,jugadorSale,jugadorEntra,minuto,usuarioCreador,usuarioModificador,fechaCreacion,fechaModificacion")] CambioPartido cambioPartido)
        {
            if (ModelState.IsValid)
            {
                db.CambioPartido.Add(cambioPartido);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.codPartido = new SelectList(db.Partido, "codPartido", "codPartido", cambioPartido.codPartido);
            ViewBag.jugadorSale = new SelectList(db.Persona.Where(user => db.Jugador.Select(f => f.codPersona).Contains(user.codPersona)), "codPersona", "nbrPersona", cambioPartido.jugadorSale);
            ViewBag.jugadorEntra = new SelectList(db.Persona.Where(user => db.Jugador.Select(f => f.codPersona).Contains(user.codPersona)), "codPersona", "nbrPersona", cambioPartido.jugadorEntra);
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login", cambioPartido.usuarioModificador);
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login", cambioPartido.usuarioCreador);
            return View(cambioPartido);
        }

        // GET: CambioPartido/Edit/5
        public async Task<ActionResult> Edit(decimal codPartido, decimal codPersona)
        {
            if (codPartido == null||codPersona==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CambioPartido cambioPartido = await db.CambioPartido.FindAsync(codPartido,codPersona);
            if (cambioPartido == null)
            {
                return HttpNotFound();
            }
            ViewBag.codPartido = new SelectList(db.Partido, "codPartido", "codPartido", cambioPartido.codPartido);
            ViewBag.jugadorSale = new SelectList(db.Persona.Where(user => db.Jugador.Select(f => f.codPersona).Contains(user.codPersona)), "codPersona", "nbrPersona", cambioPartido.jugadorSale);
            ViewBag.jugadorEntra = new SelectList(db.Persona.Where(user => db.Jugador.Select(f => f.codPersona).Contains(user.codPersona)), "codPersona", "nbrPersona", cambioPartido.jugadorEntra);
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login", cambioPartido.usuarioModificador);
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login", cambioPartido.usuarioCreador);
            return View(cambioPartido);
        }

        // POST: CambioPartido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "codPartido,jugadorSale,jugadorEntra,minuto,usuarioCreador,usuarioModificador,fechaCreacion,fechaModificacion")] CambioPartido cambioPartido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cambioPartido).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.codPartido = new SelectList(db.Partido, "codPartido", "codPartido", cambioPartido.codPartido);
            ViewBag.jugadorSale = new SelectList(db.Persona.Where(user => db.Jugador.Select(f => f.codPersona).Contains(user.codPersona)), "codPersona", "nbrPersona", cambioPartido.jugadorSale);
            ViewBag.jugadorEntra = new SelectList(db.Persona.Where(user => db.Jugador.Select(f => f.codPersona).Contains(user.codPersona)), "codPersona", "nbrPersona", cambioPartido.jugadorEntra);
            ViewBag.usuarioModificador = new SelectList(db.Usuario, "login", "login", cambioPartido.usuarioModificador);
            ViewBag.usuarioCreador = new SelectList(db.Usuario, "login", "login", cambioPartido.usuarioCreador);
            return View(cambioPartido);
        }

        // GET: CambioPartido/Delete/5
        public async Task<ActionResult> Delete(decimal codPartido, decimal codPersona)
        {
            if (codPartido == null || codPersona==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CambioPartido cambioPartido = await db.CambioPartido.FindAsync(codPartido,codPersona);
            if (cambioPartido == null)
            {
                return HttpNotFound();
            }
            return View(cambioPartido);
        }

        // POST: CambioPartido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal codPartido, decimal codPersona)
        {
            CambioPartido cambioPartido = await db.CambioPartido.FindAsync(codPartido, codPersona);
            db.CambioPartido.Remove(cambioPartido);
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
