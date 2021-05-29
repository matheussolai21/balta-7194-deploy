using System.ComponentModel.DataAnnotations;

namespace Shop1.Models{

    public class User{

         public int Id { get; set; }

         [Required(ErrorMessage="Este Campo é Obrigatorio")]
         [MaxLength(20,ErrorMessage="Este Campo deve conter maximo 20 caracteres")]
         [MinLength(3, ErrorMessage="Este campo deve conter minimo 3 caracteres")]

         public string UserName { get; set; }

         [Required(ErrorMessage="Este Campo é Obrigatorio")]
         [MaxLength(20,ErrorMessage="Este Campo deve conter maximo 20 caracteres")]
         [MinLength(3, ErrorMessage="Este campo deve conter minimo 3 caracteres")]

         public string PassWord { get; set; }

         public string Role { get; set; }

    }
}