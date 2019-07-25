using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using Traning.ContentNegotiation.Models;

namespace Traning.ContentNegotiation.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
       static List<Product> products = new List<Product>
       {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries"},
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys"},
            new Product { Id = 3, Name = "Hammer", Category = "Hardware"}
       };
        
        // GET: api/Products
        public IEnumerable<Product> Get()
        {
            //never do insert/update here
            return products;
        }

        // GET: api/Products/5
        [Route("{id}", Name = "GetProduct")]
        public IHttpActionResult Get(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/Products
        [Route(Name = "CreateProduct")]
        public void Post([FromBody]Product product)
        {
            // new data only
            products.Add(product);
        }

        // PUT: api/Products/5
        [Route("{id}", Name = "UpdateProduct")]
        public void Put(int id, [FromBody]Product product)
        {
            // update data only
        }

        // DELETE: api/Products/5
        [Route("{id}", Name = "deleteProduct")]
        public void Delete(int id)
        {
            // only delete operation from here
        }

    }
}
