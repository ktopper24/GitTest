using CarrollUniversityWebApp.server.Models;
using CarrollUniversityWebApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CarrollUniversityWebApp.server.Controllers
{
    public class BuildingController : ApiController
    {

        // GET api/building
        [HttpGet]
        public BuildingModel[] Get()
        {
            var dbm = new DatabaseManager();
            var buildingList = dbm.GetAllBuildings();

            return buildingList.ToArray();
        }


        // POST api/building
        [HttpPost]
        public void Post([FromBody]BuildingModel building)
        {
            {
                var dbm = new DatabaseManager();
                dbm.AddBuilding(building.Building_Name);
            }
        }
    }
}