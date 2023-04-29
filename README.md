# Music shop

## Run application
Before runing application please run comand for database generation (CodeFirst)
- dotnet ef database update 'InitialState' -s './MusicShop' -p './MusicShop.Infrastructure' --context 'MusicShopContext'
- rebuild and run application in VS


### TODO List
- Add logger
- Add certificate
- Configurate dockerfile for spa (client) and add it to docker-compose
- Need to finish adjastments for postgress DB
- Add authorization with certificat
- Cover with Unit Tests

### Add new migration
- dotnet ef migrations add 'InitialState' -s './MusicShop' -p './MusicShop.Infrastructure' --context 'MusicShopContext'