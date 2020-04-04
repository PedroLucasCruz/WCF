using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClienteWcfService
{
    public class Clientes
    {
      public  int ID {get; set;}
      public  String Nome {get; set;}
      public  String CPF {get; set;}

       public  bool Saved()
        {
            //Este metodo se conectaria com o banco e retornaria true para a transação
            return true;
        }
    }
}