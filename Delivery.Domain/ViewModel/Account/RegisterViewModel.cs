using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.VisualBasic;

namespace Delivery.Domain.ViewModel.Account;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Укажите имя")]
    [MaxLength(20, ErrorMessage = "Имя должно иметь длину менее 20 символов")]
    [MinLength(3, ErrorMessage = "Имя должно иметь длину более 3 символов")]
    public string Name { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Укажите пароль")]
    [MinLength(3, ErrorMessage = "Пароль должен иметь длину более 3 символов")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Укажите пароль")]
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    public string PasswordConfirm { get; set; }
}