using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entities.Models
{
    public class UsersHamburguer
    {
        public int  Id {get;set;}
       public  int  UserId {get;set;}
       public virtual User User {get;set;}
       public int HamburguerId {get;set;}
       public virtual Hamburguer Hamburguer {get;set;}

    }
}
