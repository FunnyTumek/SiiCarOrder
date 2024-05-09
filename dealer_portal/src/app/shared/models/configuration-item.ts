export interface ConfigurationItem {
    label: string,
    properties: {
        key: string,
        value: string | number,
    }[]
}