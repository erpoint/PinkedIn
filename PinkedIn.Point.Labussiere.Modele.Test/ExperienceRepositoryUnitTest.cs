using Microsoft.VisualStudio.TestTools.UnitTesting;
using PinkedIn.Point.Labussiere.BusinessLayer.Repositories;
using PinkedIn.Point.Labussiere.Modele.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkedIn.Point.Labussiere.Modele.Test
{
    [TestClass]
    public class ExperienceRepositoryUnitTest
    {
        private ExperienceRepository repo = new ExperienceRepository();
        private Experience experience;

        [TestInitialize]
        public void BeforeEach()
        {
            Employe employe = new Employe() { Id = new Random().Next() };
            experience = new Experience()
            {
                Id = new Random().Next(),
                EmployeId = employe.Id,
                Employe = employe,
                Intitule = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
            };

            repo.InsertEntity(experience);
        }

        [TestCleanup]
        public void AfterEach()
        {
            repo.DeleteAll();
        }

        [TestMethod]
        public void FindAll()
        {
            List<Experience> experiences = repo.FindAll();
            Experience experience = experiences[0];

            Assert.AreEqual(1, experiences.Count);

            Assert.AreEqual(experience.Id, this.experience.Id);
        }

        [TestMethod]
        public void FindEntity()
        {
            int id = this.experience.Id;
            Experience foundExperience = repo.FindEntity(id);

            Assert.AreEqual(experience.Id, foundExperience.Id);
            Assert.AreEqual(experience.EmployeId, foundExperience.EmployeId);
            Assert.AreEqual(experience.Employe.Id, foundExperience.Employe.Id);
            Assert.AreEqual(experience.Intitule, foundExperience.Intitule);
            Assert.AreEqual(experience.Date, foundExperience.Date);
        }

        [TestMethod]
        public void FindEntityNotExisting()
        {
            int id = new Random().Next();
            Experience foundExperience = repo.FindEntity(id);

            Assert.IsNull(foundExperience);
        }

        [TestMethod]
        public void InsertEntity()
        {
            int id = new Random().Next();
            Employe employe = new Employe() { Id = new Random().Next() };
            Experience newExperience = new Experience()
            {
                Id = id,
                EmployeId = employe.Id,
                Employe = employe,
                Intitule = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
            };
            repo.InsertEntity(newExperience);

            List<Experience> experiences = repo.FindAll();
            Experience addedExperience = experiences[1];

            Assert.AreEqual(2, experiences.Count);
            Assert.AreEqual(id, addedExperience.Id);
        }

        [TestMethod]
        public void InsertEntityAlreadyExist()
        {
            int id = experience.Id;
            Employe employe = new Employe() { Id = new Random().Next() };
            Experience newExperience = new Experience()
            {
                Id = id,
                EmployeId = employe.Id,
                Employe = employe,
                Intitule = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
            };
            repo.InsertEntity(newExperience);

            List<Experience> experiences = repo.FindAll();

            Assert.AreNotEqual(2, experiences.Count);
        }

        [TestMethod]
        public void DeleteEntity()
        {
            repo.DeleteEntity(experience);

            List<Experience> experiences = repo.FindAll();

            Assert.AreEqual(0, experiences.Count);
        }

        [TestMethod]
        public void DeleteEntityNotExisiting()
        {
            Employe employe = new Employe() { Id = new Random().Next() };
            Experience newExperience = new Experience()
            {
                Id = new Random().Next(),
                EmployeId = employe.Id,
                Employe = employe,
                Intitule = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
            };
            repo.DeleteEntity(newExperience);

            List<Experience> experiences = repo.FindAll();

            Assert.AreNotEqual(0, experiences.Count);
        }

        [TestMethod]
        public void UpdateEntity()
        {
            string newIntitule = Guid.NewGuid().ToString();
            Experience experience = new Experience()
            {
                Id = this.experience.Id,
                EmployeId = this.experience.EmployeId,
                Employe = this.experience.Employe,
                Intitule = newIntitule,
                Date = this.experience.Date,
            };
            repo.UpdateEntity(experience);

            Experience updatedExperience = repo.FindEntity(this.experience.Id);

            Assert.AreEqual(experience.Intitule, updatedExperience.Intitule);
        }

        [TestMethod]
        public void UpdateEntityNotExisting()
        {
            string newIntitule = Guid.NewGuid().ToString();
            Experience experience = new Experience()
            {
                Id = new Random().Next(),
                EmployeId = this.experience.EmployeId,
                Employe = this.experience.Employe,
                Intitule = newIntitule,
                Date = this.experience.Date,
            };
            repo.UpdateEntity(experience);

            Experience updatedExperience = repo.FindEntity(this.experience.Id);

            Assert.IsNull(updatedExperience);
        }

        [TestMethod]
        public void DeleteAll()
        {
            repo.DeleteAll();

            List<Experience> experiences = repo.FindAll();

            Assert.AreEqual(0, experiences.Count);
        }
    }
}
