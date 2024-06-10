namespace VigenereCipher;

class Program
{
    private const int ALPHABET_LENGTH = 26;
    private const int ASCII_A_CHAR = 97;
    
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a key:");
        string key;
        do
        {
            key = Console.ReadLine();
            if (key.Length == 0)
                Console.WriteLine("Invalid input. Please enter a valid key:");
        } while (key.Length == 0);

        Console.WriteLine("Enter the text to cipher:");
        string text = Console.ReadLine();

        Console.WriteLine("Do you want to (1) Cipher or (2) Decipher?");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            string cipheredText = CipherText(text, key);
            Console.WriteLine("Ciphered Text: " + cipheredText);
        }
        else if (choice == "2")
        {
            string decipheredText = DecipherText(text, key);
            Console.WriteLine("Deciphered Text: " + decipheredText);
        }
        else
        {
            Console.WriteLine("Invalid choice. Please enter 1 or 2.");
        }
    }

    private static string CipherText(string plainText, string key)
    {
        char[] cipheredText = new char[plainText.Length];
        int keyIndex = 0;
        for (int i = 0; i < plainText.Length; i++)
        {
            if (plainText[i] == ' ')
            {
                cipheredText[i] = plainText[i];
                continue;
            }
            cipheredText[i] = CipherChar(plainText[i], key[keyIndex]);
            keyIndex++; 
            keyIndex %= key.Length;
        }

        return new string(cipheredText);
    }
    
    private static char CipherChar(char textChar, char keyChar)
    {
        int column = GetAlphabetPosition(textChar);
        int row = GetAlphabetPosition(keyChar);

        return (char)(ASCII_A_CHAR + (column + row) % ALPHABET_LENGTH);
    }
    
    private static string DecipherText(string cipherText, string key)
    {
        char[] plainText = new char[cipherText.Length];
        int keyIndex = 0;
        for (int i = 0; i < cipherText.Length; i++)
        {
            if (cipherText[i] == ' ')
            {
                plainText[i] = cipherText[i];
                continue;
            }
            plainText[i] = DecipherChar(cipherText[i], key[keyIndex]);
            keyIndex++; 
            keyIndex %= key.Length;
        }

        return new string(plainText);
    }

    private static char DecipherChar(char textChar, char keyChar)
    {
        int map = GetAlphabetPosition(textChar);
        int row = GetAlphabetPosition(keyChar);

        int value = map - row;
        if (value < 0) value += ALPHABET_LENGTH;
        return (char)(ASCII_A_CHAR + value);
    }
    
    private static int GetAlphabetPosition(char textChar)
    {
        // a = 0, z = 25
        return textChar - ASCII_A_CHAR;
    }
}
