using System;



public class State_Chages
{
    public long Id { get; set; }
    public long? Car_id { get; set; }
    public Car Car { get; set; }
    public int? State_id { get; set; }
    public State State { get; set; }
    public DateTime Date { get; set; }
    public string User { get; set; }


    public State_Chages() { }
    public State_Chages(Car car, State state, string user)
    {
        if (car.Id > 0)
            Car_id = car.Id;
        else
            Car = car;

        State_id = state.Id;
        Date = DateTime.Now;
        User = user;
    }
}

