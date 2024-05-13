using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalApi.Models;

public class DoctorHospital 
{
    [Key]
    public int Id {get;set;}
    public int DoctorId {get;set;}
    public int HospitalId {get;set;}

    public Hospital? Hospital{get;set;} = null!;
    public Doctor? Doctor {get;set;} = null!;
}