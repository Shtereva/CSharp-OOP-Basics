public class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private Tire[] tires; // 4

    public Car()
    {
        this.engine = new Engine();
        this.cargo = new Cargo();
        this.tires = new Tire[4];
    }
    public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
    {
        this.model = model;
        this.engine = engine;
        this.cargo = cargo;
        this.tires = tires;
    }

    public string Model => this.model;
    public Cargo Cargo => this.cargo;
    public Tire[] Tires => this.tires;
    public Engine Engine => this.engine;
}

