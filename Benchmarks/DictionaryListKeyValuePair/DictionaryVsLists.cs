using BenchmarkDotNet.Attributes;
using Benchmarks.Models;
using System.Collections.Generic;
using System.Linq;

namespace Benchmarks.DictionaryListKeyValuePair
{
    [RankColumn]
    [MemoryDiagnoser]
    public class DictionaryVsLists
    {
        Dictionary<string, User> dictionary;
        List<KeyValuePair<string, User>> keyValuePairs;
        List<User> list;
        List<MyCustomKeyValue> customKeyValues;

        string email;
        string newEmail;

        User user;
        User newUser;

        [Params(10, 100, 1000)]
        public int listSize;

        [GlobalSetup]
        public void Setup()
        {
            email = "new-user@mail.com";
            user = new User("NewUser", email);

            newEmail = "new-user2@mail.com";
            newUser = new User("NewUser2", newEmail);
        }

        private void Init()
        {
            list = Utils.GenerateUserList(listSize).ToList();
            list.Add(user);

            dictionary = list.ToDictionary(x => x.Email);

            keyValuePairs = new List<KeyValuePair<string, User>>();
            keyValuePairs.AddRange(dictionary);
            customKeyValues = list.Select(x => new MyCustomKeyValue
            {
                Key = x.Email,
                Value = x
            }).ToList();
        }

        #region Add
        [Benchmark]
        public void List_Add()
        {
            Init();
            list.Add(newUser);
        }

        [Benchmark]
        public void Dictionary_Add()
        {
            Init();
            dictionary.Add(newEmail, newUser);
        }

        [Benchmark]
        public void Dictionary_Add_Index()
        {
            Init();
            dictionary[newEmail] = newUser;
        }

        [Benchmark]
        public void KeyValuePair_Add_With_Create()
        {
            Init();
            keyValuePairs.Add(KeyValuePair.Create(newEmail, newUser));
        }

        [Benchmark]
        public void KeyValuePair_Add()
        {
            Init();
            keyValuePairs.Add(new KeyValuePair<string, User>(newEmail, newUser));
        }
        #endregion

        #region Search
        [Benchmark]
        public User List_Find()
        {
            Init();
            var user = list.Find(x => x.Email == email);
            return user;
        }

        [Benchmark]
        public User List_SingleOrDefault()
        {
            Init();
            var user = list.SingleOrDefault(x => x.Email == email);
            return user;
        }

        [Benchmark]
        public User List_Where()
        {
            Init();
            var user = list.Where(x => x.Email == email).SingleOrDefault();
            return user;
        }

        [Benchmark]
        public User Dictionary_GetIndex()
        {
            Init();
            var user = dictionary[email];
            return user;
        }

        [Benchmark]
        public User Dictionary_TryGet()
        {
            Init();
            if (dictionary.TryGetValue(email, out var existingUser))
            {
                return existingUser;
            }
            return default;
        }

        [Benchmark]
        public User KeyValuePair_Find()
        {
            Init();
            return keyValuePairs.Find(x => x.Key == email).Value;
        }

        [Benchmark]
        public User KeyValuePair_SingleOrDefault()
        {
            Init();
            var user = keyValuePairs.SingleOrDefault(x => x.Key == email).Value;
            return user;
        }

        [Benchmark]
        public User Custom_KeyValuePair_Find()
        {
            Init();
            var user = customKeyValues.Find(x => x.Key == email).Value;
            return user;
        }

        [Benchmark]
        public User Custom_KeyValuePair_SingleOrDefault()
        {
            Init();
            var user = customKeyValues.SingleOrDefault(x => x.Key == email).Value;
            return user;
        }
        #endregion
    }
}
