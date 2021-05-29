using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop1.Data;
using Shop1.Models;

namespace Shop1.Controllers{


[Route ("product")]
public class ProductController : ControllerBase{



[HttpGet]
[Route ("")]
public async Task<ActionResult<Product>> Get([FromServices] DataContext context){
   var product = await context.Product.Include(x => x.Category).AsNoTracking().ToListAsync();
   return Ok(product);

   // include inclui as categorias nos produtos e como se fosse um join

}

[HttpGet]
[Route ("id:int")]
public async Task<ActionResult<Product>> GetById(int id,[FromServices]DataContext context){
    var product = await context.Product.Include(x => x.Category).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    return product;
}

[HttpGet]
[Route ("/category/id:int")]
public async Task<ActionResult<List<Product>>> GetByCategory(int id, [FromServices ]DataContext context){
 
  var productFromCategory = 
  await context.Product.Include(x => x.Category).AsNoTracking().Where(x => x.CategoryID == id).ToListAsync();

  return productFromCategory;
}

[HttpPost]
[Route ("")]
public async Task<ActionResult<Product>> Post([FromBody] Product model, [FromServices] DataContext context )
{
    if(ModelState.IsValid){
        context.Product.Add(model);
        await context.SaveChangesAsync();
        return model;
    }
    
    else{

        return BadRequest(ModelState);
    }


}



}

}