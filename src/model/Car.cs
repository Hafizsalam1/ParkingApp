namespace ParkingApp.Models;

public class Car {
    public string registrationNumber {get; set;}
    public string colour {get; set;}
    public string vehicle {get; set;}
    public int fee {get; set;}
    public DateTime parkedTime{get; set;}

       public override string ToString() {
        return $"{registrationNumber}, {colour}, {vehicle}, {fee}";
    }                     

}
