# Music shop

## Run application
Before runing application please run comand for database generation (CodeFirst)
- dotnet ef database update 'InitialState' -s '.' -p '../MusicShop.Infrastructure' --context 'MusicShopContext'

###
TODO: Configurate dockerfile for spa (client) and add it to docker-compose
TODO: Need to finish adjastments for postgress DB
TODO: Add authorization with certificat
