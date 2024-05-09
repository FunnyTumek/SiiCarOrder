namespace Sii.Dealer.ReadModel.Models;

public class OrderDetailConfigurationReadModel
{
    public OrderDetailConfigurationReadModel(string brand, string model, string equipmentVersion, string @class, string engine, string engineType, int enginePower, int engineCapacity, string gearboxType, int gearboxCount, string color, string interior)
    {
        this.Brand = brand;
        this.Model = model;
        this.EquipmentVersion = equipmentVersion;
        this.Class = @class;
        this.Engine = engine;
        this.EngineType = engineType;
        this.EnginePower = enginePower;
        this.EngineCapacity = engineCapacity;
        this.GearboxType = gearboxType;
        this.GearboxCount = gearboxCount;
        this.Color = color;
        this.Interior = interior;
    }

    public string Brand { get; set; }
    public string Model { get; set; }
    public string EquipmentVersion { get; set; }
    public string Class { get; set; }
    public string Engine { get; set; }
    public string EngineType { get; set; }
    public int EnginePower { get; set; }
    public int EngineCapacity { get; set; }
    public string GearboxType { get; set; }
    public int GearboxCount { get; set; }
    public string Color { get; set; }
    public string Interior { get; set; }
}
