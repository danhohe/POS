/*using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CryptoWalletSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> passphrases = new List<string> { "passphrase1", "passphrase2", "passphrase3" }; // replace with actual passphrases to search for
            List<CryptoWallet> wallets = new List<CryptoWallet>();

            foreach (string passphrase in passphrases)
            {
                CryptoWallet wallet = GetWalletInfo(passphrase);
                if (wallet.Balance > 0)
                {
                    wallets.Add(wallet);
                }
            }

            WriteToFile(wallets);
        }
        static CryptoWallet GetWalletInfo(string passphrase)
        {
            string url = $"https://api.blockchair.com/bitcoin/dashboards/address/balance?address={passphrase}"; // replace with actual API endpoint
            HttpClient client = new HttpClient();
            string json = client.GetStringAsync(url).Result;
            JObject obj = JObject.Parse(json);

            JToken dataToken = obj["data"];
            decimal balance = 0;
            if (dataToken is JArray dataArray)
            {
                if (dataArray.Count > 0)
                {
                    JObject firstDataObject = dataArray[0] as JObject;
                    JToken balanceToken = firstDataObject["balance"];
                    if (balanceToken != null && balanceToken is JValue balanceValue)
                    {
                        balance = (decimal)balanceValue.Value;
                    }
                }
            }
            else if (dataToken is JObject dataObject)
            {
                JToken balanceToken = dataObject["balance"];
                if (balanceToken != null && balanceToken is JValue balanceValue)
                {
                    balance = (decimal)balanceValue.Value;
                }
            }
            else
            {
                throw new Exception("Unexpected data format.");
            }

            CryptoWallet wallet = new CryptoWallet
            {
                Address = passphrase,
                Balance = balance
            };

            return wallet;
        }




        static void WriteToFile(List<CryptoWallet> wallets)
        {
            string filename = "cryptowallets.txt";
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (CryptoWallet wallet in wallets)
                {
                    writer.WriteLine($"Address: {wallet.Address}, Balance: {wallet.Balance}");
                }
            }
            Console.WriteLine($"Data written to {filename}");
        }
    }

    class CryptoWallet
    {
        public string Address { get; set; }
        public decimal Balance { get; set; }
    }
}*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace CryptoWalletSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> passphrases = new List<string> { "passphrase1", "passphrase2", "passphrase3" }; // replace with actual passphrases to search for
            List<CryptoWallet> wallets = new List<CryptoWallet>();

            Console.WriteLine("Starting search...");
            foreach (string passphrase in passphrases)
            {
                CryptoWallet wallet = GetWalletInfo(passphrase);
                if (wallet.Balance > 0)
                {
                    wallets.Add(wallet);
                }
                Console.WriteLine($"Checked address: {passphrase}");
            }

            WriteToFile(wallets);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static CryptoWallet GetWalletInfo(string passphrase)
        {
            string url = $"https://api.blockchair.com/bitcoin/dashboards/address/balance?address={passphrase}"; // replace with actual API endpoint
            HttpClient client = new HttpClient();
            string json = client.GetStringAsync(url).Result;
            JObject obj = JObject.Parse(json);

            JToken dataToken = obj["data"];
            decimal balance = 0;
            if (dataToken is JArray dataArray)
            {
                if (dataArray.Count > 0)
                {
                    JObject firstDataObject = dataArray[0] as JObject;
                    JToken balanceToken = firstDataObject["balance"];
                    if (balanceToken != null && balanceToken is JValue balanceValue)
                    {
                        balance = (decimal)balanceValue.Value;
                    }
                }
            }
            else if (dataToken is JObject dataObject)
            {
                JToken balanceToken = dataObject["balance"];
                if (balanceToken != null && balanceToken is JValue balanceValue)
                {
                    balance = (decimal)balanceValue.Value;
                }
            }
            else
            {
                throw new Exception("Unexpected data format.");
            }

            CryptoWallet wallet = new CryptoWallet
            {
                Address = passphrase,
                Balance = balance
            };

            return wallet;
        }

        static void WriteToFile(List<CryptoWallet> wallets)
        {
            string filename = "cryptowallets.txt";
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (CryptoWallet wallet in wallets)
                {
                    writer.WriteLine($"Address: {wallet.Address}, Balance: {wallet.Balance}");
                }
            }
            Console.WriteLine($"Data written to {filename}");
        }
    }

    class CryptoWallet
    {
        public string Address { get; set; }
        public decimal Balance { get; set; }
    }
}