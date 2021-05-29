using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop1.Models{
public class Product {

public int Id { get; set; }
//data annotations, anotações para mapear o banco
  
  public string Title { get; set; }

  [Required(ErrorMessage="Este Campo é Obrigatorio")]
  [MaxLength(60,ErrorMessage="esse campo contem no maximo 60 caracteres")]
  [MinLength(3,ErrorMessage="esse campo contem no minimo 3 caracteres")]
   public string Description { get; set; }
     
   [MaxLength(1024,ErrorMessage="esse campo contem o maximo de 1024 caracteres")]

   public decimal Price { get; set; }

     // verifica se o produto esta dentro desse range
    [Required(ErrorMessage="Este Campo é Obrigatorio")]
    [Range(1,int.MaxValue, ErrorMessage="O preço deve ser maior que zero")]

    public int CategoryID { get; set; }

// diferença e que nesse campo traz mais informações que a categoria como ta referenciando
// a model ele traz o titulo da categoria, forein key
    public Category Category{get;set;}

}


}