using BlazorSample2.Models;
using SQLite;
using System.Reflection;

namespace BlazorSample2.Utilities;

internal static class DBUtil
{

    private static bool CreateDB = false;

    public static string DBPath;
    public static string DBStructurePath;
    public static string InitialDataPath;

    // Variable for the SQLite connection
    private static SQLiteAsyncConnection Connection;

    public static List<Animal> Animals = new List<Animal>();


    public static async Task Init(
        bool ForceNewDB = false)
    {
        // delete file if exists
        if (ForceNewDB && File.Exists(DBPath))
		{
			try
			{
				File.Delete(DBPath);
			}
			catch (Exception ex)
			{
				ConsoleLog($"Error deleting {DBPath} file\n{ex.Message}");
			}
		}

		// open connection to DB
		if (Connection != null)
            return;
        Connection = new SQLiteAsyncConnection(DBPath);

        try
        {
            string SQLQuery = "SELECT * FROM Animal";
            Animals = (await Connection.QueryAsync<Animal>(SQLQuery)).ToList();
        }
        catch
        {
            CreateDB = true;
        }

        if (CreateDB)
        {

            //// create tables from models (not good because multiple primary keys are not yet supported)
            //await CreateTables();

            // create initial tables from SQL script in Embedded resource file (set in file  properties : Build action)
            string SQLScript = LoadScript(DBStructurePath);
            //ConsoleLog(SQLScript);
            await ExecuteSQLScript(SQLScript);
            ConsoleLog("Tables created in DB");
            // insert initial data from SQL script in Embedded resource file (set in file  properties : Build action)
            SQLScript = LoadScript(InitialDataPath);
            //ConsoleLog(SQLScript);
            await ExecuteSQLScript(SQLScript);
            ConsoleLog("Initial data inserted in DB");
        }

        // get all data from DB to memory
        GetAllData();

    }


    //private static async Task CreateTables()
    //{
    //    await conn.CreateTableAsync<Animal>();
    //    ConsoleLog("Table Animal was created");
    //}


    private static string LoadScript(
        string FileName)
    {
        string Data = "";
        //ConsoleLog(filename);

        using (Stream FileStream = GetStreamFromFile($"{FileName}"))
        {
            if (FileStream == null)
            {
                ConsoleLog($"Unable to read file '{FileName}'");
            }

            using (StreamReader Reader = new StreamReader(FileStream))
            {
                Data = Reader.ReadToEnd();
                if (string.IsNullOrEmpty(Data))
                {
                    ConsoleLog($"No data inside file '{FileName}'");
                }
            }
        }

        return Data;
    }


    public static Stream GetStreamFromFile(
        string FileName)
    {
        var CurrentAssembly = Assembly.GetExecutingAssembly();
        var AssemblyName = CurrentAssembly.GetName().Name.Replace("-", "_");
        string ResourceName = $"{AssemblyName}.{FileName}";
		//ConsoleLog(ResourceName);

		// NOTE: do not forget to : "Build action -> Embedded resource" appropriate files

		var Data = CurrentAssembly.GetManifestResourceStream(ResourceName);
        //ConsoleLog($"Data = {Data}");

        return Data;
    }


    public static async Task ExecuteSQLScript(
        string SQLScript)
    {
        foreach (string SQLQuery in SQLScript.Split(");"))
        {
            if (!string.IsNullOrWhiteSpace(SQLQuery))
            {
                //ConsoleLog($"{SQLQuery});");
                try
                {
					await Connection.ExecuteAsync($"{SQLQuery});");
				}
                catch (Exception ex) 
                {
					ConsoleLog($"Error executing {SQLQuery}\n{ex.Message}");
				}
			}
        }
    }


    public static async void GetAllData()
    {

        string SQLQuery = "";

        SQLQuery = "SELECT * FROM Animal";
        Animals = (await Connection.QueryAsync<Animal>(SQLQuery))
            .ToList();
        //foreach (Animal Row in Animals)
        //    ConsoleLog($"({Row.ID}) {Row.Name}");

    }


    public static async Task CreateAnimal(
        Animal CurrentAnimal)
    {
        int NbResults = 0;
        try
        {

			NbResults = await Connection.InsertAsync(
                CurrentAnimal);
            Animals.Add(CurrentAnimal);

            ConsoleLog($"{NbResults} animals created in DB");
 
        }
        catch (Exception ex)
        {
			ConsoleLog($"Failed to create {NbResults} animals in DB\n{ex.Message}");
		}

	}


    public static async Task UpdateAnimal(
        Animal CurrentAnimal)
    {
        int NbResults = 0;
        try
        {

            NbResults = await Connection.UpdateAsync(
                CurrentAnimal);

            ConsoleLog($"{NbResults} animals updated in DB");

        }
        catch (Exception ex)
        {
            ConsoleLog($"Failed to update {NbResults} animals in DB\n{ex.Message}");
        }

    }


    public static async Task DeleteAnimal(
        Animal CurrentAnimal)
    {
        int NbResults = 0;
        try
        {

            NbResults = await Connection.DeleteAsync(
                CurrentAnimal);

            ConsoleLog($"{NbResults} animals deleted in DB");

        }
        catch (Exception ex)
        {
            ConsoleLog($"Failed to delete {NbResults} animals in DB\n{ex.Message}");
        }

    }


    private static void ConsoleLog(
        string Message)
    {
        System.Diagnostics.Debug.WriteLine("*********************************************************************************");
        System.Diagnostics.Debug.WriteLine(Message);
        System.Diagnostics.Debug.WriteLine("*********************************************************************************");
    }

}
