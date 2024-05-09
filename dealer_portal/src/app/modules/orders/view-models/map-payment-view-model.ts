import { PaymentData } from "src/app/shared/services/fetch/payments.service";
import { PaymentItemViewModel } from "./payment.view-model";


export function mapPaymentToViewModel(result: PaymentData[], orderId: number) {
    const mappedResult: PaymentItemViewModel[] = result.map((item, index) => {


        const payment: PaymentItemViewModel = {
            orderId: orderId,
            paymentId: item.id,
            title: index === 0 ? "Advance" : `${index + 1} payment`,
            status: item.status,
            price: item.price,
            details: [
                { key: 'Payment ID', value: item.id },
                { key: 'Payment amount', value: item.price },
                { key: 'Confirmation date', value: item.paymentDate },
            ]
        };
        return payment;
    });
    return mappedResult;
}


