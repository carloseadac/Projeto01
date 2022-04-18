
using DAO;

using(var context = new Context())
      {
        // Creates the database if not exists
        context.Database.EnsureCreated();
      }