import { Injectable } from '@angular/core';
import {
    Http,
    Headers,
    Request,
    RequestOptions,
    RequestOptionsArgs,
    RequestMethod,
    Response,
    HttpModule
} from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/fromPromise';
import 'rxjs/add/operator/mergeMap';
import { UserManager } from 'oidc-client';
import { AuthService } from './auth.service';

@Injectable()
export class AuthHttpService {

    constructor(private http: Http, private _authService: AuthService, private defOpts?: RequestOptions) {
    }

    public get(url: string, options?: RequestOptionsArgs): Observable<Response> {
        return this.requestHelper({ body: '', method: RequestMethod.Get, url: url }, options);
    }

    public post(url: string, body: any, options?: RequestOptionsArgs): Observable<Response> {
        return this.requestHelper({ body: body, method: RequestMethod.Post, url: url }, options);
    }

    public put(url: string, body: any, options?: RequestOptionsArgs): Observable<Response> {
        return this.requestHelper({ body: body, method: RequestMethod.Put, url: url }, options);
    }

    public delete(url: string, options?: RequestOptionsArgs): Observable<Response> {
        return this.requestHelper({ body: '', method: RequestMethod.Delete, url: url }, options);
    }

    public patch(url: string, body: any, options?: RequestOptionsArgs): Observable<Response> {
        return this.requestHelper({ body: body, method: RequestMethod.Patch, url: url }, options);
    }

    public head(url: string, options?: RequestOptionsArgs): Observable<Response> {
        return this.requestHelper({ body: '', method: RequestMethod.Head, url: url }, options);
    }

    public options(url: string, options?: RequestOptionsArgs): Observable<Response> {
        return this.requestHelper({ body: '', method: RequestMethod.Options, url: url }, options);
    }

    private requestHelper(requestArgs: RequestOptionsArgs, additionalOptions?: RequestOptionsArgs): Observable<Response> {
        let options = new RequestOptions(requestArgs);
        if (additionalOptions) {
            options = options.merge(additionalOptions);
        }
        return this.request(new Request(this.mergeOptions(options, this.defOpts)));
    }

    private mergeOptions(providedOpts: RequestOptionsArgs, defaultOpts?: RequestOptions) {
        let newOptions = defaultOpts || new RequestOptions();

        newOptions = newOptions.merge(new RequestOptions(providedOpts));

        return newOptions;
    }

    private request(url: string | Request, options?: RequestOptionsArgs): Observable<Response> {
        if (typeof url === 'string') {
            return this.get(url, options); // Recursion: transform url from String to Request
        }

        // from this point url is always an instance of Request;
        let req: Request = url as Request;
        let token: string | null = this.getToken();

        return this.requestWithToken(req, token);
    }

    private getToken(): string | null {
      return this._authService.getAccessToken();
    }

    private requestWithToken(req: Request, token: string | null): Observable<Response> {
        if (this.isTokenExpired()) {
            return new Observable<Response>((obs: any) => {
                obs.error(new Error('No JWT present or has expired'));
            });
        } else {
            req.headers.set('Authorization', 'Bearer ' + token);
        }

        return this.http.request(req);
    }

    private isTokenExpired(): boolean {
        return false;
    }
}
