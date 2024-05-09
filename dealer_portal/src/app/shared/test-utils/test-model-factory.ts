import { OrderDetailsViewModel } from "src/app/modules/orders/view-models/order-details-view-model";
import { OrderStatus } from "../enums/order-status.enum";
import { OrderDetails } from "../models/order-models/order-details";

export function createTestOrderDetailsViewModel(overrides: Partial<OrderDetailsViewModel> = {}): OrderDetailsViewModel {
    return {
        configuration: [],
        customer: {
            customerEmail: "",
            customerFirstName: "",
            customerLastName: "",
            customerPhone: ""
        },
        order: {
            creationDate: new Date(),
            agreementSignedDate: new Date(),
            plannedDeliveryDate: new Date(),
            discount: 0,
            id: 1,
            price: 200000,
            status: OrderStatus.Created
        },
        ...overrides
    }
}

export function createTestOrderDetails(overrides: Partial<OrderDetails> = {}): OrderDetails {
    return {
        configuration: {
            brand: '',
            class: "",
            color: "",
            engine: "",
            engineCapacity: 0,
            enginePower: 0,
            engineType: "",
            equipmentVersion: "",
            gearboxCount: 0,
            gearboxType: "",
            interior: "",
            model: ""
        },
        customer: {
            customerEmail: "",
            customerFirstName: "",
            customerLastName: "",
            customerPhone: ""
        },
        order: {
            creationDate: new Date(),
            agreementSignedDate: new Date(),
            plannedDeliveryDate: new Date(),
            discount: 0,
            id: 1,
            price: 200000,
            status: OrderStatus.Created
        },
        ...overrides
    }
}

