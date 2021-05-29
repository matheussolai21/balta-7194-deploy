using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop1.Models{

//criação de tabela com o dataanotations.schema
    [Table("Categories")]
public class Category{

//criação de coluna com o dataanotations.schema
   [Column("Cat_Id")]
  public int Id { get; set; }
//data annotations, anotações para mapear o banco
  [Required(ErrorMessage="Este Campo é Obrigatorio")]
  [MaxLength(60,ErrorMessage="esse campo contem no maximo 60 caracteres")]
  [MinLength(3,ErrorMessage="esse campo contem no minimo 3 caracteres")]
  public string Title { get; set; }


}

}

