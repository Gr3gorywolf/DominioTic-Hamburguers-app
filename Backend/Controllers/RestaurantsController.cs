using Backend.Data;
using Backend.Entities.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private HamburguerContext dbContext = new HamburguerContext();
        private UnitOfWork unitOfWork = new UnitOfWork(new HamburguerContext());

        [HttpGet]
        [Route("all")]
        public IActionResult GetHamburguers()
        {
            var restaurants = unitOfWork.Restaurants.Get();
            return Ok(restaurants);
        }

        [HttpGet]
        [Route("{id}/details")]
        public IActionResult GetHamburguer(int Id)
        {
            var restaurant = unitOfWork.Restaurants.GetByID(Id);
            if (restaurant != null)
            {
                return Ok(restaurant);
            }
            else
            {
                return NotFound("Restaurante no encontrado");
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Restaurant restaurant)
        {
            try
            {
                if (ModelState.IsValid)
                {
                        unitOfWork.Restaurants.Insert(restaurant);
                        unitOfWork.Save();
                        return Created("api/v1/restaurants/create", restaurant);
                }
                else
                {
                    return BadRequest("Los datos introducidos son invalidos");
                }
            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] Restaurant restaurant)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Restaurants.Update(restaurant);
                    unitOfWork.Save();
                    return Ok();
                }
                else
                {
                    return BadRequest("Los datos introducidos son invalidos");
                }
            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
