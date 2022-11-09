using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CAS_DAL;
using CAS_DAL.Repositories;
using Clinical_Automation_System.ViewModel;

namespace Clinical_Automation_System.Controllers
{
    public class MedicineAPIController : ApiController
    {
        // GET api/<controller>
        MedAPIDAL ms = null;
        public MedicineAPIController()
        {
            ms = new MedAPIDAL();
        }
        List<MedicineViewModel> s = new List<MedicineViewModel>();
        [Route("GetAllMedicines")]
        public IEnumerable<MedicineViewModel> Get()
        {
            List<Medicine> c = ms.GetAllMeds();
            foreach (var item in c)
            {
                MedicineViewModel v = new MedicineViewModel();
                v.MedicineId = item.MedicineId;
                v.Name = item.Name;
                v.Price = (float)item.Price;
                v.Stock = item.Stock;
                v.IsAvailable = item.IsAvailable;
                v.Tax = (float)item.Tax;
                s.Add(v);
            }
            return s;
        }

        // GET api/<controller>/5
        [Route("GetMedicinesByID")]
        public MedicineViewModel Get(int id)
        {
            MedicineViewModel r = new MedicineViewModel();
            Medicine p = new Medicine();
            p = ms.GetMedByID(id);

            r.MedicineId = Convert.ToInt32(p.MedicineId);
            r.Name=p.Name.ToString();
            return r;
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}