using MVCClinica.Models;
using MVCClinica.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCClinica.Controllers
{
    public class MedicoController : Controller
    {
        // GET: Medico
        public ActionResult Index()
        {
            //Traer todos los Medicos usando EF
            var medicos = AdminMedico.Listar();

            //el controller retorna una vista "Index" con la lista de medicos
            return View("Index", medicos);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Medico medico = new Medico();
            return View("Create", medico);
        }

        [HttpPost]
        public ActionResult Create(Medico medico)
        {
            if (ModelState.IsValid)
            {
                AdminMedico.Cargar(medico);
                return RedirectToAction("Index");
            }

            return View("Create", medico);
        }



        //Ver detalle de un médico por Id 
        public ActionResult Detail(int id)
        {
            Medico medico = AdminMedico.BuscarMedicoId(id);

            if (medico != null)
            {
                return View("Detail", medico);
            }
            else
            {
                return HttpNotFound();
            }

        }
        // /Opera/Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Medico medico = AdminMedico.BuscarMedicoId(id);

            if (medico != null)
            {
                return View("Edit", medico);
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Medico medico)
        {

            if (ModelState.IsValid)
            {
                AdminMedico.Modificar(medico);
                return RedirectToAction("Index");
            }

            return View("Edit", medico);

        }

        //GET /Opera/Delete/Id
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Medico medico = AdminMedico.BuscarMedicoId(id);

            if (medico != null)
            {
                return View("Delete", medico);
            }
            else
            {
                return HttpNotFound();
            }

        }

        // /Opera/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Medico medico = AdminMedico.BuscarMedicoId(id);

            if (medico != null)
            {
                AdminMedico.Eliminar(medico);
            }

            else
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index");

        }

        //GET: Traer médicos por Especialidad
        [HttpGet]
        public ActionResult TraerPorEspecialidad(string especialidad)
        {
            if (especialidad == null)
            {
                return RedirectToAction("Index");
            }

            return View("Index", AdminMedico.TraerPorEspecialidad(especialidad));

        }

    }
}


