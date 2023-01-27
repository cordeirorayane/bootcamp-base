using System.Data.SQLite;

public abstract class BaseDAO
{
    public string DataSourceFile => Environment.CurrentDirectory + "AppTarefasDB.sqlite";
    public SQLiteConnection Connection => new SQLiteConnection("DataSource="+ DataSourceFile);
}