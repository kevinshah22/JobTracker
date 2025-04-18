export interface ApiResponse<T> {
    version: string;
    statusCode: number;
    message: string;
    result: T;
}