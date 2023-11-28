using System.ComponentModel.DataAnnotations;

namespace Resunet.ViewModels; 

public class ProfaileViewModel {
  [Required] public  string? ProfaileName { get; set; }
  [Required] public string? FirstName { get; set; }
  [Required] public string? LastName  { get; set; }
}