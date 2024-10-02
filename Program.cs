class Program
{
    static bool IsTxtFile(string path1)
    {
        Console.Write("Path daxil edin:");
        var path = Console.ReadLine();
        string extension = Path.GetExtension(path);
        return string.Equals(extension, ".txt", StringComparison.OrdinalIgnoreCase);
    }

    static void EncryptFile(string inputFile, string outputFile, string key)
    {
        string content = File.ReadAllText(inputFile);
        string encryptedContent = SimpleEncrypt(content, key);
        File.WriteAllText(outputFile, encryptedContent);
    }
    static string SimpleEncrypt(string text, string key)
    {
        char[] buffer = text.ToCharArray();
        for (int i = 0; i < buffer.Length; i++)
        {
            buffer[i] = (char)(buffer[i] + key.Length);
        }
        return new string(buffer);

    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter path:");
        var pathFile = Console.ReadLine();
        if (IsTxtFile(pathFile))
        {
            var key = Console.ReadLine();
            string encryptedFilePath = pathFile + ".enc"; 
            EncryptFile(pathFile, encryptedFilePath, key);
            Console.WriteLine($"Fayl şifrələnərək {encryptedFilePath} adında saxlanıldı.");

        }
        else
        {
            Console.WriteLine("Bu txt fayli deyil.Yeni path daxil edin:");

        }
    }
}


