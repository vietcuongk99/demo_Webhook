using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SideA.Model;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SideA.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return Customer.ListCustomer;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{name}")]
        public Customer Get(string name)
        {
            var customer = Customer.ListCustomer.Where(c => c.CustomerName == name).FirstOrDefault();
            return customer;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] Customer value)
        {

            Customer customer = new Customer();
            customer = value;
            Customer.ListCustomer.Add(customer);

            //send data to SideB
            WebhookController webhookController = new WebhookController();
            webhookController.WebhookSenderActionASync("https://8167b7b5a353.ngrok.io/api/values", customer);

            
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
