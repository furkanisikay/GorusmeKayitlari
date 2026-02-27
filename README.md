# 📋 Görüşme Kayıtları

![C#](https://img.shields.io/badge/C%23-.NET%20Framework%204.5.2-512BD4?logo=dotnet&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-Desktop-0078D4?logo=windows&logoColor=white)
![Material Design](https://img.shields.io/badge/Material%20Design-UI-757575?logo=materialdesign&logoColor=white)
![Access DB](https://img.shields.io/badge/Microsoft%20Access-Veritabanı-A4373A?logo=microsoftaccess&logoColor=white)
![Lisans](https://img.shields.io/badge/Lisans-MIT-green)

## 🎯 Neden Bu Proje?

Kurumlar arası görüşmelerin takibi genellikle dağınık notlar, e-postalar ve Excel tabloları arasında kaybolur. **Görüşme Kayıtları**, kurumların diğer kurumlarla gerçekleştirdiği tüm görüşmeleri merkezi bir sistem üzerinden kayıt altına alıp raporlayabilmesini sağlayan, rol tabanlı yetkilendirme sistemiyle güvenli, çoklu dışa aktarım formatlarıyla esnek bir masaüstü uygulamasıdır. Türkiye'deki kamu ve özel sektör kurumlarının görüşme yönetimi ihtiyacını karşılamak için tasarlanmıştır.

## 🏗️ Mimari ve Özellikler

- **Modüler Çok Katmanlı Mimari** — 7 ayrı proje ile sorumluluklar net bir şekilde ayrılmıştır (App, Core, Components, Extensions, Resources, Reminder, Updater)
- **Görüşme Yönetimi (CRUD)** — Görüşme, kurum, yetkili, kullanıcı ve kategori kayıtlarının eksiksiz yönetimi
- **Rol Tabanlı Yetkilendirme** — Nesne düzeyinde (ekleme, düzenleme, silme) detaylı izin sistemi
- **Çoklu Dışa Aktarım** — Excel, PDF ve HTML formatlarında özelleştirilebilir raporlama
- **Hatırlatma Sistemi** — Görüşme hatırlatıcıları ve masaüstü bildirim desteği
- **Eklenti Mimarisi** — Genişletilebilir yapı sayesinde yeni özellikler modüler olarak eklenebilir
- **Otomatik Güncelleme** — Dosya bütünlüğü doğrulamalı yerleşik güncelleme sistemi
- **Veri Şifreleme** — Hassas verilerin güvenli saklanması için yerleşik şifreleme altyapısı
- **Material Design Arayüz** — Modern ve kullanıcı dostu arayüz tasarımı

## 🚀 Hızlı Başlangıç

### Gereksinimler

- **İşletim Sistemi:** Windows 7 veya üzeri
- **Çalışma Zamanı:** [.NET Framework 4.5.2](https://dotnet.microsoft.com/download/dotnet-framework/net452) veya üzeri
- **IDE:** [Visual Studio 2015+](https://visualstudio.microsoft.com/) (geliştirme için)
- **Veritabanı:** Microsoft Access (OleDb sürücüsü)

### Kurulum

```bash
# 1. Depoyu klonlayın
git clone https://github.com/furkanisikay/GorusmeKayitlari.git

# 2. Proje dizinine gidin
cd GorusmeKayitlari

# 3. Çözüm dosyasını Visual Studio ile açın
start GorusmeKayitlari.sln
```

### Derleme

Visual Studio içinde:
1. **Çözüm Gezgini**'nde çözüme sağ tıklayın
2. **NuGet Paketlerini Geri Yükle** seçeneğini tıklayın
3. `Ctrl + Shift + B` ile projeyi derleyin
4. `F5` ile uygulamayı başlatın

Veya komut satırından:
```bash
# MSBuild ile derleme
msbuild GorusmeKayitlari.sln /p:Configuration=Release
```

## ⚙️ Ortam Kurulumu

1. **NuGet Paketleri**: İlk derlemede otomatik olarak geri yüklenir. Manuel geri yükleme için:
   ```bash
   nuget restore GorusmeKayitlari.sln
   ```

2. **Veritabanı**: Uygulama Microsoft Access (`.mdb` / `.accdb`) veritabanı kullanır. Veritabanı yolu, uygulama içindeki **Ayarlar** formundan veya Windows Kayıt Defteri üzerinden yapılandırılır.

3. **Bağımlılıklar**:
   | Paket | Açıklama |
   |-------|----------|
   | MaterialSkin | Material Design temalı arayüz bileşenleri |
   | iTextSharp | PDF dışa aktarım desteği |
   | Microsoft.Office.Interop.Excel | Excel dışa aktarım desteği |
   | WPFCustomMessageBox | Özelleştirilebilir mesaj kutuları |
   | CircularProgressBar | Dairesel ilerleme göstergesi |

## 📁 Proje Yapısı

```
GorusmeKayitlari/
├── GorusmeKayitlari.App/          # Ana WinForms uygulaması ve formlar
├── GorusmeKayitlari.Core/         # Veri erişim katmanı ve iş mantığı
├── GorusmeKayitlari.Components/   # Yeniden kullanılabilir arayüz bileşenleri
├── GorusmeKayitlari.Extensions/   # Eklenti sistemi (Hatırlatma, Dışa Aktarım, Loglama)
├── GorusmeKayitlari.Resources/    # Kaynak dosyaları ve simgeler
├── GorusmeKayitlari.Reminder/     # Hatırlatma servisi
├── GorusmeKayitlari.Reminder.Notify/ # Masaüstü bildirim uygulaması
├── GorusmeKayitlari.Updater/      # Otomatik güncelleme modülü
└── GorusmeKayitlari.sln           # Visual Studio çözüm dosyası
```

## 🤝 Katkıda Bulunma

Katkılarınızı bekliyoruz! Lütfen [CONTRIBUTING.md](CONTRIBUTING.md) dosyasını okuyarak nasıl katkıda bulunabileceğinizi öğrenin.

## 📄 Lisans

Bu proje [MIT Lisansı](LICENSE) ile lisanslanmıştır. Detaylar için `LICENSE` dosyasına bakınız.

---

**Geliştirici:** [Furkan IŞIKAY](https://github.com/furkanisikay) © 2021
