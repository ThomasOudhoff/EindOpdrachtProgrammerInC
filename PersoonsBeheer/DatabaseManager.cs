using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

public class DatabaseManager
{
    private static string dbPath = "Data Source=mydatabase.db;Version=3;";

    public static void CreateDatabase()
    {
        using (SQLiteConnection connection = new SQLiteConnection(dbPath))
        {
            connection.Open();

            string createTablesQuery = @"
                CREATE TABLE IF NOT EXISTS Persons (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Age INTEGER NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Educations (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT NOT NULL,
                    SuccessRate REAL NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Jobs (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT NOT NULL,
                    HireChance REAL NOT NULL
                );";

            using (SQLiteCommand command = new SQLiteCommand(createTablesQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            if (IsTableEmpty("Persons", connection))
            {
                InsertInitialData(connection);
            }
        }
    }

    private static bool IsTableEmpty(string tableName, SQLiteConnection connection)
    {
        string query = $"SELECT COUNT(*) FROM {tableName}";
        using (SQLiteCommand command = new SQLiteCommand(query, connection))
        {
            long count = (long)command.ExecuteScalar();
            return count == 0;
        }
    }

    private static void InsertInitialData(SQLiteConnection connection)
    {
        string insertDataQuery = @"
            INSERT INTO Persons (Name, Age) VALUES
            ('Joke', 25), ('Bob', 30), ('Nelly', 28),
            ('Henk', 35), ('Emma', 22), ('Frank', 40),
            ('Niels', 26), ('Linda', 33), ('Tom', 29), ('Jack', 31);

            INSERT INTO Educations (Title, SuccessRate) VALUES
            ('Informatica', 0.8), ('Economie', 0.6), ('Techniek', 0.7),
            ('Marketing', 0.5), ('Rechten', 0.9), ('Psychologie', 0.65),
            ('Biologie', 0.75), ('Kunst', 0.4), ('Sport', 0.55), ('Muziek', 0.3);

            INSERT INTO Jobs (Title, HireChance) VALUES
            ('Software Engineer', 0.85), ('Data Analyst', 0.7), ('Marketeer', 0.6),
            ('Advocaat', 0.75), ('Onderzoeker', 0.65), ('HR Manager', 0.55),
            ('Leraar', 0.8), ('Kunstenaar', 0.4), ('Sportcoach', 0.5), ('Muzikant', 0.3);
        ";

        using (SQLiteCommand insertCommand = new SQLiteCommand(insertDataQuery, connection))
        {
            insertCommand.ExecuteNonQuery();
        }
    }

    public static DataTable GetPersons()
    {
        DataTable dt = new DataTable();

        try
        {
            using (SQLiteConnection connection = new SQLiteConnection(dbPath))
            {
                connection.Open();

                string query = @"
                    SELECT 
                        Persons.Id, 
                        Persons.Name, 
                        Persons.Age, 
                        Educations.Title AS Education, 
                        Jobs.Title AS Job
                    FROM Persons
                    LEFT JOIN Educations ON Persons.Id % 10 = Educations.Id % 10
                    LEFT JOIN Jobs ON Persons.Id % 10 = Jobs.Id % 10";

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.Fill(dt);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Fout bij ophalen van personen: " + ex.Message, "Database Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        return dt;
    }

    public static void AddPerson(string name, int age)
    {
        try
        {
            using (SQLiteConnection connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                string query = "INSERT INTO Persons (Name, Age) VALUES (@name, @age)";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@age", age);
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Fout bij toevoegen van persoon: " + ex.Message, "Database Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static void DeletePerson(int id)
    {
        try
        {
            using (SQLiteConnection connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                string query = "DELETE FROM Persons WHERE Id = @id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Fout bij verwijderen van persoon: " + ex.Message, "Database Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static void UpdatePerson(int id, string name, int age)
    {
        try
        {
            using (SQLiteConnection connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                string query = "UPDATE Persons SET Name = @name, Age = @age WHERE Id = @id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@age", age);
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Fout bij updaten van persoon: " + ex.Message, "Database Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

