using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PinkedIn.Point.Labussiere.BusinessLayer.Repositories;
using PinkedIn.Point.Labussiere.Modele;
using PinkedIn.Point.Labussiere.Modele.Entity;

namespace PinkedIn.Point.Labussiere.MVC.Controllers
{
    public class PostulationsController : Controller
    {
        private PostulationRepository postulationRepo = new PostulationRepository();
        private EmployeRepository employeRepository = new EmployeRepository();
        private OffreRepository offreRepository = new OffreRepository();

        // GET: Postulations
        public ActionResult Index()
        {
            var postulations = postulationRepo.FindAll();
            return View(postulations.ToList());
        }

        // GET: Postulations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Postulation postulation = postulationRepo.FindEntity((int)id);
            if (postulation == null)
            {
                return HttpNotFound();
            }
            return View(postulation);
        }

        // GET: Postulations/Create
        public ActionResult Create()
        {
            ViewBag.EmployeId = new SelectList(employeRepository.FindAll(), "Id", "Nom");
            ViewBag.OffreId = new SelectList(offreRepository.FindAll(), "Id", "Intitule");
            return View();
        }

        // POST: Postulations/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeId,OffreId,Date,Statut")] Postulation postulation)
        {
            if (ModelState.IsValid)
            {
                postulationRepo.InsertEntity(postulation);
                return RedirectToAction("Index");
            }

            ViewBag.EmployeId = new SelectList(employeRepository.FindAll(), "Id", "Nom", postulation.EmployeId);
            ViewBag.OffreId = new SelectList(offreRepository.FindAll(), "Id", "Intitule", postulation.OffreId);
            return View(postulation);
        }

        // GET: Postulations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Postulation postulation = postulationRepo.FindEntity((int)id);
            if (postulation == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeId = new SelectList(employeRepository.FindAll(), "Id", "Nom", postulation.EmployeId);
            ViewBag.OffreId = new SelectList(offreRepository.FindAll(), "Id", "Intitule", postulation.OffreId);
            return View(postulation);
        }

        // POST: Postulations/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeId,OffreId,Date,Statut")] Postulation postulation)
        {
            if (ModelState.IsValid)
            {
                postulationRepo.UpdateEntity(postulation);
                return RedirectToAction("Index");
            }
            ViewBag.EmployeId = new SelectList(employeRepository.FindAll(), "Id", "Nom", postulation.EmployeId);
            ViewBag.OffreId = new SelectList(offreRepository.FindAll(), "Id", "Intitule", postulation.OffreId);
            return View(postulation);
        }

        // GET: Postulations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Postulation postulation = postulationRepo.FindEntity((int)id);
            if (postulation == null)
            {
                return HttpNotFound();
            }
            return View(postulation);
        }

        // POST: Postulations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Postulation postulation = postulationRepo.FindEntity((int)id);
            postulationRepo.DeleteEntity(postulation);
            return RedirectToAction("Index");
        }
    }
}
