﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars.Models;
using Microsoft.AspNetCore.Mvc;
using DataLibrary;
using DataLibrary.BusinessLogic;

namespace Cars.Controllers
{
    public class CarsController : Controller
    {
        public IActionResult Brands()
        {
            return View();
        }

        public IActionResult Models()
        {
            return View();
        }

        public IActionResult NewCar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewCar(CarModel model)
        {

            if(ModelState.IsValid)
            {
                _ = CarProcessor.CreateBrand(model.Name, model.Name.Substring(0, 3));
                _ = CarProcessor.CreateModel(model.Brand, model.Name.Substring(0, 3));
            }

            return View();
        }

        [HttpGet]
        public IActionResult ViewCars()
        {


            List<CarModel> cars = new List<CarModel>();

            foreach (var row in CarProcessor.LoadCars())
            {
                cars.Add(new CarModel
                {
                    Name = row.Name,
                    Brand = row.Abrv,
                });

            }

            return View(cars);
        }
    }
}