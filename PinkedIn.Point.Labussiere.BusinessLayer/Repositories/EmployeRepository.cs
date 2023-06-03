using PinkedIn.Point.Labussiere.Dal;
using PinkedIn.Point.Labussiere.Dal.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PinkedIn.Point.Labussiere.BusinessLayer.Repositories
{
    public class EmployeRepository : IRepository<Employe>
    {
        DbSet<Employe> employes;

        public EmployeRepository() 
        {
            employes = new ContextDA().Employes;
        }

        public Employe FindEmploye(int id)
        {
            return employes.Where(e => e.Id == id).FirstOrDefault();
        }

        public List<Employe> FindAll()
        {
            return employes.Where(e => true).ToList();
        }

        public void InsertEmploye(Employe employe)
        {
            employes.Add(employe);
        }

        public void DeleteEmploye(int id)
        {
            employes.Remove(FindEmploye(id));
        }

        public void UpdateEmploye(Employe employe)
        {
           DeleteEmploye(employe.Id);
           InsertEmploye(employe);
            
        }
    }
}
