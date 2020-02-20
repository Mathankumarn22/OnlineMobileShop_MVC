using System.Collections.Generic;
using OnlineMobileShop.Entity;

namespace OnlineMobileShop.Respository
{
    public class MobileRespository
    {
        public static List<Mobile> mobilelist = new List<Entity.Mobile>();

        static MobileRespository()
        {

            mobilelist.Add(new Mobile { MobileID = 1, Brand = "Nokia", Model = "y22", Battery = 3000, Price = 6000 });

            mobilelist.Add(new Mobile { MobileID = 2, Brand = "Vivo", Model = "v5", Battery = 4000, Price = 8000 });

            mobilelist.Add(new Mobile { MobileID = 3, Brand = "Oppo", Model = "f1", Battery = 5000, Price = 11000 });
        }
        public static IEnumerable<Mobile> GetDetails()
        {
            return mobilelist;
        }

        public static void Add(Mobile mobile)
        {
            mobilelist.Add(mobile);
        }
        public static void Delete(int MobileID)
        {
            Mobile mobile = GetMobileID(MobileID);
            if (mobile != null)
                mobilelist.Remove(mobile);
        }

        public static void Update(Mobile mobile)
        {
            Mobile mobilesValue = mobilelist.Find(id => id.MobileID == mobile.MobileID);
            mobilesValue.MobileID = mobile.MobileID;
            mobilesValue.Brand = mobile.Brand;
            mobilesValue.Model = mobile.Model;
            mobilesValue.Battery = mobile.Battery;
            mobilesValue.Price = mobile.Price;
        }
        public static Mobile GetMobileID(int MobileID)
        {
            return mobilelist.Find(id => id.MobileID == MobileID);
        }
    }
}