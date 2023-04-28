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
            author: new FormControl(null,  { validators: Validators.required, updateOn: 'change'}),
            title: new FormControl(null, { validators: Validators.required, updateOn: 'change'}),
            description: new FormControl(null, { validators: Validators.required, updateOn: 'change'}),
            coverUrl: new FormControl(null, { validators: Validators.required, updateOn: 'change'}),
            genreCode: new FormControl(Genres.HeavyMetal, { validators: [Validators.required, Validators.maxLength(20)], updateOn: 'change'}),
            email: new FormControl(null, { validators:  [Validators.required, Validators.email], updateOn: 'change'}),
            songs: new FormArray([])
        })
    }
}

export class ConcertForm extends FormGroup {
    constructor() {
        super({
            author: new FormControl(null,  { validators: Validators.required, updateOn: 'change'}),
            concertStartDate: new FormControl(null, { validators: Validators.required, updateOn: 'change'}),
            concertEndDate: new FormControl(null, { validators: Validators.required, updateOn: 'change'}),
            concertTitle: new FormControl(null, { validators: Validators.required, updateOn: 'change'}),
            concertDescription: new FormControl(null, { validators: Validators.required, updateOn: 'change'}),
            email: new FormControl(null, { validators: [Validators.required, Validators.email], updateOn: 'change'}),
        })
    }
}

