using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using PinkedIn.Point.Labussiere.BusinessLayer.Repositories;
using PinkedIn.Point.Labussiere.Modele.Entity;

namespace PinkedIn.Point.Labussiere.MVC.Controllers
{
    public class OffresController : Controller
    {
        private OffreRepository offreRepo = new OffreRepository();
        private StatutRepository statutRepo = new StatutRepository();
        private PostulationRepository postulationRepo = new PostulationRepository();
        private EmployeRepository employeRepo = new EmployeRepository();    

        // GET: Offres
        public ActionResult Index()
        {
            List<Offre> offres = offreRepo.FindAll();
            return View(offres);
        }

        // GET: Offres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offre offre = offreRepo.FindEntity((int)id);
            if (offre == null)
            {
                return HttpNotFound();
            }
            return View(offre);
        }

        // GET: Offres/Create
        public ActionResult Create()
        {
            ViewBag.StatutId = new SelectList(statutRepo.FindAll(), "Id", "Libelle");
            return View();
        }

        // POST: Offres/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Intitule,Date,Salaire,Description,StatutId,Responsable")] Offre offre)
        {
            if (ModelState.IsValid)
            {
                offreRepo.InsertEntity(offre);
                return RedirectToAction("Index");
            }

            ViewBag.StatutId = new SelectList(statutRepo.FindAll(), "Id", "Libelle", offre.StatutId);
            return View(offre);
        }

        // GET: Offres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offre offre = offreRepo.FindEntity((int)id);
            if (offre == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatutId = new SelectList(statutRepo.FindAll(), "Id", "Libelle", offre.StatutId);
            return View(offre);
        }

        // POST: Offres/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Intitule,Date,Salaire,Description,StatutId,Responsable")] Offre offre)
        {
            if (ModelState.IsValid)
            {
                offreRepo.UpdateEntity(offre);
                return RedirectToAction("Index");
            }
            ViewBag.StatutId = new SelectList(statutRepo.FindAll(), "Id", "Libelle", offre.StatutId);
            return View(offre);
        }

        // GET: Offres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offre offre = offreRepo.FindEntity((int)id);
            if (offre == null)
            {
                return HttpNotFound();
            }
            return View(offre);
        }

        // POST: Offres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Offre offre = offreRepo.FindEntity((int)id);
            offreRepo.DeleteEntity(offre);
            return RedirectToAction("Index");
        }

        public ActionResult Apply(int? offreId, int? employeId)
        {
            if (offreId == null && employeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offre offre = offreRepo.FindEntity((int)offreId);
            if (offre == null)
            {
                return HttpNotFound();
            }
            return View(offre);
        }

        [HttpPost, ActionName("Apply")]
        [ValidateAntiForgeryToken]
        public ActionResult Apply(int offreId, int employeId)
        {
            Postulation postulation = new Postulation()
            {
                OffreId = offreId,
                EmployeId = employeId,
                Date = DateTime.Now,
                Statut = "En attente"
            };
            postulationRepo.InsertEntity(postulation);
            return RedirectToAction("Index");
            
        }
    }
}
