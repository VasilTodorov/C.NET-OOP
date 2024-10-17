namespace Homework3RouteCipher
{
    public class TestCipher
    {
        static void Main(string[] args)
        {
            int key = -4;
            RouteCipher a = new RouteCipher(key);

            string toEncrypt = "THISISTHEPLAINTEXT";
            string encrypted = a.Encrypt(toEncrypt);
            string decrypted = a.Decrypt(encrypted);

            Console.WriteLine($"cipher key is: {key}");
            Console.WriteLine($"is to be encrypted: {toEncrypt}");
            Console.WriteLine($"after encryption:   {encrypted}");
            Console.WriteLine($"after decryption:   {decrypted}");
        }
    }
}
