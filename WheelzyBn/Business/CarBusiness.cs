
using System;
using System.Collections.Generic;

public class CarBusiness
{
    public Car CreateCar(CarRequest carRequest)
    {
        new Validations().CarValidations(carRequest);

        var car = new Car(carRequest);
        return new Dao().CreateNewCar(car);
       
    }

    public List<Car> GetActiveCars()
    {
        return new Dao().GetActiveCars();

    }

    public List<Car> GetCarByCustumer(int customerId)
    {
        if (customerId <= 0)
            throw new ArgumentException("Customer id is not valid");

        return new Dao().GetCarByCostumer(customerId);
    }

    public List<Car> GetCarByZipCode(string zipCode)
    {
        if (string.IsNullOrEmpty(zipCode))
            throw new ArgumentException("Zip-code id is not valid");

        return new Dao().GetCarByZipCode(zipCode);

    }

    public Car ChangeCarStateTo(long carId, string userName)
    {
        var dao = new Dao();
        var car = dao.GetCarById(carId);
        if (car == null)
            throw new ArgumentException("Car is invalid");

        car.SetAcepted(userName);
        return dao.AcepteCar(car);
        
        
    }

    
}


