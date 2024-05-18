
namespace HospitalApi.Models;

public class JuncDTO
{
    public string DoctorName {get;set;}
    public int DoctorId {get;set;}
    public int DoctorTCKN {get;set;}
    public string DoctorSurname {get;set;}
    public List <Hospital> Hospitals {get;set;}
}