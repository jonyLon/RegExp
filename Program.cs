using System.Text;
using System.Text.RegularExpressions;

namespace RegExp
{


    internal class Program
    {
        static void Main(string[] args)
        {

            {// 1
                using (StreamWriter sr = new StreamWriter("template.txt"))
                {
                    sr.Write("Це є текстовий файл із декількома дробовими числами.\r\nПриклади дробових чисел: 3.14, 0.5, -2.75, 10, 7, 123.456\r\nІнші числа: -15, 42, 8.0, 6\r\n3,14");
                }
                string line = "";
                using (StreamReader sr = new StreamReader("template.txt"))
                {
                    line = sr.ReadToEnd();
                    Console.WriteLine(line);

                }
                string pattern = @"\d+.\d+|\d+,\d+";
                Match match = Regex.Match(line, pattern);
                while (match.Success)
                {
                    Console.WriteLine($"Value: {match.Value, -10} Index: {match.Index}");
                    match = match.NextMatch();
                }
            }


            {// 2
                using (StreamWriter sr = new StreamWriter("obscene.txt"))
                {
                    sr.Write("Це бля що таке. Блін блінський. Хрень якась сталась. Ну не хера собі");
                }
                Console.OutputEncoding = Encoding.UTF8;
                string line = "";
                using (StreamReader sr = new StreamReader("obscene.txt"))
                {
                    line = sr.ReadToEnd();
                }
                string pattern = @"бля|блін|хрень|хер";
                var res = Regex.Replace(line, pattern, "*",RegexOptions.IgnoreCase);
                using (StreamWriter sr = new StreamWriter("correct.txt"))
                {
                    sr.Write(res);
                }
                Console.WriteLine(res);
            }
            {// 3
                using (StreamWriter sr = new StreamWriter("template2.txt"))
                {
                    sr.Write("Це є текстовий файл із декількома дробовими числами.\r\nПриклади дробових чисел: 3.14, 0.5, -2.75, 10, 7, 123.456\r\nІнші числа: -15, 42, 8.0, 6\r\n");
                }
                Console.OutputEncoding = Encoding.UTF8;
                string line = "";
                using (StreamReader sr = new StreamReader("template2.txt"))
                {
                    line = sr.ReadToEnd();
                    Console.WriteLine();
                }
                string pattern = @"\d+";
                List<int> digits = new List<int>();
                Match match = Regex.Match(line, pattern);
                while (match.Success)
                {
                    digits.Add(int.Parse(match.Value));
                    match = match.NextMatch();
                }
                foreach (var item in digits)
                {
                    Console.Write(item + "  ");
                }
                Console.WriteLine();
            }
            {// 4
                string passwordPattern = @"((^[A-Za-z0-9_-]*$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[-_])).{6,}";
                string loginPattern = @"[A-Za-z0-9._-]{4,}@(([a-zA-Z0-9])(?=.*\.)).{2,}";
                Dictionary<string, string> credentials = new Dictionary<string, string>
                {
                    {"user1@example.com", "Password123!"},
                    {"john.doe@email.com", "Doe-@1234"},
                    {"alice_smithgmail.com", "SecurePass456"},
                    {"admin@admin.com", "Admin_Pass789"},
                    {"test.user@yahoo.com", "TestUser@987"},
                    {"jane_doe@hotmail.com", "JaneDoe_Pwd"},
                    {"superuser@examplecom", "Super-Pass789"},
                    {"developer@test.com", "DevPass123"},
                    {"cus@gmail.com", "Cust-ome_r12345!"},
                    {"manager@example.org", "er-P6"}
                };
                var regexLogin = new Regex(loginPattern);
                var regexPassword = new Regex(passwordPattern);
                Console.WriteLine();
                foreach (var item in credentials)
                {
                    var log = regexLogin.IsMatch(item.Key);
                    var pass = regexPassword.IsMatch(item.Value);
                    Console.WriteLine($"Login {item.Key} is valid: {log,-20}Password {item.Value} is valid: {pass,-20}");
                }
            }



        }
    }
}