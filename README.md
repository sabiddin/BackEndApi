# BackEndApi
Once the repository is cloned.
Change the connection string in the appsettings.json.
Build the solution.
To apply the migrations, goto the package manager console, select the project BackEndApi.Data and type 
update-database

To Add new migrations create a new model in the Domian.Models, Goto the DataContext 
and add the new collection for your model as public DbSet<Physician> Physicians {get;set;}. Then goto the 
package manager console and select the Data project and run the command Add-Migrations. Once thats completed 
run the command Update-Database.

This will create the database, add the necessary tables needed for the application.
