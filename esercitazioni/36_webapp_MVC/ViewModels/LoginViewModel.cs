using System.ComponentModel.DataAnnotations;

namespace _36_webapp_MVC.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "L'email è obbligatoria.")]
    [EmailAddress(ErrorMessage = "Inserisci un'email valida.")]
    public string Email { get; set; }

    // le parentesi quadrate sono "DATA ANNOTATION", che permettono di 
    // effettuare controlli senza utilizzare cicli o logiche complesse

    [Required(ErrorMessage = "La password è obbligatoria.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public bool RememberMe { get; set; }
}