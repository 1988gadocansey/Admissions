import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { FileParameter, PictureUploadClient } from "../../web-api-client";

@Injectable({
    providedIn: 'root'
})
export class FileUploadService {

    // API url
    baseApiUrl = "https://file.io";



    constructor(private http: HttpClient, private pictureService: PictureUploadClient) { }

    // Returns an observable
    upload(file): Observable<any> {
        let files = [];
        let fileParameter: FileParameter = { data: file, fileName: file.name };
        files.push(fileParameter);
        console.log(files);
        return this.pictureService.uploadImages(files)
    }
}
