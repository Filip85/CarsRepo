using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.BusinessLogic
{
    public static class CarProcessor
    {
        public static int CreateBrand(string name, string abrv) 
        {
            VehicleMake data = new VehicleMake
            {
                Name = name,
                Abrv = abrv
            };

            string sql = @"insert into dbo.VehicleMakeT (Name, abrv) values (@Name, @Abrv);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int CreateModel(string name, string abrv)
        {
            var makeID = 12;
            //List<VehicleModels> model = new List<VehicleModels>();

           // var dataId = LoadCarIdWithAbrv(abrv);

            /*foreach(var row in dataId)
            {
                model.Add(new VehicleModels
                {
                    MakeId = row.Id
                });
                makeID = row.Id;
            }*/

            VehicleModels data = new VehicleModels
            {
                MakeId = makeID,
                Name = name,
                Abrv = abrv
            };

            string sql = @"insert into dbo.VehicleModelT (MakeId, Name, Abrv) values (@MakeId, @Name, @Abrv);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<VehicleMake> LoadCars()
        {
            string sql = @"select Id, Name, Abrv from dbo.VehicleMakeT";

            return SqlDataAccess.LoadData<VehicleMake>(sql);
        }

        public static List<VehicleMake> LoadCarIdWithAbrv(string Abrv)
        {
            string sql = @"select Id from dbo.VehicleMakeT where Abrv = @Abrv";

            return SqlDataAccess.LoadData<VehicleMake>(sql);
        }
    }
}
