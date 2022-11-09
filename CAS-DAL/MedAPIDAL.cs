using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS_DAL
{
    public class MedAPIDAL
    {
        MyContext c = null;
        public MedAPIDAL()
        {
            c = new MyContext();
        }
        public List<Medicine> GetAllMeds()
        {
            return c.Medicines.ToList();
        }
        public Medicine GetMedByID(int id)
        {
            List<Medicine> s = c.Medicines.ToList();
            Medicine r = s.Find(pr => pr.MedicineId == id);
            return r;
        }
    }
}
