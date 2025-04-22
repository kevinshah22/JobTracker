import { Injectable } from "@angular/core";
import { Observable, map } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { ApiResponse } from "../Models/api-response.model";
import { JobApplicationModel } from "../Models/job-application.model";
import { environment } from "../../environment";
import { manageApiResponse } from "../core/api-response-util";

@Injectable({
    providedIn: 'root'
})
export class jobApplicationService {
    private apiUrl = `${environment.apiUrl}JobApplication`;

    constructor(private http: HttpClient) { }

    list(): Observable<JobApplicationModel[]> {
        return this.http.get<ApiResponse<JobApplicationModel[]>>(this.apiUrl).pipe(
            map(response =>
                manageApiResponse<JobApplicationModel[]>(response))
        );
    }
}