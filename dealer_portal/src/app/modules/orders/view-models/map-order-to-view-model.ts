import { Configuration } from "src/app/shared/models/configuration";
import { ConfigurationItem } from "src/app/shared/models/configuration-item";
import { OrderDetails } from "src/app/shared/models/order-models/order-details";
import { OrderDetailsViewModel } from "./order-details-view-model";

export function mapOrderToViewModel(result: OrderDetails) {
    const mappedConfiguration: ConfigurationItem[] = [];
    const keys = Object.keys(result.configuration);
    const engine: ConfigurationItem = {
        label: 'Engine',
        properties: []
    }

    const gearbox: ConfigurationItem = {
        label: 'Gearbox',
        properties: []
    }

    for (let i = 0; i < keys.length; i++) {
        const element = result.configuration[keys[i] as keyof Configuration];

        if (keys[i].indexOf('engine') >= 0) {
            const propName = keys[i].replace('engine', '') === '' ? "Engine" : keys[i].replace('engine', '');
            engine.properties.push({ key: propName, value: element });
        } else if (keys[i].indexOf('gearbox') >= 0) {
            const propName = keys[i].replace('gearbox', '') === '' ? "Gearbox" : keys[i].replace('gearbox', '');
            gearbox.properties.push({ key: propName, value: element });
        } else {
            mappedConfiguration.push({
                label: keys[i],
                properties: [{
                    key: keys[i],
                    value: element
                }]
            })
        }
    }
    mappedConfiguration.splice(2, 0, engine);
    mappedConfiguration.splice(3, 0, gearbox);

    const mappedResult: OrderDetailsViewModel = {
        customer: result.customer,
        order: result.order,
        configuration: mappedConfiguration
    }

    return mappedResult;
}
