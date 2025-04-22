import { ApiResponse } from "../Models/api-response.model";

export function manageApiResponse<T>(response: ApiResponse<T>): T {
    if (response.statusCode == 200 && response.result) {
        return response.result;
    }
    else {
        const errorMsg = response.responseException?.exceptionMessage || 'API Error occurred.';
        throw new Error(errorMsg);
    }
}