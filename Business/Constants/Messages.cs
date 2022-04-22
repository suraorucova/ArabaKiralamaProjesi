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
        internal static string MaintenanceTime = "Sitem bakimda";
        internal static string CarListed="Arabalar listelendi";
        internal static string BrandAdded="Marka eklendi";
        internal static string BrandAddedInvalid="Marka eklenmesi basarisiz";
        internal static string BrandUpdated="Marka guncellendi";
        internal static string BrandUpdatedInvalid="Marka guncellenmesi basarisiz";
    }
}
