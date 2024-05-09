using Sii.CarOrder.Contracts.Enums;

namespace Sii.CarOrder.Contracts.Models
{
    public static class ProductionProgressStates
    {
        public static Dictionary<ProductionProgressState, string> States => new Dictionary<ProductionProgressState, string> 
        {
            { ProductionProgressState.Started, "Rozpoczęto produkcję" },
            { ProductionProgressState.Canceled, "Anulowano produkcję" },
            { ProductionProgressState.Ended, "Zakończono produkcję" },
            { ProductionProgressState.VinNumberAssigned, "Nadano numer Vin" },
            { ProductionProgressState.CarBodyPartsManufactured, "Wyprodukowano elementy karoserii" },
            { ProductionProgressState.CarBodyPartsWelded, "Zespawano elementy karoserii" },
            { ProductionProgressState.CarBodyVarnished, "Polakierowano karoserię" },
            { ProductionProgressState.CarPartsManufactured, "Wyprodukowano elementy wyposażenia" },
            { ProductionProgressState.CarAssembled, "Wykonano montaż auta" },
            { ProductionProgressState.FluidsReplenished, "Uzupełniono wszystkie niezbędne płyny" },
            { ProductionProgressState.SoftwareUploaded, "Wgrano oprogramowanie" },
            { ProductionProgressState.TestsPerformed, "Wykonano testy" }
        };

        public static T GetRandomElement<T>(IList<T> list)
        {
            if (list is null || list.Count == 0)
                return default(T);

            var rnd = new Random();
            var index = rnd.Next(list.Count);
            return list[index];
        }

        public static IList<T> GetShuffledList<T>(IList<T> list)
        {
            if (list is null || list.Count == 0)
                return list;

            var rnd = new Random();
            return list.OrderBy(item => rnd.Next()).ToList<T>();
        }
    }
}
