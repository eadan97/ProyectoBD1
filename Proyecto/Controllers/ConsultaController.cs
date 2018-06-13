using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class ConsultaController:Controller
    {
        private Entities db = new Entities();

        public async Task<ActionResult> ArbitrosTorneo()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ArbitrosTorneo(int codTorneo)
        {
            var list = db.ArbitrosTorneo(codTorneo);
            return View("ListarArbitrosTorneo", list);
        }

        public async Task<ActionResult> Goleadores()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Goleadores(int codEquipo1, int codEquipo2, DateTime fecha )
        {
            var list = db.Goleadores(codEquipo1,codEquipo2,fecha);
            return View("ListarGoleadores", list);
        }

        public async Task<ActionResult> Encuentros()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Encuentros(int codEquipo1, int codEquipo2, DateTime fecha)
        {
            var list = db.Encuentros(codEquipo1, codEquipo2, fecha);
            return View("ListarEncuentros", list);
        }

        public async Task<ActionResult> DatosJugador()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> DatosJugador(int codPersona)
        {
            var list = db.DatosJugador(codPersona);
            return View("ListarDatosJugador", list);
        }
        public async Task<ActionResult> DatosEntrenador()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> DatosEntrenador(int codPersona)
        {
            var list = db.DatosEntrenador(codPersona);
            return View("ListarDatosEntrenador", list);
        }

        public async Task<ActionResult> TablaGeneral()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> TablaGeneral(int codCompetencia, int codTemporada)
        {
            var list = db.TablaGeneral(codCompetencia, codTemporada);
            return View("ListarTablaGeneral", list);
        }

        /*public async Task<ActionResult> ListarArbitrosTorneo()
        {

        }*/

    }
}