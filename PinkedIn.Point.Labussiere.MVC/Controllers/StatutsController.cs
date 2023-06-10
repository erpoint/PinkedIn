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
    public class StatutsController : Controller
    {
        private StatutRepository repo = new StatutRepository();

        // GET: Statuts
        public ActionResult Index()
        {
            return View(repo.FindAll());
        }

        // GET: Statuts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statut statut = repo.FindEntity((int)id);
            if (statut == null)
            {
                return HttpNotFound();
            }
            return View(statut);
        }

        // GET: Statuts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Statuts/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Libelle")] Statut statut)
        {
            if (ModelState.IsValid)
            {
                repo.InsertEntity(statut);
                return RedirectToAction("Index");
            }

            return View(statut);
        }

        // GET: Statuts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statut statut = repo.FindEntity((int)id);
            if (statut == null)
            {
                return HttpNotFound();
            }
            return View(statut);
        }

        // POST: Statuts/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Libelle")] Statut statut)
        {
            if (ModelState.IsValid)
            {
                repo.UpdateEntity(statut);
                return RedirectToAction("Index");
            }
            return View(statut);
        }

        // GET: Statuts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statut statut = repo.FindEntity((int)id);
            if (statut == null)
            {
                return HttpNotFound();
            }
            return View(statut);
        }

        // POST: Statuts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Statut statut = repo.FindEntity((int)id);
            repo.DeleteEntity(statut);
            return RedirectToAction("Index");
        }
    }
}
