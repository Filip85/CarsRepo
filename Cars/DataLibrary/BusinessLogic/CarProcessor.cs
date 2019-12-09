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
            var makeID = 1009;
            List<VehicleMake> model = new List<VehicleMake>();

            var dataId = LoadCarIdWithAbrv(abrv);

            foreach(var row in dataId)
            {
                model.Add(new VehicleMake
                {
                    Id = row.Id
                });
                makeID = row.Id;
            }

            VehicleModels data = new VehicleModels
            {
                MakeId = makeID,
                Name = name,
                Abrv = abrv
            };

            string sql = @"insert into dbo.VehicleModelT (MakeId, Name, Abrv) values (@MakeId, @Name, @Abrv);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<CarModel> LoadCars()
        {
            //string sql = @"select Id, Name, Abrv from dbo.VehicleMakeT";

            string sql = @"select VehicleMakeT.Id, VehicleMakeT.Name, VehicleModelT.Name, VehicleModelT.Abrv from dbo.VehicleModelT inner join VehicleMakeT on VehicleMakeT.Id = VehicleModelT.MakeId"; 

            return SqlDataAccess.LoadData<CarModel>(sql);
        }

        public static List<VehicleMake> LoadCarIdWithAbrv(string Abrv) 
        {
            VehicleMake data = new VehicleMake
            {
                Abrv = Abrv
            };

            string sql = @"select Id from dbo.VehicleMakeT where Abrv=@Abrv";

            return SqlDataAccess.LoadDataId<VehicleMake>(sql, data);
        }

        public static int DeleteData(int id)
        {
            VehicleMake data = new VehicleMake
            {
                Id = id
            };


            string sql = @"delete from dbo.VehicleMakeT where Id=@Id";

            return SqlDataAccess.DeleteData<VehicleMake>(sql, data);
        }
    }
}
