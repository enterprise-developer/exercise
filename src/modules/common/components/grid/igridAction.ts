export class IGridAction {
    id?: string;
    text: string;
    handler?: (event?: any) => void;
}