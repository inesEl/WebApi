using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.App_Start
{
    public class MongoConfig
    {
        public static void Seed()
        {
            var patients = PatientDb.Open();

            if (!patients.AsQueryable().Any(p => p.Name == "dodo"))
            {
                var data = new List<Patient>()
                {
                    new Patient
                    {
                        Name = "dodo",
                        Ailments = new List<Ailment> (){ new Ailment { Name= "Crazyyyy" } },
                        Medications = new List<Medication>()
                    },
                     new Patient
                    {
                        Name = "toto",
                        Ailments = new List<Ailment> (){ new Ailment { Name= "Biiitch" } },
                        Medications = new List<Medication>(){ new Medication { Name= "Hard core", Doses= 100} }
                    }
                };

                patients.InsertMany(data);
            }
        }
    }
}
