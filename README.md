# SQLiteConnection Plugin for Xamarin Forms

This plugin for Xamarin Forms makes it easy to create a connection to a SQLite database. Instead of implementing platform-specific code for each client project, you simply use a couple lines of code in the PCL project.

## SETUP

Available on Nuget: https://www.nuget.org/packages/Plugin.SQLiteConnection/1.0.0

Install the package to the whole solution. This package already includes the SQLite-net-pcl package so you do not need one.

## USAGE

You simply use the CrossSQLiteConnection class, which is singleton. You first invoke CreateConnection passing the database name, then you get the connection via the Connection property.

  ```csharp
            // Simply create a connection and get the instance
            CrossSQLiteConnection.Current.CreateConnection("test.db3")
            var connection = CrossSQLiteConnection.Current.Connection;
            
            // Use SQLite types as you like
            connection.CreateTable<Customer>();
            var c1 = new Customer() { CustomerName = "Alessandro" };
            connection.Insert(c1);
            var customers = connection.Table<Customer>();
```

## API

  ```csharp
        // Create a connection to the specified SQLite database
        void CreateConnection(string dbFileName);

        // Return the connection to a SQLite database
        // Assumes you invoked CreateConnection first
        SQLite.SQLiteConnection Connection { get; }
```
