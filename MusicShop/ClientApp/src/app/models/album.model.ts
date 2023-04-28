import { FormArray, FormControl, FormGroup, Validators } from "@angular/forms";

export enum Genres {
    HeavyMetal = 'HM',
    Rock = 'R',
    Pop = 'P'
}

export interface CreateAlbumRequest {
    author: string;
    title: string;
    description: string;
    coverUrl: string;
    genreCode: string;
    musicBandName: string;
    songs: Song[]
}

export interface Genre {
    code: string;
    description: string;
}

export interface Song {
    name: string;
}

export class AlbumForm extends FormGroup {
    constructor() {
        super({
            author: new FormControl(null,  { validators: Validators.required, updateOn: 'blur'}),
            title: new FormControl(null, { validators: Validators.required, updateOn: 'blur'}),
            description: new FormControl(null, { validators: Validators.required, updateOn: 'blur'}),
            coverUrl: new FormControl(null, { validators: Validators.required, updateOn: 'blur'}),
            genreCode: new FormControl(Genres.HeavyMetal, { validators: Validators.required, updateOn: 'blur'}),
            musicBandName: new FormControl(null, { validators: Validators.required, updateOn: 'blur'}),
            songs: new FormArray([])
        })
    }
}

