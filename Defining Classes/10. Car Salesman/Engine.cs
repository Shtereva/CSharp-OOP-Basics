using System;
public class Engine
{
    private string model;
    private string power;
    private string displacement;
    private string efficiency;

    public Engine(string model, string power)
    {
        this.model = model;
        this.power = power;
        this.displacement = "n/a";
        this.efficiency = "n/a";
    }

    public string Model => this.model;
    public string Displacement
    {
        set { this.displacement = value; }
    }

    public string Efficiency
    {
        set { this.efficiency = value; }
    }

    public override string ToString()
    {
        string nl = Environment.NewLine;
        return $"{this.model}:{nl}  Power: {this.power}{nl}  Displacement: {this.displacement}{nl}  Efficiency: {this.efficiency}";
    }
}
