using System.Collections.Generic;
using System.Linq;
using Forum.App.Controllers;
using Forum.Data;
using Forum.Models;

namespace Forum.App.Services
{
    public static class UserService
    {
        public static bool TryLogInUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            var forumData = new ForumData();

            bool userExist = forumData.Users.Any(u => u.Username == username && u.Password == password);

            return userExist;
        }

        public static SignUpStatus TrySignUpUser(string username, string password)
        {
            bool validUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            bool validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;

            if (!validUsername || !validPassword)
            {
                return SignUpStatus.DetailsError;
            }

            var forumData = new ForumData();

            bool userAlreadyExist = forumData.Users.Any(u => u.Username == username);

            if (!userAlreadyExist)
            {
                int userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
                User user = new User(userId, username, password, new List<int>());
                forumData.Users.Add(user);
                forumData.SaveChanges();

                return SignUpStatus.Success;
            }

            return SignUpStatus.UsernameTakenError;
        }

        internal static User GetUser(int userId)
        {
            var forumData = new ForumData();
            User user = forumData.Users.Find(u => u.Id == userId);

            return user;
        }

        internal static User GetUser(string username)
        {
            var forumData = new ForumData();
            User user = forumData.Users.Find(u => u.Username == username);

            return user;
        }
    }
}
