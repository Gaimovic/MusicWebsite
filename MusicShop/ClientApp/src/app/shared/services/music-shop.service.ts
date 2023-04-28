import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: 'root'
})
export class MusicShopService {
    constructor(private httpClient: HttpClient) {}

    public setDummyDatabse() {
        this.httpClient
        .get(`${environment.bffUrl}/api/musicshop/createdb`)
        .subscribe(
            (response: any) => {
                console.log(response);
            }
        );
    }

    public getAlbums(): Observable<any> {
        return this.httpClient
            .get(`${environment.bffUrl}/api/musicshop/getAllAlbums`);
    }

    public reloadAlbums() {
        return this.getAlbums()
                .subscribe({
                    error: err => console.log(err)
                });
    }

    public removeAlbum(albumId: string): Observable<any> {
        return this.httpClient
            .get(`${environment.bffUrl}/api/musicshop/removeAlbum?albumId=${albumId}`);
    }

    public addNewAlbum(album: any) {
        return this.httpClient.post<any>(`${environment.bffUrl}/api/musicshop/createAlbum`, album);
    }

    public getConcerts(): Observable<any> {
        return this.httpClient
            .get(`${environment.bffUrl}/api/musicshop/getConcerts`);
    }

    public addNewConcert(concert: any) {
        return this.httpClient.post<any>(`${environment.bffUrl}/api/musicshop/addConcert`, concert);
    }

    public removeConcert(concertId: string): Observable<any> {
        return this.httpClient
            .get(`${environment.bffUrl}/api/musicshop/removeConcert?concertId=${concertId}`);
    }
}