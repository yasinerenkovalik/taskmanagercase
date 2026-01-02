# Docker ile Task Manager Çalıştırma

Bu proje React frontend, .NET API ve PostgreSQL veritabanını Docker Compose ile aynı anda çalıştırır.

## Gereksinimler
- Docker
- Docker Compose

## Çalıştırma

### 1. Tüm servisleri başlat
```bash
docker-compose up --build
```


## Erişim URL'leri
- **React Frontend**: http://localhost:3000
- **.NET API**: http://localhost:5001
- **PostgreSQL**: localhost:5432

## Servisler

### Database (PostgreSQL)
- Port: 5432
- Database: taskmanager_db
- User: taskmanager_user
- Password: taskmanager_pass


