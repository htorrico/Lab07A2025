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
        public List<Customer> Read()
        {

         DCustomer _customerData = new DCustomer();
         return _customerData.Read();
           
        }

        public void Create(Customer customer)
        {
            DCustomer _customerData = new DCustomer();           
            _customerData.Create(customer);
        }

        public int GetSize5()
        {
            //Cuenta todos los que contenga el número 5 en tu teléfono
            DCustomer _customerData = new DCustomer();
            var customers = _customerData.Read();
            //Expresiones Lambda
            var size = customers.Where(c => c.Phone != null && c.Phone.Contains("5")).Count();

            return size;
        }
    }
}
