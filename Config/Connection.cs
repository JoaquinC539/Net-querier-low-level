using Npgsql;

namespace Config.Connection;

public class Connection
{    
    
    public static NpgsqlConnection Connect()
    {
        string conString="Host=localhost:5432;Username=postgres;Password=MyPassword;Database=MyDatabase";        
        return new NpgsqlConnection(conString);
        
    }
}