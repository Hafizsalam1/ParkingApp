// See https://aka.ms/new-console-template for more information
using System;
using ParkingApp.Controller;
using ParkingApp.Repository;
using System.Timers;

namespace ParkingApp
{
    class Program
    {

        static void Main(string[] args)
        {

            App app = new App();

                app.mainMenu();
            
        }
    }
}
