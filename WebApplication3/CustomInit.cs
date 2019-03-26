using System.Data.Entity;

namespace WebApplication3
{
    internal class CustomInit<T> : DropCreateDatabaseAlways<Factory>
    {
        protected override void Seed(Factory context)
        {
            base.Seed(context);
            context.Workers.Add(new Worker
            {
                FirstName = "Firstname",
                LastName = "LastName",
                Address = "Soborna str",
                Salary = 9999m,
                Gedner = "Monatgnik"

            });
            context.Workers.Add(new Worker
            {
                FirstName = "Ivan",
                LastName = "Ivanenko",
                Address = "Lutck ",
                Salary = 9999m,
                Gedner = "male"

            });
            context.Workers.Add(new Worker
            {
                FirstName = "Vitalik",
                LastName = "Klichko",
                Address = "Soborna str",
                Salary = 11111111m,
                Gedner = "Mer"

            });
        }
    }
}