using System;
using System.IO;

class DataBase
{
    #region Public Methods
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

    // Saves user data to database file
    // Parameters:
    //   userData: User object containing the data to save
    public void Fn_Save_To_DB(User userData)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(Constants.DB_NAME, true))
            {
                WriteUserData(sw, userData);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error occurred while saving to DB: {e.Message}");
        }
    }
    #endregion

    #region Private Methods
    private void WriteUserData(StreamWriter sw, User userData)
    {
        DateTime time = DateTime.Now;
        sw.WriteLine("=====================");
        sw.WriteLine($"Account Created: {time}");
        sw.WriteLine($"Account ID: {userData.UserId}");
        sw.WriteLine($"User Name: {userData.UserName}");
        sw.WriteLine($"User Surname: {userData.UserSurname}");
        sw.WriteLine($"User Password: {userData.UserPassword}");
        sw.WriteLine("=====================\n");
    }
    #endregion
}