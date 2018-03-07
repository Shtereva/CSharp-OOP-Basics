public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int factor)
        : base(id, oreOutput, energyRequirement)
    {
        this.sonicFactor = factor;
        base.EnergyRequirement /= this.sonicFactor;
    }

}
