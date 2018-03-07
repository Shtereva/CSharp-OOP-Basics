using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private double totalStoredEnergy;
    private double totalMinedOre;
    private ModeType mode;

    private List<Harvester> harvesters;
    private List<Provider> providers;

    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.mode = ModeType.Full;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        var harvester = HarvesterFactory.Create(arguments);
        this.harvesters.Add(harvester);

        return $"Successfully registered {arguments[0]} Harvester - {harvester.Id}";
    }

    public string RegisterProvider(List<string> arguments)
    {
        var provider = ProviderFactory.Create(arguments);
        this.providers.Add(provider);

        return $"Successfully registered {arguments[0]} Provider - {provider.Id}";
    }

    public string Day()
    {
        double summedOreOutput = 0;

        double producedEnergyFromProviders = this.providers.Sum(p => p.EnergyOutput);
        this.totalStoredEnergy += producedEnergyFromProviders;

        double requiredEnergyForHarvesters = this.CheckModeForEnergy();

        if (this.totalStoredEnergy >= requiredEnergyForHarvesters)
        {
            this.totalStoredEnergy -= requiredEnergyForHarvesters;
            summedOreOutput = this.CheckModeForOre();
        }

        this.totalMinedOre += summedOreOutput;

        var sb = new StringBuilder();

        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {producedEnergyFromProviders}");
        sb.AppendLine($"Plumbus Ore Mined: {summedOreOutput}");

        return sb.ToString().Trim();
    }

    private double CheckModeForOre()
    {
        double sum = 0;

        if (this.mode == ModeType.Half)
        {
            sum = (this.harvesters.Sum(h => h.OreOutput * 0.5));
        }

        if (this.mode == ModeType.Full)
        {
            sum = this.harvesters.Sum(h => h.OreOutput);
        }

        return sum;
    }

    private double CheckModeForEnergy()
    {
        double sum = 0;

        if (this.mode == ModeType.Half)
        {
            sum = (this.harvesters.Sum(h => h.EnergyRequirement * 0.6));
        }

        if (this.mode == ModeType.Full)
        {
            sum = this.harvesters.Sum(h => h.EnergyRequirement);
        }

        return sum;
    }

    public string Mode(List<string> arguments)
    {
        this.mode = Enum.Parse<ModeType>(arguments[0]);

        return $"Successfully changed working mode to {this.mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];
        var provider = this.providers.SingleOrDefault(p => p.Id == id);
        var harvester = this.harvesters.SingleOrDefault(h => h.Id == id);

        if (provider == null && harvester == null)
        {
            return $"No element found with id - {id}";
        }

        return harvester?.ToString().Trim() ?? provider?.ToString().Trim();
    }

    public string ShutDown()
    {
        var sb = new StringBuilder();

        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {this.totalStoredEnergy}");
        sb.AppendLine($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return sb.ToString().Trim();
    }
}
