import { Injectable } from "@angular/core";
import { Observable, map } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { ApiResponse } from "../Models/api-response.model";
import { environment } from "../../environment";
import { manageApiResponse } from "../core/api-response-util";
import { CompanyModel } from "../Models/company.model";

@Injectable({
    providedIn: 'root'
})
export class CompanyService {
    private apiUrl = `${environment.apiUrl}company`;

    constructor(private http: HttpClient) { }

    list(): Observable<CompanyModel[]> {
        return this.http.get<ApiResponse<CompanyModel[]>>(this.apiUrl).pipe(
            map(response =>
                manageApiResponse<CompanyModel[]>(response))
        );
    }

    get(id: number): Observable<CompanyModel> {
        return this.http.get<ApiResponse<CompanyModel>>(`${this.apiUrl}/${id}`).pipe(
            map(response => manageApiResponse<CompanyModel>(response))
        );

    }

    save(data: CompanyModel):Observable<CompanyModel> {
        return this.http.post<ApiResponse<CompanyModel>>(this.apiUrl, data).pipe(
              map(response => manageApiResponse<CompanyModel>(response))
            );
    }

    update(data: CompanyModel):Observable<CompanyModel> {
        return this.http.put<ApiResponse<CompanyModel>>(this.apiUrl, data).pipe(
              map(response => manageApiResponse<CompanyModel>(response))
            );
    }
}