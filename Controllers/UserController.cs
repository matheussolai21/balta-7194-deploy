using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop1.Data;
using Shop1.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Shop1.Services;


namespace Shop1.Controllers{

[Route("users") ]
public  class UserController : Controller
{
    // joga no banco o usuario cria e joga no banco o usuario
    [HttpPost]
    [Route ("")]
    [AllowAnonymous] // não precisa de autorização
    public async Task<ActionResult<User>> Post([FromServices] DataContext context, [FromBody]User model){
        if(!ModelState.IsValid){
          
          return BadRequest(ModelState);
        }
        try
        {
            model.Role = "employee";
            context.Add(model);
            await context.SaveChangesAsync();
           
           //esconde a senha
            model.PassWord = "";
            return model;
        }
        catch (System.Exception)
        {
            
            return BadRequest(new{Massage = "Não foi possivel criar usúario"});
        }
    }
    // esse metodo vai verificar se o usuaario existe se existir gera um token e usuario novo
    // [HttpPost]
    // [Route ("login")]
   
    // public async Task<ActionResult<dynamic>> Authenticate([FromServices] DataContext context, [FromBody]User model){
    //    var user = await context.User.AsNoTracking().Where(x => x.UserName == model.UserName && x.PassWord == model.PassWord).FirstOrDefaultAsync();

    //      if (user == null)
    //      {
    //          return NotFound(new{Message = "Usúario e senha incorretos"});
    //      }

    //    var token = TokenService.GenerateToken(user);

        // esconde a senha   
        //    User.PassWord = "";
    //    return new{
    //        user = user,
    //        token = token
    //    };

    [HttpPut]
    [Route("{id:int}")]
    [Authorize (Roles = "manager")]
    public  async Task<ActionResult<List<User>>> Put(int id, [FromBody]User model,[FromServices]DataContext context){
        // verifica se o id e mesmo de modelo
        
        // verifica se os dados são validos
       if (!ModelState.IsValid)
        return BadRequest(ModelState);

        if (model.Id == id){
            return NotFound(new {Message = "Usuario não encontrado"} );

        }


        try {
             // esta informando que a atribuindo que a model foi modificada
             context.Entry<User>(model).State = EntityState.Modified;
             await context.SaveChangesAsync();
             return Ok(model);
 
        }
       catch(Exception){
           return BadRequest(new{Message = "Não foi possivel Atualizar a Usuário"});

       }

    }

}

   
    

}