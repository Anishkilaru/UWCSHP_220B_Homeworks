using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2Project
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            List<String> names=users.Where(u => u.Password == "hello").Select(u=>u.Name).ToList();
            foreach(String name in names)
            {
                Console.WriteLine(name);
            }

            users.RemoveAll(u => u.Name.Equals(u.Password, StringComparison.OrdinalIgnoreCase));

            var user = users.Where(u => u.Password == "hello").FirstOrDefault();
            users.Remove(user);

            foreach (var usr in users)
            {
                Console.WriteLine(String.Format("{0} {1}", usr.Name,usr.Password));
            }

            Console.ReadLine();
        }

    }
}
