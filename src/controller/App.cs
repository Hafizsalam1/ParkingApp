using ParkingApp.Service;
using ParkingApp.Repository;
using ParkingApp.Models;
namespace ParkingApp.Controller;

public class App{

        private ParkingService? parkingService = new ParkingService();
        private ParkingRepository ParkingRepository = new ParkingRepository();

    public void mainMenu(){
        while(true){
        string? input = Console.ReadLine();

        string[] inputs = input.Split(' ');

        switch(inputs[0]){
            case "create_parking_lot":
                    parkingService?.createParking(int.Parse(inputs[1]));
                    break;
                

            case "park":
                Car car = new Car();
                car.colour = inputs[2];
                car.registrationNumber = inputs[1];
                car.vehicle = inputs[3];
                car.fee = 3000;
                car.parkedTime = DateTime.Now;
                parkingService?.parkedCars(car);
                break;

            case "leave":
                parkingService?.checkout(int.Parse(inputs[1]));
                break;  

            case "status":
                parkingService?.getAllParkedCar();
                break;
            case "registration_numbers_for_vehicles_with_ood_plate":
                parkingService?.OddregistrationNumbers();
                break;
            case "registration_numbers_for_vehicles_with_event_plate":
                parkingService?.EvenregistrationNumbers();
                break;
            case "type_of_vehicles" :
                parkingService?.TotalVehicleByType(inputs[1]);
                break;
            case "registration_numbers_for_vehicles_with_colour":
                parkingService?.registNumberVehiclewithColour(inputs[1]);
                break;
            case "slot_numbers_for_vehicles_with_colour":
                parkingService?.slotwithvehicleColour(inputs[1]);
                break;
            case "slot_number_for_registration_number" :
                parkingService?.findSlotforRegistNumber(inputs[1]);
                break;
            case "exit":
                Environment.Exit(0);
                break;






        }

        }



    }


}