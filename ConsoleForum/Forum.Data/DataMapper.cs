using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Forum.Models;

namespace Forum.Data
{
    public class DataMapper
    {
        private const string DATA_PATH = "../../../../data/";
        private const string CONFIG_PATH = "config.ini";
        private const string DEFAULT_CONFIG = "users=users.csv\r\ncategories=categories.csv\r\nposts=posts.csv\r\nreplies=replies.csv";

        private static readonly Dictionary<string, string> config;

        static DataMapper()
        {
            Directory.CreateDirectory(DATA_PATH);
            config = LoadConfig(DATA_PATH + CONFIG_PATH);
        }

        private static void EnsureConfigFile(string configFilePath)
        {
            if (!File.Exists(configFilePath))
            {
                File.WriteAllText(configFilePath, DEFAULT_CONFIG);
            }
        }

        private static void EnsureFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        private static Dictionary<string, string> LoadConfig(string configFilePath)
        {
            EnsureConfigFile(configFilePath);

            var contents = ReadLines(configFilePath);

            var config = contents
                .Select(l => l.Split('='))
                .ToDictionary(t => t[0], t => DATA_PATH + t[1]);

            return config;
        }

        private static string[] ReadLines(string path)
        {
            EnsureFile(path);
            var lines = File.ReadAllLines(path);
            return lines;
        }

        private static void WriteLines(string path, string[] lines)
        {
            File.WriteAllLines(path, lines);
        }

        public static List<Category> LoadCategories()
        {
            var categories = new List<Category>();
            var dataLines = ReadLines(config["categories"]);

            foreach (var dataLine in dataLines)
            {
                var args = dataLine.Split(";", StringSplitOptions.RemoveEmptyEntries);
                int id = int.Parse(args[0]);
                string name = args[1];

                var postIds = args.Length > 2 ? args[2]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList() : new List<int>();

                var category = new Category(id, name, postIds);
                categories.Add(category);
            }

            return categories;
        }

        public static void SaveCategories(List<Category> categories)
        {
            var lines = new List<string>();

            foreach (var category in categories)
            {
                string line = $"{category.Id};{category.Name};{string.Join(",", category.PostIds)}";
                lines.Add(line);
            }

            WriteLines(config["categories"], lines.ToArray());
        }

        public static List<User> LoadUsers()
        {
            var users = new List<User>();
            var dataLines = ReadLines(config["users"]);

            foreach (var dataLine in dataLines)
            {
                var args = dataLine.Split(";", StringSplitOptions.RemoveEmptyEntries);
                int id = int.Parse(args[0]);
                string username = args[1];
                string password = args[2];
                var postIds = args.Length > 3 ? args[3]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList() : new List<int>();

                var user = new User(id, username, password, postIds);
                users.Add(user);
            }

            return users;
        }

        public static void SaveUsers(List<User> users)
        {
            var lines = new List<string>();

            foreach (var user in users)
            {
                string line = $"{user.Id};{user.Username};{user.Password};{string.Join(",", user.PostIds)}";
                lines.Add(line);
            }

            WriteLines(config["users"], lines.ToArray());
        }

        public static List<Post> LoadPosts()
        {
            var posts = new List<Post>();
            var dataLines = ReadLines(config["posts"]);

            foreach (var dataLine in dataLines)
            {
                var args = dataLine.Split(";", StringSplitOptions.RemoveEmptyEntries);
                int id = int.Parse(args[0]);
                string title = args[1];
                string content = args[2];
                int categoryId = int.Parse(args[3]);
                int authorId = int.Parse(args[4]);
                var replyIds = args.Length > 5 ? args[5]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList() : new List<int>();

                var post = new Post(id, title, content, categoryId, authorId, replyIds);
                posts.Add(post);
            }

            return posts;
        }

        public static void SavePosts(List<Post> posts)
        {
            var lines = new List<string>();

            foreach (var post in posts)
            {
                string line = $"{post.Id};{post.Title};{post.Content};{post.CategoryId};{post.AuthorId};{string.Join(",", post.ReplyIds)}";
                lines.Add(line);
            }

            WriteLines(config["posts"], lines.ToArray());
        }

        public static List<Reply> LoadReplies()
        {
            var replies = new List<Reply>();
            var dataLines = ReadLines(config["replies"]);

            foreach (var dataLine in dataLines)
            {
                var args = dataLine.Split(";", StringSplitOptions.RemoveEmptyEntries);
                int id = int.Parse(args[0]);
                string content = args[1];
                int authorId = int.Parse(args[2]);
                int postId = int.Parse(args[3]);

                var reply = new Reply(id, content, authorId, postId);
                replies.Add(reply);
            }

            return replies;
        }

        public static void SaveReplies(List<Reply> replies)
        {
            var lines = new List<string>();

            foreach (var reply in replies)
            {
                string line = $"{reply.Id};{reply.Content};{reply.AuthorId};{reply.PostId}";
                lines.Add(line);
            }

            WriteLines(config["replies"], lines.ToArray());
        }
    }
}
