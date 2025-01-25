// Create instances of upgraded car features
using OnlineTest.Models;

//basic car
BasicCar basicCar = new(new BasicHonker()); // 4 cylinders and 2 doors and custom cheap honker
basicCar.Beep(); // Quiet beep at volume: 2

//upgraded car
UpgradedEngine upgradedEngine = new(6);
UpgradedDoor upgradedDoor = new(6);
UpgradedHonker upgradedHonker = new(6);
UpgradedCar upgradedCar = new(upgradedEngine, upgradedDoor, upgradedHonker);
upgradedCar.Beep();

//print description of both cars
Console.WriteLine(basicCar.GetDescription());
Console.WriteLine(upgradedCar.GetDescription());



