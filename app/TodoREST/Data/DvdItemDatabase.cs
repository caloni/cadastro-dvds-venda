using SQLite;
using TodoREST.Models;

namespace TodoREST.Data;

public class DvdItemDatabase
{
    string DatabasePath;
    SQLiteConnection Database;
    public DvdItemDatabase()
    {
    }
    void Init()
    {
        if (Database is not null)
            return;

        DatabasePath = Path.Combine(FileSystem.AppDataDirectory, Constants.DatabaseFilename);
        Database = new SQLiteConnection(DatabasePath, Constants.Flags);
        var result = Database.CreateTable<DvdItem>();
    }

    public TableQuery<DvdItem> GetItems()
    {
        Init();
        return Database.Table<DvdItem>();
    }

    public TableQuery<DvdItem> GetItemsNotDone()
    {
        Init();
        return Database.Table<DvdItem>();
        
        // SQL queries are also possible
        //return await Database.Query<DvdItem>("SELECT * FROM [DvdItem] WHERE [Done] = 0");
    }

    public DvdItem GetItem(string id)
    {
        Init();
        return Database.Table<DvdItem>().Where(i => i.id == id).FirstOrDefault();
    }

    public int SaveItem(DvdItem item)
    {
        Init();
        if (item.id.Length > 0)
        {
            return Database.Update(item);
        }
        else
        {
            return Database.Insert(item);
        }
    }

    public int DeleteItem(DvdItem item)
    {
        Init();
        return Database.Delete(item);
    }
}