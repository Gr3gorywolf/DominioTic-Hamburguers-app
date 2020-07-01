using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backend.Entities.Models;
using Backend.Data;
using Backend.Services;
using System.Data;

namespace Backend.Services
{
    [Route("api/v1/[controller]/[action]")]
    public class UsersController : Controller
    {
      
        private HamburguerContext dbContext = new HamburguerContext();
        private UnitOfWork unitOfWork = new UnitOfWork(new HamburguerContext());

        [HttpGet("{Id}")]
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
        public IActionResult Test()
        {
            return Ok("Yeah");
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (unitOfWork.Users.Get((ax) => ax.Email == user.Email).FirstOrDefault() == null)
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

        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var loggedUser = unitOfWork.Users.Get((ax) => ax.Email == user.Email && ax.Password == user.Password).FirstOrDefault();
                    if (loggedUser != null)
                    {
                        return Ok(loggedUser);
                    }
                    else
                    {
                        return BadRequest("Usuario no existe o correo y contraseña invalida.");
                    }

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
        public IActionResult UpdateUser([FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Users.Update(user);
                    unitOfWork.Save();
                    return Ok("Usuario actualizado exitosamente");
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
        public IActionResult DeleteUser(int Id)
        {
            var user = unitOfWork.Users.GetByID(Id);
            if (user != null)
            {
                unitOfWork.Users.Delete(user);
                unitOfWork.Save();
                return Ok("Usuario eliminado exitosamente");
            }
            else
            {
                return NotFound("Usuario no encontrado");
            }
        }



    }
}