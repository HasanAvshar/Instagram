using Instagram;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

Main main = new Main();
main.main();
class Main
{
    public void main()
    {
        Post p1 = new Post("Post 1");
        Post p2 = new Post("Post 2");
        Post p3 = new Post("Post 3");

        Database.AddPost(p1);
        Database.AddPost(p2);
        Database.AddPost(p3);
        int select = 1;

        do
        {
            Console.Clear();
            if (select == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[1] => Admin");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("[2] => User");
                Console.WriteLine("[3] => Exit");
            }
            else if (select == 2)
            {
                Console.WriteLine("[1] => Admin");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[2] => User");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("[3] => Exit");
            }

            else if (select == 3)
            {
                Console.WriteLine("[1] => Admin");
                Console.WriteLine("[2] => User");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[3] => Exit");
                Console.ForegroundColor = ConsoleColor.White;
            }

            ConsoleKeyInfo info = Console.ReadKey(true);
            if (info.Key == ConsoleKey.UpArrow)
            {
                if (select == 1) select = 3;
                else select--;
            }
            else if (info.Key == ConsoleKey.DownArrow)
            {
                if (select == 3) select = 1;
                else select++;
            }

            if (info.Key == ConsoleKey.Enter)
            {
                if (select == 3)
                {
                    Console.WriteLine("Good bye");
                    Console.ReadLine();
                    Environment.Exit(0);
                    break;
                }
                else if (select == 1)
                {
                    Admin admin = new Admin();
                    admin.AdminMenu();
                    Console.ReadLine();
                }
                else if (select == 2)
                {

                    do
                    {
                        Console.Clear();
                        User user = new User();
                        user.UserMenu();
                        user.DisplayAllPosts();
                        User u1 = new User("Hesen", "Avshar", "hesen@gmail.com", "123456");

                        Database.AddUser(u1);
                        Database.AddPost(p1);
                        Database.AddPost(p2);
                        Database.AddPost(p3);

                        p1.Calculate();
                        p2.Calculate();
                        p3.Calculate();
                    } while (true);

                }
            }
        } while (true);
    }
}
namespace Instagram
{
    class Admin
    {
        public void AdminMenu()
        {
            int select = 1;

            do
            {
                Console.Clear();
                if (select == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[1] => Add Post");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[2] => Delete Post");
                    Console.WriteLine("[3] => Show All Posts");
                    Console.WriteLine("[4] => Show Notifications");
                    Console.WriteLine("[5] => Exit");
                }
                else if (select == 2)
                {
                    Console.WriteLine("[1] => Add Post");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[2] => Delete Post");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[3] => Show All Posts");
                    Console.WriteLine("[4] => Show Notifications");
                    Console.WriteLine("[5] => Exit");
                }

