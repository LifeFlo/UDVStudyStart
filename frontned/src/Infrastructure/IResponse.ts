export interface IResponse<T> {
    value: T;
    error: string;
    errorExplain: string;
}