public class Tire
{
    private double pressure;
    private int age;

    public Tire()
    {

    }

    public Tire(double pressure, int age)
    {
        this.pressure = pressure;
        this.age = age;
    }

    public double Pressure => this.pressure;
}
