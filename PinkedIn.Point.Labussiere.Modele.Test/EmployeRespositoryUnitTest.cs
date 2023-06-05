using Microsoft.VisualStudio.TestTools.UnitTesting;
using PinkedIn.Point.Labussiere.BusinessLayer.Repositories;
using PinkedIn.Point.Labussiere.Modele.Entity;
using System;
using System.Collections.Generic;

namespace PinkedIn.Point.Labussiere.Modele.Test
{
    [TestClass]
    public class EmployeRespositoryUnitTest
    {
        private EmployeRepository repo = new EmployeRepository();
        private Employe employe;

        [TestInitialize]
        public void BeforeEach()
        {
            employe = new Employe()
            {
                Id = new Random().Next(),
                Nom = Guid.NewGuid().ToString(),
                Prenom = Guid.NewGuid().ToString(),
                DateDeNaissance = DateTime.Now,
                Anciennete = new Random().Next(),
                Biographie = Guid.NewGuid().ToString(),
                Formations = new List<Formation>(),
                Experiences = new List<Experience>(),
                Postulations = new List<Postulation>()
            };
            repo.InsertEntity(employe);
        }

        [TestCleanup]
        public void AfterEach()
        {
            repo.DeleteAll();
        }

        [TestMethod]
        public void FindAll()
        {
            List<Employe> employes = repo.FindAll();
            Employe employe = employes[0];

            Assert.AreEqual(1, employes.Count);

            Assert.AreEqual(employe.Id, this.employe.Id);
        }

        [TestMethod]    
        public void FindEntity()
        {
            int id = this.employe.Id;
            Employe foundEmploye = repo.FindEntity(id);

            Assert.AreEqual(employe.Id, foundEmploye.Id);
            Assert.AreEqual(employe.Nom, foundEmploye.Nom);
            Assert.AreEqual(employe.Prenom, foundEmploye.Prenom);
            Assert.AreEqual(employe.DateDeNaissance, foundEmploye.DateDeNaissance);
            Assert.AreEqual(employe.Anciennete, foundEmploye.Anciennete);
            Assert.AreEqual(employe.Biographie, foundEmploye.Biographie);
            CollectionAssert.AreEquivalent(employe.Formations, foundEmploye.Formations);
            CollectionAssert.AreEquivalent(employe.Experiences, foundEmploye.Experiences);
            CollectionAssert.AreEquivalent(employe.Postulations, foundEmploye.Postulations);
        }

        [TestMethod]
        public void FindEntityNotExisting()
        {
            int id = new Random().Next();
            Employe foundEmploye = repo.FindEntity(id);

            Assert.IsNull(foundEmploye);
        }

        [TestMethod]
        public void InsertEntity()
        {
            int id = new Random().Next();
            Employe newEmploye = new Employe()
            {
                Id = id,
                Nom = Guid.NewGuid().ToString(),
                Prenom = Guid.NewGuid().ToString(),
                DateDeNaissance = DateTime.Now,
                Anciennete = new Random().Next(),
                Biographie = Guid.NewGuid().ToString(),
                Formations = new List<Formation>(),
                Experiences = new List<Experience>(),
                Postulations = new List<Postulation>()
            };
            repo.InsertEntity(newEmploye);

            List<Employe> employes = repo.FindAll();
            Employe addedEmploye = employes[1];

            Assert.AreEqual(2, employes.Count);
            Assert.AreEqual(id,addedEmploye.Id);
        }

        [TestMethod]
        public void InsertEntityAlreadyExist()
        {
            int id = employe.Id;
            Employe newEmploye = new Employe()
            {
                Id = id,
                Nom = Guid.NewGuid().ToString(),
                Prenom = Guid.NewGuid().ToString(),
                DateDeNaissance = DateTime.Now,
                Anciennete = new Random().Next(),
                Biographie = Guid.NewGuid().ToString(),
                Formations = new List<Formation>(),
                Experiences = new List<Experience>(),
                Postulations = new List<Postulation>()
            };
            repo.InsertEntity(employe);

            List<Employe> employes = repo.FindAll();

            Assert.AreNotEqual(2, employes.Count);
        }

        [TestMethod]
        public void DeleteEntity()
        {
            repo.DeleteEntity(employe);

            List<Employe> employes = repo.FindAll();

            Assert.AreEqual(0, employes.Count);
        }

        [TestMethod]
        public void DeleteEntityNotExisiting()
        {
            Employe newEmploye = new Employe()
            {
                Id = new Random().Next(),
                Nom = Guid.NewGuid().ToString(),
                Prenom = Guid.NewGuid().ToString(),
                DateDeNaissance = DateTime.Now,
                Anciennete = new Random().Next(),
                Biographie = Guid.NewGuid().ToString(),
                Formations = new List<Formation>(),
                Experiences = new List<Experience>(),
                Postulations = new List<Postulation>()
            };
            repo.DeleteEntity(newEmploye);

            List<Employe> employes = repo.FindAll();

            Assert.AreNotEqual(0, employes.Count);
        }

        [TestMethod]
        public void UpdateEntity()
        {
            string newNom = Guid.NewGuid().ToString();
            Employe employe = new Employe()
            {
                Id = this.employe.Id,
                Nom = newNom,
                Prenom = this.employe.Prenom,
                DateDeNaissance = this.employe.DateDeNaissance,
                Anciennete = this.employe.Anciennete,
                Biographie = this.employe.Biographie,
                Formations = this.employe.Formations,
                Experiences = this.employe.Experiences,
                Postulations = this.employe.Postulations,
            };
            repo.UpdateEntity(employe);

            Employe updatedEmploye = repo.FindEntity(this.employe.Id);

            Assert.AreEqual(employe.Nom,updatedEmploye.Nom);
        }

        [TestMethod]
        public void UpdateEntityNotExisting()
        {
            string newNom = Guid.NewGuid().ToString();
            Employe employe = new Employe()
            {
                Id = new Random().Next(),
                Nom = newNom,
                Prenom = this.employe.Prenom,
                DateDeNaissance = this.employe.DateDeNaissance,
                Anciennete = this.employe.Anciennete,
                Biographie = this.employe.Biographie,
                Formations = this.employe.Formations,
                Experiences = this.employe.Experiences,
                Postulations = this.employe.Postulations,
            };
            repo.UpdateEntity(employe);

            Employe updatedEmploye = repo.FindEntity(this.employe.Id);

            Assert.IsNull(updatedEmploye);
        }

        [TestMethod]
        public void DeleteAll()
        {
            repo.DeleteAll();

            List<Employe> employes = repo.FindAll();

            Assert.AreEqual (0, employes.Count);
        }
    }
}
