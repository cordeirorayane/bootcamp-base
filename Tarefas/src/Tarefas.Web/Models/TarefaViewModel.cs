using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tarefas.Web.Models;

public class TarefaViewModel
{
    
    public int Id { get; set; }

    [MinLength(5, ErrorMessage = ("Necessário pelo menos 5 caracteres"))]
    [Required (ErrorMessage ="Informe o titulo")]
    [DisplayName("Título")]    
    public string? Titulo { get; set; }        
    [Required(ErrorMessage ="Informe a descricao")]
    [DisplayName("Descrição")]    
    public string? Descricao { get; set; } 
    [Required(ErrorMessage ="Informe please")] 
    [DisplayName("Concluída")]
    public bool Concluida { get; set; }
}