using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sii.CarOrder.Contracts.Enums
{
    public enum ProductionProgressState
    {
        Started,
        Canceled,
        Ended,
        VinNumberAssigned,
        CarBodyPartsManufactured,
        CarBodyPartsWelded,
        CarBodyVarnished,
        CarPartsManufactured,
        CarAssembled,
        FluidsReplenished,
        SoftwareUploaded,
        TestsPerformed
    }
}
