using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop1.Data;
using Shop1.Models;



namespace Shop1.Controllers{

    [Route("v1")]
    public class  HomeController : ControllerBase 
    {
        
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<dynamic>> Get([FromServices] DataContext context ){
            var employee = new User {Id = 1, UserName = "robin" ,PassWord = "teste1" , Role = "employee"};
            var manager = new User {Id = 2, UserName = "batman" };
            var product = new Product {Id = 3};
            var category = new Category {Id = 4, Title = "informatica"};

            context.User.Add(employee);
            context.User.Add(manager);
            context.Category.Add(category);
            context.Product.Add(product);
            await context.SaveChangesAsync();

            return Ok(new {
                Message = "Dados Enviados"

            });


        }
    }
}
