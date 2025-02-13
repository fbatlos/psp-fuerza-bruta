namespace psp_fuerza_bruta;

using System.IO;

public class Fichero
{
    public List<String> GetText()
    {
        List<String> listPassword = new List<String>();
        String line;
        try
        {
            
            string relativePath = "2151220-passwords.txt"; 
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

            if (!File.Exists(fullPath))
            {
                Console.WriteLine($"Error: No se encontró el archivo en {fullPath}");
            }

            StreamReader sr = new StreamReader(fullPath);
        
            line = sr.ReadLine();
            
            while (line != null)
            {
                line = sr.ReadLine();
                
                listPassword.Add(line);
            }
            
            sr.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        
        return listPassword;
    }
}