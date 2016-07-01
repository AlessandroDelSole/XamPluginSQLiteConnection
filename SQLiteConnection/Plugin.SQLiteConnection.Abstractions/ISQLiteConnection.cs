using System;
using SQLite;

namespace Plugin.SQLiteConnection.Abstractions
{
  /// <summary>
  /// Interface for SQLiteConnection
  /// </summary>
  public interface ISQLiteConnection
  {
        void CreateConnection(string dbFileName);

        SQLite.SQLiteConnection Connection { get; }
  }
}
