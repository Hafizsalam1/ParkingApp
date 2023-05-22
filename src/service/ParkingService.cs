using ParkingApp.Models;
using ParkingApp.Repository;
namespace ParkingApp.Service;

public class ParkingService{
    private ParkingRepository? parkingRepository = new ParkingRepository();

    public ParkingService(ParkingRepository parkingRepository){
        this.parkingRepository = new ParkingRepository();
    }
    public ParkingService(){

    }

    public void createParking (int totalSlot){
        parkingRepository?.createParking(totalSlot);
        Console.WriteLine("Successfully created parking lot with " + totalSlot + " slots");
    }

    public void parkedCars( Car car){
        var parkedCars = parkingRepository?.getAllParkedCar();
        int totalCars = 0;
        foreach (var slotNumber in parkedCars?.Keys)
        {
            if(parkedCars[slotNumber] != null){
                totalCars  = totalCars +  1;
            
        }

            
        }
        if(totalCars == parkedCars.Count){
            Console.WriteLine("Sorry, parking lot is full");

        }

        else{
                parkingRepository?.parkCar(car);
        }


    }
    public void checkout(int slotNumber){
        var parkedCar = parkingRepository?.getAllParkedCar(); 
        if(parkedCar[slotNumber] !=null){
            parkingRepository?.checkout(slotNumber);
            Console.WriteLine("slot number" + slotNumber + "is free");
        }
        else{
            Console.WriteLine("slot number" + slotNumber + "already empty");
        }
    }

    public void lotAvailable(){
        Console.WriteLine("Available parking lot: ");
        foreach (var slotNumber in parkingRepository.lotAvailable())
        {
            Console.WriteLine(slotNumber);
            
        }

    }


    public void lotFull(){
        Console.WriteLine("not available parking lot: ");
        foreach (var slotNumber in parkingRepository.lotFull())
        {
            Console.WriteLine(slotNumber);
        }

    }

    public void OddregistrationNumbers(){
        List<string> ?registrationNumbers = parkingRepository?.registrationNumbers();
        List<string> oddRegistNumber = new List<string>();

        foreach (var registNumber in registrationNumbers)
        {
            string[] noplatDipisaah = registNumber.Split('-');
            int noplat = int.Parse(noplatDipisaah[1]);
            if(noplat%2 != 0){
                oddRegistNumber.Add(registNumber);

            }

            
        }
        if(oddRegistNumber.Count == 0){
            Console.WriteLine("There is no vehicle with odd register number");

        }
        else{
            foreach (var odd in oddRegistNumber)
        {
            Console.Write(odd + ",");
            
        }


        }

    }



    public void EvenregistrationNumbers(){
        List<string> ?registrationNumbers = parkingRepository?.registrationNumbers();
        List<string> EvenRegistNumber = new List<string>();

        foreach (var registNumber in registrationNumbers)
        {
            string[] noplatDipisaah = registNumber.Split('-');
            int noplat = int.Parse(noplatDipisaah[1]);
            if(noplat%2 == 0){
                EvenRegistNumber.Add(registNumber);

            }    
        }
        if(EvenRegistNumber.Count == 0){
            Console.WriteLine("There is no vehicle with even register number");

        }
        else{
            foreach (var even in EvenRegistNumber)
        {
            Console.Write(even + ",");
            
        }


        }

    }

    public void TotalVehicleByType(string type){
        Console.WriteLine(parkingRepository?.TotalVehicleByType(type));
    }


    public void getAllParkedCar(){
        var getAllCars = parkingRepository?.getAllParkedCar();
        foreach (var car in getAllCars)
        {
            if(car.Value != null){
            TimeSpan timeDifference =  DateTime.Now - car.Value.parkedTime;
            int hoursDifference =(int) timeDifference.TotalHours;
            car.Value.fee = car.Value.fee + 3000*hoursDifference;
            Console.WriteLine("Slot " + car.Key + car.Value);
            }
            
        }
    }

    public void registNumberVehiclewithColour(string colour){
        
        var registNumbers = parkingRepository?.findCarbyColour(colour);
        foreach (var registNumber in registNumbers)
        {
            Console.Write(registNumber + ",");
            
        }
    }

    public void slotwithvehicleColour(string colour){
        List <int> slotwithvehicleColour = new List<int>();
        var cars = parkingRepository?.getAllParkedCar();
        foreach (var slotNumber in cars.Keys)
        {
            if(cars[slotNumber] != null){

            if(cars[slotNumber].colour == colour){
                slotwithvehicleColour.Add(slotNumber);
            }
            }
            
        }
        foreach (var slot in slotwithvehicleColour)
        {
            Console.Write(slot + ",");
            
        }


    }

    public void findSlotforRegistNumber(string registNumber){
        if(parkingRepository?.findSlotforRegistNumber(registNumber) == 0){
            Console.WriteLine("Not found");
        }
        else{
            Console.WriteLine(parkingRepository?.findSlotforRegistNumber(registNumber));
        }
        
    }






    






}
