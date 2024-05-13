using System.ComponentModel.DataAnnotations;

namespace HospitalApi.Models;

public class Doctor 
{
    [Key]
    public int Id {get;set;}
    public int TCKN {get;set;}
    public string Name {get;set;}
    public string Surname {get;set;}
}