using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop1.Data;
using Shop1.Models;

namespace Shop1.Controllers{

// controller base é uma classe para facilitar a construção das controllers no projeto

[Route("v1/categories")]
public class CategoryController : ControllerBase{
    [HttpGet]
    [Route("")]
    [AllowAnonymous]
    [ResponseCache(VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Any, Duration =30) ]
    //essa linha usa para dizer que um metodo não usa cache na api
    //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true) ]
    public async Task<ActionResult<List<Category>>> Get([FromServices]DataContext context){
        var category = await context.Category.AsNoTracking().ToListAsync();
        return Ok(category);
    }


  [HttpGet]  
  // significa que so podemos passar parametros inteiros pra rota
  [Route("{id:int}")]
  [AllowAnonymous]

    public  async Task<ActionResult<Category>> GetById(int id, [FromServices]DataContext context){
        var category = await context.Category.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return category;



    }
    [HttpPost]  
    [Route("")]
    // [Authorize(Roles = "employee")]
    // nesse caso ele criou um metodo do tipo category que é a nossa model, esta recebendo com coropo as informações e retornando
    // nossa model
    public async Task<ActionResult<List<Category>>> Post([FromBody]Category model, [FromServices]DataContext context){
       try{

            if (!ModelState.IsValid)
        return BadRequest(ModelState);

        context.Category.Add(model);
        await context.SaveChangesAsync(); // salvando as informações no banco de forma assincrona e apos salvar ele gera um id pra minha model
        return Ok(model);

       }

       catch{

           return BadRequest(new {message = "Não foi possivel gerar sua Categoria"});

       }
      
    }

    [HttpPut]
    [Route("{id:int}")]
    [Authorize(Roles = "employee")]
    public  async Task<ActionResult<List<Category>>> Put(int id, [FromBody]Category model,[FromServices]DataContext context){
        // verifica se o id e mesmo de modelo
        if (model.Id == id){
            return NotFound(new {Message = "categoria não encontrada"} );

        }

        // verifica se os dados são validos
       if (!ModelState.IsValid)
        return BadRequest(ModelState);

        return Ok(model);
        
        try 
        {
            // esta informando que a atribuindo que a model foi modificada
           context.Entry<Category>(model).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(model);
 
        }
        catch(DbUpdateConcurrencyException)
        {

           return BadRequest(new{ Message = "Este registro ja foi Atualizado" });
        
        }
       catch(Exception){
           return BadRequest(new{Message = "Não foi possivel Atualizar a categoria"});

       }

    }

    [HttpDelete]
    [Route("{id:int}")]
    [Authorize(Roles = "employee")]
    public async Task<ActionResult<Category>> Delete(int id,[FromServices] DataContext context){

      var category = await context.Category.FirstOrDefaultAsync(x => x.Id == id  );
      if(category == null){
          return NotFound(new{Message = "Não foi possivel deletar a categoria "});
      }
       
       try{
               context.Category.Remove(category);
               await context.SaveChangesAsync();
               return Ok(new{Message = "Categoria Excluida com sucesso"});

       }
       catch(Exception){
            return BadRequest(new{Message = "Categoria não pode ser excluida"});
       }
    }

    

}

}