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
        private readonly string CONNECTION_STRING = "PinkedInTestConnectionString";

        [TestCleanup]
        public void afterEach()
        {

        }

        [TestMethod]
        public void TestCtor()
        {
            EmployeRepository repo = new EmployeRepository(CONNECTION_STRING);
        }

        [TestMethod]
        public void FindAll()
        {
            EmployeRepository repo = new EmployeRepository(CONNECTION_STRING);
            Employe employe = new Employe()
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

            List<Employe> employes = repo.FindAll();
            Assert.IsNotNull(employes);
            Assert.AreEqual(1, employes.Count);
        }

        [TestMethod]    
        public void FindEntity()
        {
            EmployeRepository repo = new EmployeRepository(CONNECTION_STRING);
            int id = new Random().Next();
            Employe employe = new Employe()
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

            Employe foundEmploye = repo.FindEntity(id);
            Assert.IsNotNull(foundEmploye);
        }

        [TestMethod]
        public void InsertEntity()
        {
            EmployeRepository repo = new EmployeRepository(CONNECTION_STRING);
            int id = new Random().Next();
            Employe employe = new Employe()
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
            Assert.AreEqual(1, employes.Count);
        }

        [TestMethod]
        public void DeleteEntity()
        {
            EmployeRepository repo = new EmployeRepository(CONNECTION_STRING);
            int id = new Random().Next();
            Employe employe = new Employe()
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

            repo.DeleteEntity(employe);

            List<Employe> employes = repo.FindAll();

            Assert.AreEqual(0, employes.Count);
        }
    }
}