                else if (select == 3)
                {
                    Console.WriteLine("[1] => Add Post");
                    Console.WriteLine("[2] => Delete Post");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[3] => Show All Posts");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[4] => Show Notifications");
                    Console.WriteLine("[5] => Exit");
                }
                else if (select == 4)
                {
                    Console.WriteLine("[1] => Add Post");
                    Console.WriteLine("[2] => Delete Post");
                    Console.WriteLine("[3] => Show All Posts");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[4] => Show Notifications");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[5] => Exit");
                }
                else if (select == 5)
                {
                    Console.WriteLine("[1] => Add Post");
                    Console.WriteLine("[2] => Delete Post");
                    Console.WriteLine("[3] => Show All Posts");
                    Console.WriteLine("[4] => Show Notifications");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[5] => Exit");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                ConsoleKeyInfo info = Console.ReadKey(true);
                if (info.Key == ConsoleKey.UpArrow)
                {
                    if (select == 1) select = 5;
                    else select--;
                }
                else if (info.Key == ConsoleKey.DownArrow)
                {
                    if (select == 5) select = 1;
                    else select++;
                }

                if (info.Key == ConsoleKey.Enter)
                {
                    if (select == 5)
                    {
                        break;
                    }
                    else if (select == 1)
                    {
                        AddPost();
                    }
                    else if (select == 2)
                    {
                        DeletePost();
                    }
                    else if (select == 3)
                    {
                        ShowAllPosts();
                    }
                    else if (select == 4)
                    {
                        ShowNotifications();
                    }
                }
            } while (true);
        }

        public void AddPost()
        {
            Console.Clear();
            Console.WriteLine("Enter post content:");
            string content = Console.ReadLine();
            Post post = new Post(content);
            Database.AddPost(post);
            Console.WriteLine("Post added successfully.");
            Console.ReadLine();
        }

        public void DeletePost()
        {
            Console.Clear();
            Console.WriteLine("Enter post ID to delete:");
            Guid postId = Guid.Parse(Console.ReadLine());
            if (Database.GetPosts().RemoveAll(p => p.Id == postId) > 0)
            {
                Console.WriteLine("Post deleted successfully.");
            }
            else
            {
                Console.WriteLine("Post not found.");
            }
            Console.ReadLine();
        }

        public void ShowAllPosts()
        {

            foreach (Post post in Database.GetPosts())
            {
                post.Show();
            }
            Console.ReadLine();

        }

        public void ShowNotifications()
        {
            Console.Clear();
            foreach (Notification notification in Database.GetNotifications())
            {
                Console.WriteLine("From: " + notification.FromUser + ", Action: " + notification.Action + ", Post ID: " + notification.PostId + ", Date: " + notification.DateTime);
            }
            Console.ReadLine();
        }

    }
    class User
    {
        static public List<User> Users = new List<User>();
        public int _id;
        public string _name;
        public string _surname;
        public int _age;
        public string _email;
        public string _password;


        public User()
        {
            _id = Guid.NewGuid().GetHashCode();
        }
        public User(string name, string surname, string email, string password)
        {
            _id = Guid.NewGuid().GetHashCode();
            _name = name;
            _surname = surname;
            _email = email;
            _password = password;
        }

        public int Id
        {
            get { return _id; }
        }


        public string Name
        {
            get { return _name; }
            set
            {
                if (value != null && value.Length > 3 && value.Length < 20)
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentException("Name must be between 3 and 20 characters");
                }
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                if (value != null && value.Length > 3 && value.Length <= 20)
                {
                    _surname = value;
                }
                else
                {
                    throw new ArgumentException("Surname must be between 3 and 20 characters");
                }
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if (value != null && value > 0 && value <= 100)
                {
                    _age = value;
                }
                else
                {
                    throw new ArgumentException("Name must be between 1 and 100 characters");
                }
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (value != null && value.Length > 5 && value.Length <= 30 && value.EndsWith(".com"))
                {
                    _email = value;
                }
                else
                {
                    throw new ArgumentException("Email must be between 5 and 20 characters and end with '.com'");
                }
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (value.Length > 5 && value.Length <= 20)
                {
                    _password = value;
                }
                else
                {
                    throw new ArgumentException("Email must be between 6 and 20 characters");
                }
            }
        }
        public void Like(Guid postId)
        {
            Post post = Database.GetPosts().Find(p => p.Id == postId);
            if (post != null)
            {
                post.Like(this);
                Console.WriteLine("Post liked successfully");
            }
            else
            {
                Console.WriteLine("Post not found");
            }
            Console.ReadLine();
        }

        public void View(Guid postId)
        {
            Post post = Database.GetPosts().Find(p => p.Id == postId);
            if (post != null)
            {
                post.View(this);
                Console.WriteLine("Admin notified that you are watching.");
            }
            else
            {
                Console.WriteLine("Post not found");
            }
            Console.ReadLine();
        }
        public void UserMenu()
        {
            int select = 1;

            do
            {
                Console.Clear();
                if (select == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[1] => Login");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[2] => Register");
                    Console.WriteLine("[3] => Exit");
                }
                else if (select == 2)
                {
                    Console.WriteLine("[1] => Login");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[2] => Register");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[3] => Exit");
                }

                else if (select == 3)
                {
                    Console.WriteLine("[1] => Login");
                    Console.WriteLine("[2] => Register");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[3] => Exit");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                ConsoleKeyInfo info = Console.ReadKey(true);
                if (info.Key == ConsoleKey.UpArrow)
                {
                    if (select == 1) select = 3;
                    else select--;
                }
                else if (info.Key == ConsoleKey.DownArrow)
                {
                    if (select == 3) select = 1;
                    else select++;
                }

                if (info.Key == ConsoleKey.Enter)
                {
                    if (select == 3)
                    {
                        Main main = new Main();
                        main.main();
                    }
                    else if (select == 1)
                    {
                        Login();
                        break;
                    }
                    else if (select == 2)
                    {
                        Register();
                        break;
                    }
                }
            } while (true);

        }

        public static void Login()
        {
            bool check = true;
            do
            {
                Console.WriteLine("Enter email: ");
                string email = Console.ReadLine();

                Console.WriteLine("Enter password: ");
                string password = Console.ReadLine();

                User user = Users.Find(u => u.Email == email && u.Password == password);
                if (user != null || email == "hesen@gmail.com" && password == "123456")
                {
                    Console.WriteLine("Login successful");
                    check = false;
                }
                else
                {
                    Console.WriteLine("Invalid email or password");
                }
            } while (check);
        }

        public static void Register()
        {
            Console.Clear();
            User user = new User();

            Console.WriteLine("Enter name: ");
            user.Name = Console.ReadLine();

            Console.WriteLine("Enter surname: ");
            user.Surname = Console.ReadLine();

            Console.WriteLine("Enter age: ");
            user.Age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter email: ");
            user.Email = Console.ReadLine();
            string recipientEmail = user.Email;
            user.Password = "123456";
            string password = user.Password;

            Network network = new Network();
            network.SendMail(recipientEmail);

            Console.WriteLine("Enter the code sent to Gmail: ");
            string code = Console.ReadLine();

            if (code == password)
            {

                Database.AddUser(user);
                Console.WriteLine("User registered");
            }
            else
            {
                Console.WriteLine("Invalid code. Registration failed.");
            }
            Console.Clear();
        }

        public void DisplayAllPosts()
        {
            Console.Clear();
            foreach (Post post in Database.GetPosts())
            {
                post.Show();
            }

        }
    }

    class Post
    {
        public Guid Id { get; private set; }
        public string Content { get; set; }
        public DateTime CreationDateTime { get; private set; }
        public int LikeCount { get; private set; }
        public int ViewCount { get; private set; }

        public Post(string content)
        {
            Id = Guid.NewGuid();
            Content = content;
            CreationDateTime = DateTime.Now;
            LikeCount = 0;
            ViewCount = 0;
        }

        public void Show()
        {
            Console.WriteLine("Post ID: " + Id);
            Console.WriteLine("Content: " + Content);
            Console.WriteLine("Creation Date Time: " + CreationDateTime);
            Console.WriteLine("Like Count: " + LikeCount);
            Console.WriteLine("View Count: " + ViewCount);
            Console.WriteLine();
        }
        public void Like(User user)
        {
            LikeCount++;
            NotifyAdmin(user, "liked");
        }

        public void View(User user)
        {
            ViewCount++;
            NotifyAdmin(user, "viewed");
        }

        private void NotifyAdmin(User user, string action)
        {
            Notification notification = new Notification
            {
                FromUser = user.Name + " " + user.Surname,
                Action = action,
                PostId = Id,
                DateTime = DateTime.Now
            };
            Database.AddNotification(notification);
        }

        public void Calculate()
        {
            while (true)
            {
                User user = new User();
                Console.WriteLine("If you want to like, type L: ");
                Console.WriteLine("Type W if you want to tell the admin that you are watching: ");
                Console.WriteLine("'E' to exit: ");

                string choice = Console.ReadLine();

                if (choice == "E")
                {
                    break;
                }
                Console.WriteLine("Enter the Guid of the post you want to like: ");
                Guid postId = Guid.Parse(Console.ReadLine());

                Post post = Database.GetPosts().Find(p => p.Id == postId);
                if (post == null)
                {
                    Console.WriteLine("Post not found");
                    return;
                }
                else if (choice == "L")
                {
                    post.LikeCount++;
                    Console.WriteLine("Post liked successfully");

                }
                else if (choice == "W")
                {
                    post.ViewCount++;
                    Console.WriteLine("Admin notified that you are watching.");

                }
                else
                {
                    throw new ArgumentException("Choice can be 'W' or 'L'");
                }
                user.DisplayAllPosts(); 
            }
           

        }
    }
    record Notification
    {
        public string FromUser { get; set; }
        public string Action { get; set; }
        public Guid PostId { get; set; }
        public DateTime DateTime { get; set; }
    }
    class Network
    {
        public void SendMail(string recipientEmail)
        {
            string subject = "Instagram Code";
            string body = "123456";
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("hesenavs1@gmail.com", "nyvc brqn ttec pbsv");
            smtpClient.EnableSsl = true;

            message.From = new MailAddress("hesenavs1@gmail.com");
            message.To.Add(new MailAddress(recipientEmail));
            message.Subject = subject;
            message.Body = body;

            smtpClient.Send(message);
        }
    }
    class Database
    {
        private static List<User> _users = new List<User>();
        private static List<Post> _posts = new List<Post>();
        private static List<Admin> _admin = new List<Admin>();

        public static List<User> GetUsers() { return _users; }
        public static List<Post> GetPosts() { return _posts; }
        public List<Admin> GetAdmins() { return _admin; }
        private static List<Notification> _notifications = new List<Notification>();


        public static void AddUser(User user)
        {
            if (user != null)
            {
                _users.Add(user);
            }
            else
            {
                throw new ArgumentNullException(nameof(user), "User object cannot be null.");
            }
        }


        public static void AddPost(Post post)
        {
            if (post != null)
            {
                _posts.Add(post);
            }
            else
            {
                throw new ArgumentNullException(nameof(post), "Post object cannot be null.");
            }
        }

        public static void DisplayUsers()
        {
            foreach (User user in _users)
            {
                Console.WriteLine("Name: " + user.Name + ", Surname: " + user.Surname + ", Age: " + user.Age + ", Email: " + user.Email + ", Id: " + user.Id);
            }
        }

        public static void DisplayPosts()
        {
            foreach (Post post in _posts)
            {
                Console.WriteLine("Content: " + post.Content + ", Like Count: " + post.LikeCount + ", View Count: " + post.ViewCount);
            }
        }

        public static void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public static List<Notification> GetNotifications()
        {
            return _notifications;
        }
    }
}
