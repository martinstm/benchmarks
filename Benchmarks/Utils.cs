using Benchmarks.Extensions;
using Benchmarks.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Benchmarks
{
    public static class Utils
    {
        static string[] names = { "James", "Cate", "Dave", "Allen", "Monica", "Amy", "John", "Mark", "Rose", "Mike" };

        public static IEnumerable<User> GenerateRandomUserList(int size)
        {
            Random random = new Random();
            var list = new List<User>();

            while (size > 0)
            {
                int index = random.Next(names.Length);
                var randomName = names[index];

                var randomYears = random.Next(0, 10);

                list.Add(new User(randomName, randomName.ToEmail(), randomYears));

                size--;
            }
            return list;
        }

        public static IEnumerable<User> GenerateUserList(int size)
        {
            var list = new List<User>();

            while (size > 0)
            {
                foreach (var name in names)
                {
                    list.Add(new User(name, name.ToEmail()));
                    size--;
                    if (size == 0)
                        break;
                }
            }
            return list;
        }

        public static IEnumerable<int> GenerateRandomNumbersList(int size)
        {
            return Enumerable.Range(1, size);
        }

        public static IEnumerable<string> GenerateRandomStringList(int size)
        {
            var list = new List<string>();

            while (size > 0)
            {
                list.Add(Guid.NewGuid().ToString());
                size--;
            }
            return list;
        }

        /// <summary>
        /// Generates a list with half random values and another half with null values
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static IEnumerable<string> GenerateRandomStringListWithNull(int size)
        {
            var list = new List<string>();

            while (size > 0)
            {
                if (size % 2 == 0)
                {
                    list.Add(Guid.NewGuid().ToString());
                }
                else
                {
                    list.Add(null);
                }
                size--;

            }
            return list;
        }
    }
}
