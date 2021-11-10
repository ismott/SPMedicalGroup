using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpMadicalGrup.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o email do usuario")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuario")]
        public string Senha { get; set; }
    }
}
