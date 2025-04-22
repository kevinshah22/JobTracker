import { Injectable } from "@angular/core";
import { Observable, map } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { ApiResponse } from "../Models/api-response.model";
import { RegistrationModel } from "../Models/register-request.model";
import { environment } from "../../environment";
import { EncryptDecryptService } from '../core/encryption.decryption';

@Injectable({
    providedIn: 'root'
})
export class RegistrationService {
    private apiUrl = `${environment.apiUrl}User/register`

    constructor(private http: HttpClient,
        private encryptDecryptService: EncryptDecryptService
    ) { }

    register(data: RegistrationModel): Observable<boolean> {
        data.password = this.encryptDecryptService.encryptUsingAES256(data.password);
        return this.http.post<ApiResponse<string>>(this.apiUrl, data).pipe(
            map(response => {
                if (response.statusCode == 200) {
                    return true;
                }
                else {
                    return false;
                }
            })

        );
    }
}
