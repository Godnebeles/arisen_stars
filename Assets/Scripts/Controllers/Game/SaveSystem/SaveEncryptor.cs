using System;


public class SaveEncryptor
{
    private const int encryptingKey = 237;

    public string Encrypt(string str)
    {
        string result = "";

        for (int i = 0; i < str.Length; i++)
        {
            if (Char.IsDigit(str[i]))
                result += str[i] ^ encryptingKey;
            else
                result += Convert.ToChar(str[i] ^ encryptingKey);
        }

        return result;
    }

    public string Decrypt(string str)
    {
        string result = "";

        for (int i = 0; i < str.Length; i++)
        {
            
            result += str[i] ^ encryptingKey;
            
           
        }

        return result;
    }
}