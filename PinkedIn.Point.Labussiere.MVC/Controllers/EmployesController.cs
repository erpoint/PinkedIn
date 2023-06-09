﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PinkedIn.Point.Labussiere.BusinessLayer.Repositories;
using PinkedIn.Point.Labussiere.Modele;
using PinkedIn.Point.Labussiere.Modele.Entity;

namespace PinkedIn.Point.Labussiere.MVC.Controllers
{
    public class EmployesController : Controller
    {
        private EmployeRepository repo = new EmployeRepository();
        private ExperienceRepository experienceRepo = new ExperienceRepository();

        // GET: Employes
        public ActionResult Index()
        {
            return View(repo.FindAll());
        }

        //POST: Emploes
        [HttpPost]
        public ActionResult Index(string searchEmployee)
        {
            List<Employe> employes = new List<Employe>();
            if (!string.IsNullOrEmpty(searchEmployee))
            {
                employes = repo.FindByName(searchEmployee);
            }
            return View(employes);
        }

        // GET: Employes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employe employe = repo.FindEntity((int)id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // GET: Employes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employes/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Prenom,DateDeNaissance,Anciennete,Biographie")] Employe employe)
        {
            if (ModelState.IsValid)
            {
                repo.InsertEntity(employe);
                return RedirectToAction("Index");
            }

            return View(employe);
        }

        // GET: Employes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employe employe = repo.FindEntity((int)id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // POST: Employes/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Prenom,DateDeNaissance,Anciennete,Biographie")] Employe employe)
        {
            if (ModelState.IsValid)
            {
                repo.UpdateEntity(employe);
                return RedirectToAction("Index");
            }
            return View(employe);
        }

        // GET: Employes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employe employe = repo.FindEntity((int)id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // POST: Employes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employe employe = repo.FindEntity((int)id);
            repo.DeleteEntity(employe);
            return RedirectToAction("Index");
        }

        public ActionResult AddExperience(int id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employe employe = repo.FindEntity((int)id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeId = employe.Id;
            return View();
        }

        [HttpPost, ActionName("AddExperience")]
        [ValidateAntiForgeryToken]
        public ActionResult AddExperience([Bind(Include = "Id,EmployeId,Intitule,Date")] Experience experience)
        {
            experienceRepo.InsertEntity(experience);
            return RedirectToAction("Detail", new {id=experience.EmployeId});
        }
    }
}
