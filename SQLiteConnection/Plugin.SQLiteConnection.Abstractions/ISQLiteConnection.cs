using System;
using SQLite;

namespace Plugin.SQLiteConnection.Abstractions
{
  /// <summary>
  /// Interface for SQLiteConnection
  /// </summary>
  public interface ISQLiteConnection
  {
        /// <summary>
        /// Create a connection to the specified SQLite database
        /// </summary>
        /// <param name="dbFileName"></param>
        void CreateConnection(string dbFileName);

        /// <summary>
        /// Return the connection to a SQLite database
        /// Assumes you invoked CreateConnection first
        /// </summary>
        SQLite.SQLiteConnection Connection { get; }
  }
}
