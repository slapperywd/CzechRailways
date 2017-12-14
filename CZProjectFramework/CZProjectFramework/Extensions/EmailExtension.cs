using System;
using System.IO;
using System.Linq;

namespace CZProjectFramework.Extensions
{
    public static class EmailExtension
    {
        private static readonly string PathToEmails =
            @"\\ecsc0010468b\CdCzFrame\mails.txt";

        public static string GetCurrentMail()
        {
            var allNames =
                File.ReadAllLines(PathToEmails);

            var currentEmail = allNames.First(x => !x.EndsWith(" +"));
            var number = allNames.Select((value, index) => new {value, index}).Where(t => !t.value.EndsWith(" +"))
                .Select(t => t.index).First();

            allNames[number] = currentEmail + " +";
            //another process exception
            File.WriteAllLines(PathToEmails, allNames);

            Console.WriteLine(currentEmail);
            return currentEmail;
        }
    }
}