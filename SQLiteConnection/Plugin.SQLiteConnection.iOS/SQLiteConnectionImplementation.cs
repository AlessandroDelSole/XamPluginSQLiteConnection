using Plugin.SQLiteConnection.Abstractions;
using System;
using SQLite;
using System.IO;

namespace Plugin.SQLiteConnection
{
    /// <summary>
    /// Implementation for SQLiteConnection
    /// </summary>
    public class SQLiteConnectionImplementation : ISQLiteConnection
    {
        private SQLite.SQLiteConnection connection;

        /// <summary>
        /// Return the connection to a SQLite database
        /// Assumes you invoked CreateConnection first
        /// </summary>
        public SQLite.SQLiteConnection Connection
        {
            get
            {
                if (connection==null)
                {
                    throw new ArgumentNullException("Connection is null. Please invoke CreateConnection first");
                }
                return connection;
            }
        }

        /// <summary>
        /// Create a connection to the specified SQLite database
        /// </summary>
        /// <param name="dbFileName"></param>
        public void CreateConnection(string dbFileName)
        {
            string personalFolder =
                System.Environment.
                GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder =
                Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dbFileName);
            this.connection= new SQLite.SQLiteConnection(path);
        }
    }
}