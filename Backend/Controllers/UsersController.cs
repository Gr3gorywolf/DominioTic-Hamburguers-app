using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backend.Entities.Models;
using Backend.Data;
using Backend.Services;
using System.Data;

namespace Backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
      
        private HamburguerContext dbContext = new HamburguerContext();
        private UnitOfWork unitOfWork = new UnitOfWork(new HamburguerContext());

        [HttpGet]
        [Route("{id}/details")]
        public IActionResult GetUserDetails(int Id)
        {
            User user = unitOfWork.Users.GetByID(Id);
            if(user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet]
        [Route("test")]
        public IActionResult Test()
        {
            return Ok("Yeah");
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (unitOfWork.Users.Get((ax) => ax.Email == user.Email).First() == null)
                    {
                        unitOfWork.Users.Insert(user);
                        unitOfWork.Save();
                        return Created("api/v1/users/create", user);
                    }
                    else
                    {
                        return BadRequest("Ya existe un usuario con este correo");
                    }
                   
                }
                else
                {
                    return BadRequest("Los datos introducidos son invalidos");
                }
            }catch(DataException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Users.Update(user);
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