namespace Sii.CarOrder.Contracts.Dealer
{
    public class PlaceOrderDealerEvent
    {
        public PlaceOrderDealerEvent(int orderId, string brandCode, string modelCode, string equipmentVersionCode, string classCode, string engineCode, string gearboxCode, string colorCode, string interiorCode, IEnumerable<string> additionalEquipmentCodes/*, DateTime deliveryDate*/)
        {
            OrderId = orderId;
            BrandCode = brandCode;
            ModelCode = modelCode;
            EquipmentVersionCode = equipmentVersionCode;
            ClassCode = classCode;
            EngineCode = engineCode;
            GearboxCode = gearboxCode;
            ColorCode = colorCode;
            InteriorCode = interiorCode;
            InteriorCode = interiorCode;
            AdditionalEquipmentCodes = additionalEquipmentCodes;
        }

        public int OrderId { get; set; }
        public string BrandCode { get; set; }
        public string ModelCode { get; set; }
        public string EquipmentVersionCode { get; set; }
        public string ClassCode { get; set; }
        public string EngineCode { get; set; }
        public string GearboxCode { get; set; }
        public string ColorCode { get; set; }
        public string InteriorCode { get; set; }
        public IEnumerable<string> AdditionalEquipmentCodes { get; set; }
    }
}
