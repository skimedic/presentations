import { Component, OnInit } from '@angular/core';
import { Headers, Http, RequestOptions } from '@angular/http';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { AuthHttpService } from './auth-http.service';
import { AuthService } from './auth.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    claims: any[];

    constructor(private _http: Http,
        private _authHttp: AuthHttpService,
        private _httpClient: HttpClient,
        private _authService: AuthService) {
    }

    ngOnInit() {
        this._authService.initializeUser();
    }

    login() {
        this._authService.login();
    }

    callApiManualAuthHeader() {
        const headers = new Headers({ 'Authorization': 'Bearer ' + this._authService.getAccessToken() });
        const options = new RequestOptions({ headers: headers });
        this._http.get('http://localhost:5001/Identity', options)
            .subscribe(response => {
                this.claims = response.json();
            });
    }

    callApiAutoAuthHeaderAuthHttp() {
        this.claims = [];
        this._authHttp.get('http://localhost:5001/Identity')
            .subscribe(response => this.claims = response.json());
    }

    callApiAutoAuthHeaderHttpClientInterceptor() {
        this._httpClient.get<any[]>('http://localhost:5001/Identity')
            .subscribe(claims => {
                this.claims = claims;
            });
    }

    logout() {
        this._authService.logout();
    }
}
