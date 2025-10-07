using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;


namespace Business
{
    public class BCustomer
    {
        public List<Customer> ObtenerCustomers()
        {

         DCustomer _customerData = new DCustomer();
         return _customerData.ListarCustomers();
           
        }
    }
}
