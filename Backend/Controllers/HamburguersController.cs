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
    public class HamburguersController : ControllerBase
    {
        private HamburguerContext dbContext = new HamburguerContext();
        private UnitOfWork unitOfWork = new UnitOfWork(new HamburguerContext());

        [HttpGet]
        [Route("all")]
        public IActionResult GetHamburguers()
        {
            var hamburguers = unitOfWork.Hamburguers.Get();
            return Ok(hamburguers);
        }

        [HttpGet]
        [Route("{id}/details")]
        public IActionResult GetHamburguer(int Id)
        {
            var hamburguer = unitOfWork.Hamburguers.GetByID(Id);
            if (hamburguer != null)
            {
                return Ok(hamburguer);
            }
            else
            {
                return NotFound("Hamburguer no encontrado");
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Hamburguer hamburguer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Restaurant restaurant = null;
                    if (hamburguer.RestaurantId != null)
                    {
                        restaurant = unitOfWork.Restaurants.GetByID(hamburguer.RestaurantId);
                    }
                    if(restaurant != null)
                    {
                        hamburguer.Restaurant = restaurant;
                        hamburguer.RestaurantId = restaurant.RestaurantId;
                       
                    }
                    else
                    {
                        return BadRequest("Id del restaurante invalido");
                    }

                    unitOfWork.Hamburguers.Insert(hamburguer);
                    unitOfWork.Save();
                    return Created("api/v1/hamburguers/create", hamburguer);
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
        public IActionResult Update([FromBody] Hamburguer hamburguer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Hamburguers.Update(hamburguer);
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
