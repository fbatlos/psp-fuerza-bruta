namespace psp_fuerza_bruta;

using System;
using System.Security.Cryptography;
using System.Text;

public class HashPassword
{
    string sSourceData;
    byte[] tmpSource;
    

    public String getHash(string password)
    {
        byte[] tmpHash;
        sSourceData = password;
        //Create a byte array from source data.
        tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);
        
        //Compute hash based on source data.
        tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
        
       return ByteArrayToString(tmpHash);
    }
    
    
    static string ByteArrayToString(byte[] arrInput)
    {
        int i;
        StringBuilder sOutput = new StringBuilder(arrInput.Length);
        for (i=0;i < arrInput.Length; i++)
        {
            sOutput.Append(arrInput[i].ToString("X2"));
        }
        return sOutput.ToString();
    }
}