using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineMobileShop.Entity;

namespace OnlineMobileShop.Respository
{
    public class UserRespo
    {
        public static List<User> userList = new List<User>();
        static UserRespo()
        {
            userList.Add(new User { userID = 1, name = "Mathan", phoneNumber = 7845122356, mailID = "mathankumarn@gmail.com", password="mathan" });
            userList.Add(new User { userID = 2, name = "Barathi", phoneNumber = 4564122356, mailID = "kumarn@gmail.com", password = "Barathi" });
            userList.Add(new User { userID = 3, name = "Kannan", phoneNumber = 7863122356, mailID = "mathan@gmail.com", password = "Kannan" });

        }
        public static IEnumerable<User> GetDetails()
        {
            return userList;
        }
        public static void Add(User user)
        {
            userList.Add(user);
        }
        public static void Delete(int userID)
        {
            User user = GetuserID(userID);
            if (user != null)
                userList.Remove(user);
        }
        public static void Update(User user)
        {
            User userValue = userList.Find(id => id.userID == user.userID);
            userValue.userID = user.userID;
            userValue.name = user.name;
            userValue.phoneNumber = user.phoneNumber;
            userValue.mailID = user.mailID;
        }
        public static User GetuserID(int userID)
        {
            return userList.Find(id => id.userID == userID);
        }
    
    }
}
