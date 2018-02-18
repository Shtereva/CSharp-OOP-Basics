public class Cargo
{
    private int cargoWeight;
    private CargoType cargoType;

    public Cargo()
    {

    }

    public Cargo(int cargoWeight, CargoType cargoType)
    {
        this.cargoWeight = cargoWeight;
        this.cargoType = cargoType;
    }

    public CargoType CargoType => this.cargoType;
}
