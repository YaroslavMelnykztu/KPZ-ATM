using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ATM.Models;
using ATM.Services;

namespace ATM.Data
{
    public class FileStorage
    {
        private static FileStorage instance;
        private string filePath = "database.json";

        private FileStorage() { }

        public static FileStorage GetInstance()
        {
            if (instance == null)
            {
                instance = new FileStorage();
            }
            return instance;
        }

        public void SaveAccounts(List<Account> accounts)
        {
            string json = JsonConvert.SerializeObject(accounts, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public List<Account> LoadAccounts()
        {
            if (!File.Exists(filePath))
            {
                PasswordHasher hasher = new PasswordHasher();
                List<Account> defaultAccounts = new List<Account>
                {
                    new Account { CardNumber = "1111", PinCode = hasher.HashPassword("1234"), Balance = 5000.0, OwnerName = "Test User" },
                    new Account { CardNumber = "2222", PinCode = hasher.HashPassword("0000"), Balance = 1000.0, OwnerName = "Receiver" }
                };

                SaveAccounts(defaultAccounts);
                return defaultAccounts;
            }

            string json = File.ReadAllText(filePath);
            List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(json);

            return accounts ?? new List<Account>();
        }

        public void LogTransaction(string message)
        {
            string logEntry = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " | " + message + Environment.NewLine;
            File.AppendAllText("transactions.log", logEntry);
        }

        public string[] GetLogs()
        {
            if (!File.Exists("transactions.log"))
            {
                return new string[0];
            }
            return File.ReadAllLines("transactions.log");
        }
    }
}
