import { PaymentStatus } from "src/app/shared/enums/payment-status.enum"

export interface PaymentItemViewModel {
    orderId: number
    paymentId: number
    title: string
    status: PaymentStatus
    price: number
    details: {
        key: string
        value: any
    }[]
}

