using ParkingApp.Models;
using System.Timers;
namespace ParkingApp.Repository;

public class ParkingRepository{

    
    public ParkingRepository(){}
    private System.Timers.Timer _timer;
    Dictionary<int, Car> slot = new Dictionary<int, Car>();

    public Parking createParking (int totalSlot){


        for(int i = 1; i <= totalSlot; i++){
            slot.Add(i,null);
        }

        Parking parking = new Parking(slot);
        return parking;
        
    }

    public void parkCar(Car car){
        int noSlot = lotAvailable().Min();
        slot[noSlot] = car;

        Console.WriteLine("Allocated slot number: " + noSlot);
    }

    public Car checkout(int slotNumber){
        Car car = slot[slotNumber];
        slot[slotNumber] =  null;
        return car;
    }

    public List<string> registrationNumbers(){
        List<string> registrationNumbers = new List<string>();
        foreach (var slotNumber in slot.Keys)
        {
            if(slot[slotNumber]!= null){
                registrationNumbers.Add(slot[slotNumber].registrationNumber);
            }
            
        }
        return registrationNumbers;

    }

    public List<int> lotFull(){
        List<int> lots = new List<int>();
        foreach (var lotNumber in slot.Keys)
        {
            if(slot[lotNumber] !=null ){
                lots.Add(lotNumber);
            }
            
        }
        return lots;

    }

    public List<int> lotAvailable(){
        List<int> lots = new List<int>();
        foreach (var lotNumber in slot.Keys)
        {
            if(slot[lotNumber] == null){
                lots.Add(lotNumber);
            }
            
        }
        return lots;
        

    }

    public List<string> findCarbyColour(string colour){
        List<string> regNumbers = new List<string>();
        foreach (var slotNumber in slot.Keys)
        {
            if(slot[slotNumber] != null){
            if(slot[slotNumber].colour == colour){
                regNumbers.Add(slot[slotNumber].registrationNumber);
            }
            }
            
        }
        return regNumbers;
        
    }

    public int TotalVehicleByType(string type){
        int totalVehicle = 0;
        foreach (var slotNumber in slot.Keys)
        {
            if(slot[slotNumber] != null){
            if(slot[slotNumber].vehicle == type){
                totalVehicle = totalVehicle + 1;
            }
            
        }
        
        }
        return totalVehicle;
        
    }

    public Dictionary<int, Car> getAllParkedCar(){
        return slot;
    }

    public int findSlotforRegistNumber(string registNumber){
        int slotWithRegistNumber = 0;

        foreach (var slotNumber in slot.Keys)
        {
            if(slot[slotNumber] != null){
                if(slot[slotNumber].registrationNumber == registNumber){
                    slotWithRegistNumber = slotNumber;
                }

            }

            
        }
        return slotWithRegistNumber;

    }



    



}
