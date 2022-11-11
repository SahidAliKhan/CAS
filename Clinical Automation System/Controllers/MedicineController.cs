using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CAS_BAL;
using Clinical_Automation_System.ViewModel;

namespace Clinical_Automation_System.Controllers
{
    public class MedicineController : ApiController
    {
        MedicineDAL ms = null;
        public MedicineController()
        {
            ms = new MedicineDAL();
        }
        List<MedicineViewModel> s = new List<MedicineViewModel>();
        // GET api/<controller>
        [Route("GetAllMedsDetails")]
        public IEnumerable<MedicineViewModel> Get()
        {
            List<Medicine> c = ms.GetAllMeds();
            foreach (var item in c)
            {
                MedicineViewModel v = new MedicineViewModel();
                v.MedicineId= item.MedicineId;
                v.Name = item.Name;
                v.Price= (float)item.Price;
                v.Stock = item.Stock;
                v.Tax = (float)item.Tax;
                v.IsAvailable = item.IsAvailable;
                v.IsActive = item.IsActive;
                s.Add(v);
            }
            return s;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
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