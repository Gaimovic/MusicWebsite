import { Genres } from "../models/album.model"

export const getGenres  = () => {
    return [
        {
            code: Genres.HeavyMetal,
            description: 'Heavy Metal'
        },
        {
            code: Genres.Pop,
            description: 'Pop'
        },
        {
            code: Genres.Rock,
            description: 'Rock'
        }
    ]
}