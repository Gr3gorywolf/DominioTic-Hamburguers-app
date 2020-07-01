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
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private HamburguerContext dbContext = new HamburguerContext();
        private UnitOfWork unitOfWork = new UnitOfWork(new HamburguerContext());

        [HttpGet]
        public IActionResult GetRestaurants()
        {
            var restaurants = unitOfWork.Restaurants.Get();
            return Ok(restaurants);
        }

        [HttpGet("{Id}")]
        public IActionResult GetRestaurant(int Id)
        {
            var restaurant = unitOfWork.Restaurants.GetByID(Id);
            restaurant.Hamburguers = unitOfWork.Hamburguers.Get(ax => ax.RestaurantId == restaurant.Id).ToList();
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
        public IActionResult CreateRestaurant([FromBody] Restaurant restaurant)
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
        public IActionResult UpdateRestaurant([FromBody] Restaurant restaurant)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Restaurants.Update(restaurant);
                    unitOfWork.Save();
                    return Ok("Restaurante actualizado exitosamente");
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

        [HttpDelete("{Id}")]
        public IActionResult DeleteRestaurant(int Id)
        {
            var restaurant = unitOfWork.Restaurants.GetByID(Id);
            if (restaurant != null)
            {
                unitOfWork.Restaurants.Delete(restaurant);
                unitOfWork.Save();
                return Ok("Restaurant eliminado exitosamente");
            }
            else
            {
                return NotFound("Restaurant no encontrado");
            }
        }

    }
}
