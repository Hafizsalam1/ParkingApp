using System.Collections.Generic;

namespace ParkingApp.Models;


public class Parking {

    Dictionary<int, Car> slot {get; set;} 

    public Parking(Dictionary<int, Car> slot){
        this.slot = slot;
    }

}

