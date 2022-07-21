using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarAddedInvalid = "Araba eklenmesi basarisiz";
        public static string CarDeletedInvalid = "Araba silinmesi basarisiz";
        public static string MaintenanceTime = "Sitem bakimda";
        public static string CarListed="Arabalar listelendi";
        public static string BrandAdded="Marka eklendi";
        public static string BrandAddedInvalid="Marka eklenmesi basarisiz";
        public static string BrandUpdated="Marka guncellendi";
        public static string BrandUpdatedInvalid="Marka guncellenmesi basarisiz";
        public static string CustomerAdded="Müsteri eklendi";
        public static string CustomerListed="Müsteriler listelendi";
        public static string ReturnInvalid="Araba teslim edilmemiştir. Bu yüzden yeni araba kiralanamaz";
        public static string RentalAdded=" Araba kiralandi";
        public static string RentalDelete=" Araba kiralama kaydı silindi";
        public static string RentalDeleteInvalid="Araba kiralama kaydı silinmesi başarısız oldu";
        public static string RentalListed=" Araba kiralama kaytları listelendi";
        public static string UserAdded="Kullanıcı eklendi";
        public static string UserDeleted=" Kullanıcı silindi";
        public static string UsersListed=" Kullanıcılar listelendi";
        public static string UserUpdated=" Kullanıcı bilgileri güncellendi";
        public static string ColorGetByName="Renk bulundu ";
        public static string ColorAdded="Renk eklendi";
        internal static string CarImageAdded;
        internal static string CarImageDelete;
        internal static string CarImageUpdate;
        internal static string ColorImageAdded;
        internal static string ColorImageDeleted;
        internal static string ColorImageUpdated;
    }
}
