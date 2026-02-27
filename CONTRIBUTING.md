# 🤝 Katkıda Bulunma Rehberi

Görüşme Kayıtları projesine katkıda bulunmak istediğiniz için teşekkür ederiz! Bu rehber, katkı sürecini kolaylaştırmak için hazırlanmıştır.

## 📋 Başlamadan Önce

1. Projeyi **fork** edin
2. Kendi fork'unuzu yerel makinenize klonlayın:
   ```bash
   git clone https://github.com/KULLANICI_ADINIZ/GorusmeKayitlari.git
   ```
3. Upstream remote'u ekleyin:
   ```bash
   git remote add upstream https://github.com/furkanisikay/GorusmeKayitlari.git
   ```

## 🔄 Geliştirme Süreci

1. **Yeni bir dal (branch) oluşturun:**
   ```bash
   git checkout -b ozellik/yeni-ozellik-adi
   ```
   Dal isimlendirme kuralları:
   - `ozellik/` — Yeni özellikler için
   - `duzeltme/` — Hata düzeltmeleri için
   - `dokuman/` — Dokümantasyon değişiklikleri için

2. **Değişikliklerinizi yapın** ve test edin.

3. **Commit mesajlarınızı anlamlı yazın:**
   ```bash
   git commit -m "Kategori filtreleme özelliği eklendi"
   ```

4. **Değişikliklerinizi push edin:**
   ```bash
   git push origin ozellik/yeni-ozellik-adi
   ```

5. **Pull Request (PR) açın** ve değişikliklerinizi açıklayın.

## 📐 Kod Standartları

- **Değişken, sınıf ve fonksiyon isimleri** evrensel standartlarda (İngilizce) yazılmalıdır
- **Yorum satırları ve açıklamalar** Türkçe olmalıdır
- Mevcut kod stiline uygun yazın
- Her yeni özellik için gerekli açıklamaları ekleyin

## 🐛 Hata Bildirimi

Hata bildirmek için [GitHub Issues](https://github.com/furkanisikay/GorusmeKayitlari/issues) sayfasını kullanın. Hata bildiriminizde şunları belirtin:

1. **Hatanın açıklaması** — Ne olması gerekiyordu ve ne oldu?
2. **Yeniden üretme adımları** — Hatayı nasıl tetikleyebiliriz?
3. **Ortam bilgisi** — İşletim sistemi, .NET sürümü vb.
4. **Ekran görüntüleri** — Varsa ekran görüntüsü ekleyin.

## 💡 Özellik Önerisi

Yeni bir özellik önermek için [GitHub Issues](https://github.com/furkanisikay/GorusmeKayitlari/issues) sayfasında bir issue açın ve `özellik` etiketi ekleyin.

## 📄 Lisans

Katkıda bulunarak, katkılarınızın projenin [MIT Lisansı](LICENSE) kapsamında lisanslanacağını kabul etmiş olursunuz.
