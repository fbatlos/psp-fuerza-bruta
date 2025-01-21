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
            StreamReader sr = new StreamReader("C:\\Users\\pacob\\RiderProjects\\psp-fuerza-bruta\\psp-fuerza-bruta\\2151220-passwords.txt");
        
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