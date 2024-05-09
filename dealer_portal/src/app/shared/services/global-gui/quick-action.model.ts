export interface QuickActionGroup {
    label: string;
    actions: QuickActionModel[];
}

export interface QuickActionModel {
    label: string;
    enabled: boolean;
    handler: () => any;
}
