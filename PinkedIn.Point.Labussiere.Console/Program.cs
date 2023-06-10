using PinkedIn.Point.Labussiere.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkedIn.Point.Labussiere.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContextDA contextDA = new ContextDA();
            contextDA.Employes.ToList();
        }
    }
}
