using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    //işlmeler içerisinde dönülücek metinsel mesajların içerikleri için oluşturuldu. 
    public static class Messages
    {
        //Araba için
        public static string CarAdded = "Araba eklendi";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string CarListed = "Araba Listlendi";
        public static string CarUpdate = "Araba Bilgileri Güncellendi";
        public static string CarDeleted = "Araba Bilgileri Silindi";
        public static string CarDeletedError = "Silincek Araba Bulunamadı";


        //Brand için
        public static string BrandAdded = "Marka eklendi";
        public static string BrandNameInvalid = "Marka ismi geçersiz";
        public static string BrandListed = "Markalar Listlendi";
        public static string BrandUpdate = "Marka Bilgileri Güncellendi";
        public static string BrandDeleted = "Marka Bilgileri Silindi";
        public static string BrandDeletedError = "Silincek Marka Bulunamadı";

        //Color için
        public static string ColorAdded = "Renk eklendi";
        public static string ColorNameInvalid = "Renk geçersiz";
        public static string ColorListed = "Renk Listlendi";
        public static string ColorUpdate = "Renk Bilgileri Güncellendi";
        public static string ColorDeleted = "Renk Bilgileri Silindi";
        public static string ColorDeletedError = "Renk Marka Bulunamadı";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kulanıcı Bilgileri Silindi";
        public static string UserDeletedError = "Silincek Kullanıcı Bulunamadı";
        public static string UserListed = "Kullanıcılar Listlendi";
        public static string UserUpdate = "Kullanıcı Bilgileri Güncellendi";


        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri Bilgileri Silindi";
        public static string CustomerDeletedError = "Silincek Müşteri Bulunamadı";
        public static string CustomerListed = "Müşteri Listlendi";
        public static string CustomerUpdate = "Müşteri Bilgileri Güncellendi";


        public static string RentalAdded = "Kiralama eklendi";
        public static string RentalDeleted = "Kiralama Bilgileri Silindi";
        public static string RentalDeletedError = "Silincek Kiralama Bulunamadı";
        public static string RentalListed = "Kiralamalar Listlendi";
        public static string RentalUpdate = "Kiralama Bilgileri Güncellendi";
        public static string RentalUpdateError = "Güncellencek Kiralama Bulunamadı";

        public static string MaintenanceTime = "Server Bakım Zamanı";
    }
}
