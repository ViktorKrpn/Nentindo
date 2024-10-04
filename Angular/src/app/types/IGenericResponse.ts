export interface IGenericResponse<T> {
    result: T;
    errors: string[];
    warnings: string[];
    isSucessful: boolean;
}