using System.Security.Cryptography;

using (Aes aes = Aes.Create())
{
    var crypto = aes.CreateEncryptor();

    using (FileStream inputStream = new FileStream("../../../text.txt", FileMode.Open, FileAccess.Read))
    using (FileStream outputStream = new FileStream("../../../cryptedText.txt", FileMode.Create, FileAccess.Write))
    using (CryptoStream cryptoStream = new CryptoStream(outputStream, crypto, CryptoStreamMode.Write))
    {
        inputStream.CopyTo(cryptoStream);
    }
}
