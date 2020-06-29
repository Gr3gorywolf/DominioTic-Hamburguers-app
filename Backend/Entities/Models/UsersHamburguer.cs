using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entities.Models
{
    public class UsersHamburguer
    {
        public int  UsersHamburguerId {get;set;}
       public  int  UserId {get;set;}
       public User User {get;set;}
       public int HamburguerId {get;set;}
       public Hamburguer Hamburguer {get;set;}

    }
}
