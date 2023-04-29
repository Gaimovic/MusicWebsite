# Music shop

## Run application
- Download application and run it in visual studio (Database will be generated on run)


### TODO List
- Add logger
- Add certificate
- Configurate dockerfile for spa (client) and add it to docker-compose
- Need to finish adjastments for postgress DB
- Add authorization with certificat
- Cover with Unit Tests
- Add Cloud image store

### Add new migration
- dotnet ef migrations add 'InitialState' -s './MusicShop' -p './MusicShop.Infrastructure' --context 'MusicShopContext'
- dotnet ef database update 'InitialState' -s './MusicShop' -p './MusicShop.Infrastructure' --context 'MusicShopContext'