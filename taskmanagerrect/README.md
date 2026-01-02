# Görev Yöneticisi (Task Manager)

Bu proje, React ve TypeScript kullanılarak geliştirilmiş bir görev yönetimi uygulamasıdır. Backend API'si ile entegre çalışarak görevleri listeleme, ekleme ve güncelleme işlemlerini gerçekleştirir.

## Özellikler

- ✅ Görev listesi görüntüleme
- ✅ Yeni görev ekleme
- ✅ Mevcut görevleri düzenleme
- ✅ Görev durumu yönetimi (Bekliyor, Devam Ediyor, Tamamlandı)
- ✅ Responsive tasarım
- ✅ TypeScript desteği

## API Entegrasyonu

Uygulama aşağıdaki API endpoint'lerini kullanır:

### Görevleri Listele
```bash
curl -X 'GET' \
  'https://localhost:7291/api/tasks' \
  -H 'accept: */*'
```

### Yeni Görev Ekle
```bash
curl -X 'POST' \
  'https://localhost:7291/api/tasks' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
    "title": "string",
    "description": "string", 
    "status": 0,
    "isDeleted": false
  }'
```

### Görev Güncelle
```bash
curl -X 'PUT' \
  'https://localhost:7291/api/tasks/{id}' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
    "id": "guid",
    "title": "string",
    "description": "string",
    "status": 0
  }'
```

## Veri Modeli

### Task (Görev)
- `id`: string (GUID)
- `title`: string - Görev başlığı
- `description`: string - Görev açıklaması  
- `status`: TaskStatus - Görev durumu (0: Bekliyor, 1: Devam Ediyor, 2: Tamamlandı)
- `isDeleted`: boolean - Silinme durumu

## Kurulum ve Çalıştırma

1. Bağımlılıkları yükleyin:
```bash
npm install
```

2. Geliştirme sunucusunu başlatın:
```bash
npm run dev
```

3. Tarayıcınızda `http://localhost:5174` adresine gidin.

## Teknolojiler

- **React 19** - UI framework
- **TypeScript** - Type safety
- **Vite** - Build tool ve dev server
- **CSS3** - Styling

## Proje Yapısı

```
src/
├── components/          # React bileşenleri
│   ├── TaskList.tsx    # Görev listesi bileşeni
│   └── TaskForm.tsx    # Görev ekleme/düzenleme formu
├── services/           # API servisleri
│   └── taskService.ts  # Task API çağrıları
├── types/              # TypeScript tip tanımları
│   └── Task.ts         # Task ile ilgili tipler
├── App.tsx             # Ana uygulama bileşeni
├── App.css             # Ana stil dosyası
└── main.tsx            # Uygulama giriş noktası
```

## Kullanım

1. **Görev Listesi**: Ana sayfada tüm görevlerinizi görüntüleyebilirsiniz
2. **Yeni Görev Ekleme**: "Yeni Görev Ekle" butonuna tıklayarak form açılır
3. **Görev Düzenleme**: Her görevin yanındaki "Düzenle" butonuna tıklayarak güncelleme yapabilirsiniz
4. **Durum Yönetimi**: Görevlerin durumunu Bekliyor, Devam Ediyor veya Tamamlandı olarak ayarlayabilirsiniz

## API Gereksinimleri

Uygulamanın çalışması için backend API'sinin `https://localhost:7291` adresinde çalışıyor olması gerekir. CORS ayarlarının frontend için uygun şekilde yapılandırılmış olduğundan emin olun.