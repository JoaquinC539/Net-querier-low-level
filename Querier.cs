using Config.Connection;
using Npgsql;
public class Querier
{
    public static List<Dictionary<string, object>> QueryIndex()
    {

        List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();
        using (NpgsqlConnection connection = Connection.Connect())
        {
            connection.Open();
            using (var cmd = new NpgsqlCommand("SELECT * FROM vendedores ORDER BY _id DESC", connection))
            {
                //var cmd = new NpgsqlCommand("INSERT INTO  myTable (field) VALUES (@p)", connection) // @ represent to be inserted
                //cmd.Parameters.AddWithValue("p","MyValue") //Insert for prepared statment
                //var read=cmd.ExecuteNonQuery(); execute for non returning sql statements
                //var read=cmd.ExecuteReader(); execute for returning sql statements
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Dictionary<string, object> row = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string columnName = reader.GetName(i);
                            object value = reader.GetValue(i);
                            row.Add(columnName, value);

                        }
                        results.Add(row);
                    }
                }

            }

        }
        return results;

    }

}