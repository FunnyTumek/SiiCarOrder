using System;
using System.Collections.Generic;
using System.Linq;
using Sii.Dealer.Core.Application.DataTransferObjects;

namespace Sii.Dealer.ConsoleApp
{
    public static class CarConfigurationGenerator
    {
        public static CarConfigurationDto GenerateConfiguration()
        {
            var r = new Random();

            string brandCode = GetRandomElement(r, BrandCodes);
            string modelCode = GetRandomElement(r, ModelCodes);
            string equipmentVersionCode = GetRandomElement(r, EquipmentVersionCodes);
            string classCode = GetRandomElement(r, ClassCodes);
            string engineCode = GetRandomElement(r, EngineCodes);
            string gearboxCode = GetRandomElement(r, GearboxCodes);
            string colorCode = GetRandomElement(r, ColorCodes);
            string interiorCode = GetRandomElement(r, InteriorCodes);
            List<string> additionalEquipmentCodes = GetRandomSubset(r, AdditionalEquipmentCodes).ToList();

            return new CarConfigurationDto
            {
                BrandCode = brandCode,
                ModelCode = modelCode,
                EquipmentVersionCode = equipmentVersionCode,
                ClassCode = classCode,
                EngineCode = engineCode,
                GearboxCode = gearboxCode,
                ColorCode = colorCode,
                InteriorCode = interiorCode,
                AdditionalEquipmentCodes = additionalEquipmentCodes
            };
        }

        private static T GetRandomElement<T>(Random random, IList<T> list)
        {
            var index = random.Next(list.Count);
            return list[index];
        }

        private static IEnumerable<T> GetRandomSubset<T>(Random random, IList<T> list)
        {
            int k = random.Next(list.Count);
            return list.OrderBy(el => random.Next()).Take(k);
        }

        private static IList<string> BrandCodes => new List<string> { "BC01" };
        private static IList<string> ModelCodes => new List<string> { "MC01", "MC02", "MC03", "MC04", "MC05", "MC06" };
        private static IList<string> EquipmentVersionCodes => new List<string> { "EV01", "EV02", "EV03", "EV04", "EV05" };
        private static IList<string> ClassCodes => new List<string> { "CC01", "CC02", "CC03", "CC04", "CC05", "CC06" };
        private static IList<string> EngineCodes => new List<string> { "EC01", "EC02", "EC03", "EC04", "EC05", "EC06", "EC07", "EC08", "EC09", "EC10", "EC11" };
        private static IList<string> GearboxCodes => new List<string> { "GC01", "GC02", "GC03", "GC04" };
        private static IList<string> ColorCodes => new List<string> { "CO01", "CO02", "CO03", "CO04", "CO05", "CO06", "CO07", "CO08", "CO09" };
        private static IList<string> InteriorCodes => new List<string> { "IC01", "IC02", "IC03", "IC04", "IC05", "IC06" };
        private static IList<string> AdditionalEquipmentCodes => new List<string> { "AE01", "AE02", "AE03", "AE04", "AE05", "AE06", "AE07", "AE08", "AE09" };
    }
}
