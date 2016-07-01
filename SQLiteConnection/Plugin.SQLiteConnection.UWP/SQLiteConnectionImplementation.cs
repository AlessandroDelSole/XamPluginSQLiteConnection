using Plugin.SQLiteConnection.Abstractions;
using System;
using SQLite;
using Windows.Storage;
using System.IO;

namespace Plugin.SQLiteConnection
{
    /// <summary>
    /// Implementation for Feature
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
                if (connection == null)
                {
                    throw new ArgumentNullException("Connection is null. Please invoke CreateConnection first");
                }
                return connection;
            }
        }

        /// <summary>
        /// Create a connection to the specified SQLite Database
        /// </summary>
        /// <param name="dbFileName"></param>
        public void CreateConnection(string dbFileName)
        {
            var path = Path.Combine(ApplicationData.
                Current.LocalFolder.Path, dbFileName);
            connection= new SQLite.SQLiteConnection(path);
        }
    }
}