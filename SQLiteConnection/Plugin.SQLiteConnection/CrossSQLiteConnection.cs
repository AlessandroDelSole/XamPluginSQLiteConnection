using Plugin.SQLiteConnection.Abstractions;
using System;

namespace Plugin.SQLiteConnection
{
  /// <summary>
  /// Cross platform SQLiteConnection implemenations
  /// </summary>
  public class CrossSQLiteConnection
  {
    static Lazy<ISQLiteConnection> Implementation = new Lazy<ISQLiteConnection>(() => CreateSQLiteConnection(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

    /// <summary>
    /// Current settings to use
    /// </summary>
    public static ISQLiteConnection Current
    {
      get
      {
        var ret = Implementation.Value;
        if (ret == null)
        {
          throw NotImplementedInReferenceAssembly();
        }
        return ret;
      }
    }

    static ISQLiteConnection CreateSQLiteConnection()
    {
#if PORTABLE
        return null;
#else
        return new SQLiteConnectionImplementation();
#endif
    }

    internal static Exception NotImplementedInReferenceAssembly()
    {
      return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
  }
}
