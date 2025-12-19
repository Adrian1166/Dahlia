using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.IO;
using System.Text;

/// <summary>
/// Descrizione di riepilogo per Cripta
/// </summary>
public class Cripta
{
	public Cripta()
	{
		//
		// TODO: aggiungere qui la logica del costruttore
		//
	}

    public string Encrypt(string TextToBeEncrypted, string myPsw)
    {
        RijndaelManaged RijndaelCipher = new RijndaelManaged();
        string Password = myPsw;
        byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(TextToBeEncrypted);
        byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
        PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
        //Creates a symmetric encryptor object. 
        ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
        MemoryStream memoryStream = new MemoryStream();
        //Defines a stream that links data streams to cryptographic transformations
        CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
        cryptoStream.Write(PlainText, 0, PlainText.Length);
        //Writes the final state and clears the buffer
        cryptoStream.FlushFinalBlock();
        byte[] CipherBytes = memoryStream.ToArray();
        memoryStream.Close();
        cryptoStream.Close();
        string EncryptedData = Convert.ToBase64String(CipherBytes);
        return EncryptedData;
    }

    public string Decrypt(string TextToBeDecrypted, string myPsw)
    {
        RijndaelManaged RijndaelCipher = new RijndaelManaged();
        string Password = myPsw;
        byte[] EncryptedData = Convert.FromBase64String(TextToBeDecrypted);
        byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
        //Making of the key for decryption
        PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
        //Creates a symmetric Rijndael decryptor object.
        ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
        MemoryStream memoryStream = new MemoryStream(EncryptedData);
        //Defines the cryptographics stream for decryption.THe stream contains decrpted data
        CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);
        byte[] PlainText = new byte[EncryptedData.Length];
        int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);
        memoryStream.Close();
        cryptoStream.Close();
        //Converting to string
        string DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);
        return DecryptedData;
    }

    public string getMD5Hash(string input)
    {
        System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
        bs = x.ComputeHash(bs);
        System.Text.StringBuilder s = new System.Text.StringBuilder();
        foreach (byte b in bs)
        {
            s.Append(b.ToString("x2").ToLower());
        }
        string hash = s.ToString();
        return hash;
    }
}
