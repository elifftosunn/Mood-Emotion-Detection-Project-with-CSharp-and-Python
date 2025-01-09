# 🎵 Ruh Hali Tespitine Dayalı Kişiselleştirilmiş Müzik Öneri Sistemi

Bu proje, kullanıcıların yüz ifadelerinden ruh halini tespit ederek, anlık duygusal durumlarına uygun müzik türleri öneren bir sistem geliştirmeyi amaçlamaktadır. YOLO tabanlı bir derin öğrenme modeli ile yüz ifadesi analizi yapılarak duygu durumları doğru bir şekilde belirlenir ve kişiselleştirilmiş müzik önerileri sunulur.

## 🚀 Projenin Hedefleri
- **Ruh Halini Dinamik Bir Parametre Olarak Ele Alma:** Ruh hali, bir anlık veri olarak değil, zaman içinde değişen bir parametre olarak ele alınmaktadır. Bu sayede kullanıcıların ruh hali dalgalanmalarına göre günün farklı saatlerinde farklı müzik türleri önerilir.
- **Öğrenen Sistem:** Sistem zamanla kullanıcıların müzik tercihlerini öğrenerek öneri doğruluğunu artırır. Bu durum daha isabetli ve kişiye özel müzik önerileri sunulmasını sağlar.
- **Kolay Kullanıcı Deneyimi:** Kullanıcıların kolayca giriş yapabileceği ve kayıt olabileceği bir arayüz sağlanır.
- **Veri Yönetimi:** Duygu durum geçmişi ve önerilen müzikler optimize edilmiş bir MSSQL veritabanında saklanır.

## 🛠️ Kullanılan Teknolojiler

| Teknoloji                 | Açıklama                                                                                 |
|---------------------------|-----------------------------------------------------------------------------------------|
| ![YOLO](https://img.shields.io/badge/YOLO-DeepLearning-blue?style=flat-square) | YOLO tabanlı derin öğrenme modeli, yüz ifadesi analizi için kullanıldı.  |
| ![C#](https://img.shields.io/badge/C%23-WindowsForms-purple?style=flat-square) | Kullanıcı arayüzü C# Windows Forms ile geliştirildi.                      |
| ![MSSQL](https://img.shields.io/badge/MSSQL-Database-red?style=flat-square)   | Veritabanı yönetimi için Microsoft SQL Server kullanıldı.                |
| ![Python](https://img.shields.io/badge/Python-Programming%20Language-yellow?style=flat-square) | YOLO modeli entegrasyonu ve veri analizi için Python kullanıldı. |


## 🌟 Temel Özellikler
- **Yüz İfadesi Analizi:** YOLO tabanlı model ile anlık duygusal durum tespiti.
- **Yazılı İfade Analizi:** Kullanıcının yazılı ifadelerinden ruh hali analizi.
- **Kişiselleştirilmiş Müzik Önerileri:** Kullanıcının ruh hali ve tercihlerini dikkate alarak öneri yapılması.
- **Ruh Hali Geçmişi Analizi:** Zaman içindeki ruh hali dalgalanmalarını takip etme.
- **Veritabanı Entegrasyonu:** MSSQL kullanılarak kullanıcı verileri, duygu durumu geçmişi ve öneriler saklanır.

## 📊 Veritabanı Yapısı

Veritabanı, kullanıcılara özel veri ve sistem önerilerini saklamak için optimize edilmiştir. Aşağıda tabloların genel yapısı açıklanmıştır:

| Tablo Adı               | Açıklama                                                                                   |
|--------------------------|-------------------------------------------------------------------------------------------|
| **Users**               | Kullanıcı bilgilerini (ID, ad, e-posta, şifre vb.) saklar.                                |
| **UserPreferences**     | Kullanıcıların müzik tercihlerini ve ayarlarını içerir.                                   |
| **Sessions**            | Kullanıcı oturum bilgilerini (giriş tarihi, süresi vb.) tutar.                            |
| **MoodHistory**         | Kullanıcıların ruh hali değişim geçmişini saklar.                                         |
| **Musics**              | Sistemde önerilen veya kullanıcı tarafından dinlenen müziklerin detaylarını içerir.       |
| **MusicGenres**         | Müzik türlerini ve bu türlere ait açıklamaları içerir.                                    |
| **MusicRecommendations** | Kullanıcıya önerilen müzikler ve öneri tarihleri gibi bilgileri saklar.                   |

## 📖 Proje Akışı
1. Kullanıcı giriş yapar veya yeni bir hesap oluşturur.
2. Yüz ifadesi ile anlık ruh hali tespit edilir.
3. Ruh haline uygun müzik türleri önerilir.
4. Öneri geçmişi MSSQL veritabanına kaydedilir.
5. Sistem kullanıcı tercihlerini öğrenerek öneri doğruluğunu artırır.

## 📂 Kurulum ve Kullanım

1. **Depoyu Klonlayın:**
   ```bash
   git clone https://github.com/elifftosunn/Mood-Emotion-Detection-Project-with-CSharp-and-Python.git
   cd Mood-Emotion-Detection-Project-with-CSharp-and-Python
2. **Gerekli Bağımlılıkları Yükleyin:**

- MSSQL Server kurulumunu tamamlayın ve bağlantı dizesini yapılandırın.
- C# Nuget Packages üzerinden System.Data.SqlClient 4.9.0 sürümünü indirin.

3. **Uygulamayı Çalıştırın:**
- Visual Studio kullanarak projeyi açın ve çalıştırın.
