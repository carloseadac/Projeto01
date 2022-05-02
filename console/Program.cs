
using DAO;

using(var context = new DaoContext())
      {
        // Creates the database if not exists
        context.Database.EnsureCreated();
      }