using MongoDB.Driver;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Models;

namespace WebApi.Controllers
{
    [EnableCors("*", "*", "Get")]
    public class PatientsController : ApiController
    {
        IMongoCollection<Patient> _patients;

        public PatientsController()
        {
            _patients = PatientDb.Open();
        }

        public IEnumerable<Patient> Get()
        {
            return _patients.Find(_=> true).ToEnumerable();
        }

        public IHttpActionResult Get(string id)
        {
            var patient = _patients.Find(_ => _.Id == id).ToList();
            if(patient.Count == 0)
            {
                return NotFound();
            }
            return Ok(patient);
        }
        [Route("api/patients/{id}/medications")]
        public IHttpActionResult GetMedications(string id)
        {
            var patient = _patients.Find(_ => _.Id == id).ToList();
            if (patient.Count == 0)
            {
                return NotFound();
            }
            return Ok(patient[0].Medications);
        }
    }
}
