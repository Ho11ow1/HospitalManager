using System;
using System.IO;

class C_DB
{
    private C_User userdata = new C_User();
    public bool Fn_DB_Exist()
    {
        if (!File.Exists(Constants.DB_NAME))
        {
            try
            {
                using (FileStream fs = File.Create(Constants.DB_NAME))
                {
                    fs.Close();
                }
                Console.WriteLine("Database file created.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error creating database file: {e.Message}");
                return false;
            }
        }

        return true;
    }

    public void Fn_Save_To_DB()
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(Constants.DB_NAME, true))
            {
                DateTime time = DateTime.Now;

                sw.WriteLine("=====================\n");
                sw.WriteLine($"Account Created: {time}\n");
                sw.WriteLine($"Account ID: {userdata.Fn_GetID()}\n");


                sw.WriteLine("=====================\n\n");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error occurred while saving to DB: {e.Message}");
        }
    }
}