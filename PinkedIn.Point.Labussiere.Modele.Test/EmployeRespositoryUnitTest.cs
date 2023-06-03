using Microsoft.VisualStudio.TestTools.UnitTesting;
using PinkedIn.Point.Labussiere.BusinessLayer.Repositories;
using PinkedIn.Point.Labussiere.Modele.Entity;
using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace PinkedIn.Point.Labussiere.Modele.Test
{
    [TestClass]
    public class EmployeRespositoryUnitTest
    {
        [TestMethod]
        public void FindAll()
        {
            EmployeRepository repo = new EmployeRepository();
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
            EmployeRepository repo = new EmployeRepository();
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
    }
}
