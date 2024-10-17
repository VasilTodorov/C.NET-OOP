namespace Problem2Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Transposition cypher demo.");
            var plaintext = "IAMENCRYPTED";

            TranspositionCypher transpositionCypher = new TranspositionCypher("beauty") ;
            var encryptedText = transpositionCypher.Encrypt(plaintext);
            Console.WriteLine($"Encrypt: {plaintext} : {encryptedText}");

            var decryptedText = transpositionCypher.Decrypt(encryptedText);
            Console.WriteLine($"Decrypt: {encryptedText} : {decryptedText}");
        }
    }
}