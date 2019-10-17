using System;
using System.Data.SQLite;

namespace TestCalculator
{
    public class DatabaseCalculator : ICalculator
    {
        private const string ConnectionString = "FullUri=file::memory:?cache=shared";

        public int Result { get; private set; }

        public void EnterNumber(int number)
        {
            using (var con = new SQLiteConnection(ConnectionString).OpenAndReturn())
            {
                var command = con.CreateCommand();
                command.CommandText = "INSERT INTO calc VALUES (?)";
                var param = command.CreateParameter();
                param.Value = number;
                command.Parameters.Add(param);
                command.ExecuteNonQuery();
            }
        }

        public void Add()
        {
            using (var con = new SQLiteConnection(ConnectionString).OpenAndReturn())
            {
                var command = con.CreateCommand();
                command.CommandText = "Select SUM(numbers) FROM calc";
                Result = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public void Clear()
        {
            using (var con = new SQLiteConnection(ConnectionString).OpenAndReturn())
            {
                var command2 = con.CreateCommand();
                command2.CommandText = "CREATE TABLE IF NOT EXISTS calc ( numbers INTEGER);";
                command2.ExecuteNonQuery();

                var command1 = con.CreateCommand();
                command1.CommandText = "DELETE FROM calc";
                command1.ExecuteNonQuery();
            }
        }
    }
}
