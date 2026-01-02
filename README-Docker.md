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

### 2. Arka planda çalıştır
```bash
docker-compose up -d --build
```

### 3. Logları izle
```bash
docker-compose logs -f
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

### API (.NET)
- Port: 5000
- Environment: Development
- CORS: React için yapılandırılmış

### React Frontend
- Port: 3000
- Development server (hot reload)
- API URL: http://localhost:5000

## Yararlı Komutlar

### Servisleri durdur
```bash
docker-compose down
```

### Veritabanı verilerini sil
```bash
docker-compose down -v
```

### Sadece belirli servisi yeniden başlat
```bash
docker-compose restart api
docker-compose restart react
docker-compose restart db
```

### Container'lara bağlan
```bash
# API container'ına bağlan
docker exec -it taskmanager_api bash

# React container'ına bağlan
docker exec -it taskmanager_react sh

# Database container'ına bağlan
docker exec -it taskmanager_db psql -U taskmanager_user -d taskmanager_db
```

## Sorun Giderme

### Port çakışması
Eğer portlar kullanılıyorsa, docker-compose.yml'de port numaralarını değiştirin.

### Build hataları
```bash
# Cache'i temizle ve yeniden build et
docker-compose build --no-cache
```

### Veritabanı bağlantı sorunu
API container'ı veritabanından önce başlarsa, birkaç saniye bekleyip yeniden dener.