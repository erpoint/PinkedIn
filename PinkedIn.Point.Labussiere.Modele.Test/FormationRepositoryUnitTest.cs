using Microsoft.VisualStudio.TestTools.UnitTesting;
using PinkedIn.Point.Labussiere.BusinessLayer.Repositories;
using PinkedIn.Point.Labussiere.Modele.Entity;
using System;
using System.Collections.Generic;

namespace PinkedIn.Point.Labussiere.Modele.Test
{
    [TestClass]
    public class FormationRepositoryUnitTest
    {
        private FormationRepository repo;
        private Formation formation;

        [TestInitialize]
        public void BeforeEach()
        {
            Employe employe = new Employe() { Id = new Random().Next() };
            formation = new Formation()
            {
                Id = new Random().Next(),
                EmployeId = employe.Id,
                Employe = employe,
                Intitule = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
            };

            repo.InsertEntity(formation);
        }

        [TestCleanup]
        public void AfterEach()
        {
            repo.DeleteAll();
        }

        [TestMethod]
        public void FindAll()
        {
            List<Formation> formations = repo.FindAll();
            Formation formation = formations[0];

            Assert.AreEqual(1, formations.Count);

            Assert.AreEqual(formation.Id, this.formation.Id);
        }

        [TestMethod]
        public void FindEntity()
        {
            int id = this.formation.Id;
            Formation foundExperience = repo.FindEntity(id);

            Assert.AreEqual(formation.Id, foundExperience.Id);
            Assert.AreEqual(formation.EmployeId, foundExperience.EmployeId);
            Assert.AreEqual(formation.Employe.Id, foundExperience.Employe.Id);
            Assert.AreEqual(formation.Intitule, foundExperience.Intitule);
            Assert.AreEqual(formation.Date, foundExperience.Date);
        }

        [TestMethod]
        public void FindEntityNotExisting()
        {
            int id = new Random().Next();
            Formation foundExperience = repo.FindEntity(id);

            Assert.IsNull(foundExperience);
        }

        [TestMethod]
        public void InsertEntity()
        {
            int id = new Random().Next();
            Employe employe = new Employe() { Id = new Random().Next() };
            Formation newExperience = new Formation()
            {
                Id = id,
                EmployeId = employe.Id,
                Employe = employe,
                Intitule = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
            };
            repo.InsertEntity(newExperience);

            List<Formation> formations = repo.FindAll();
            Formation addedExperience = formations[1];

            Assert.AreEqual(2, formations.Count);
            Assert.AreEqual(id, addedExperience.Id);
        }

        [TestMethod]
        public void InsertEntityAlreadyExist()
        {
            int id = formation.Id;
            Employe employe = new Employe() { Id = new Random().Next() };
            Formation newExperience = new Formation()
            {
                Id = id,
                EmployeId = employe.Id,
                Employe = employe,
                Intitule = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
            };
            repo.InsertEntity(newExperience);

            List<Formation> formations = repo.FindAll();

            Assert.AreNotEqual(2, formations.Count);
        }

        [TestMethod]
        public void DeleteEntity()
        {
            repo.DeleteEntity(formation);

            List<Formation> formations = repo.FindAll();

            Assert.AreEqual(0, formations.Count);
        }

        [TestMethod]
        public void DeleteEntityNotExisiting()
        {
            Employe employe = new Employe() { Id = new Random().Next() };
            Formation newExperience = new Formation()
            {
                Id = new Random().Next(),
                EmployeId = employe.Id,
                Employe = employe,
                Intitule = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
            };
            repo.DeleteEntity(newExperience);

            List<Formation> formations = repo.FindAll();

            Assert.AreNotEqual(0, formations.Count);
        }

        [TestMethod]
        public void UpdateEntity()
        {
            string newIntitule = Guid.NewGuid().ToString();
            Formation formation = new Formation()
            {
                Id = this.formation.Id,
                EmployeId = this.formation.EmployeId,
                Employe = this.formation.Employe,
                Intitule = newIntitule,
                Date = this.formation.Date,
            };
            repo.UpdateEntity(formation);

            Formation updatedExperience = repo.FindEntity(this.formation.Id);

            Assert.AreEqual(formation.Intitule, updatedExperience.Intitule);
        }

        [TestMethod]
        public void UpdateEntityNotExisting()
        {
            string newIntitule = Guid.NewGuid().ToString();
            Formation formation = new Formation()
            {
                Id = new Random().Next(),
                EmployeId = this.formation.EmployeId,
                Employe = this.formation.Employe,
                Intitule = newIntitule,
                Date = this.formation.Date,
            };
            repo.UpdateEntity(formation);

            Formation updatedExperience = repo.FindEntity(this.formation.Id);

            Assert.IsNull(updatedExperience);
        }

        [TestMethod]
        public void DeleteAll()
        {
            repo.DeleteAll();

            List<Formation> formations = repo.FindAll();

            Assert.AreEqual(0, formations.Count);
        }
    }
}
