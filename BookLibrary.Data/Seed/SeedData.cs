using BookLibrary.Data.Contexts;
using BookLibrary.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookLibrary.Data.Seed
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider svc)
        {
            var ctx = svc.GetRequiredService<LibraryContext>();
            ctx.Database.EnsureCreated();

            if (ctx.Books.Any()) return;

            ctx.Books.AddRange(
                new Book { Title = "Pride and Prejudice", FirstName = "Jane", LastName = "Austen", TotalCopies = 100, CopiesInUse = 80, Type = "Hardcover", ISBN = "1234567891", Category = "Fiction" },
                new Book { Title = "To Kill a Mockingbird", FirstName = "Harper", LastName = "Lee", TotalCopies = 75, CopiesInUse = 65, Type = "Paperback", ISBN = "1234567892", Category = "Fiction" },
                new Book { Title = "The Catcher in the Rye", FirstName = "J.D.", LastName = "Salinger", TotalCopies = 50, CopiesInUse = 45, Type = "Hardcover", ISBN = "1234567893", Category = "Fiction" },
                new Book { Title = "The Great Gatsby", FirstName = "F. Scott", LastName = "Fitzgerald", TotalCopies = 50, CopiesInUse = 22, Type = "Hardcover", ISBN = "1234567894", Category = "Non-Fiction" },
                new Book { Title = "The Alchemist", FirstName = "Paulo", LastName = "Coelho", TotalCopies = 50, CopiesInUse = 35, Type = "Hardcover", ISBN = "1234567895", Category = "Biography" },
                new Book { Title = "The Book Thief", FirstName = "Markus", LastName = "Zusak", TotalCopies = 75, CopiesInUse = 11, Type = "Hardcover", ISBN = "1234567896", Category = "Mystery" },
                new Book { Title = "The Chronicles of Narnia", FirstName = "C.S.", LastName = "Lewis", TotalCopies = 100, CopiesInUse = 14, Type = "Paperback", ISBN = "1234567897", Category = "Sci-Fi" },
                new Book { Title = "The Da Vinci Code", FirstName = "Dan", LastName = "Brown", TotalCopies = 50, CopiesInUse = 40, Type = "Paperback", ISBN = "1234567898", Category = "Sci-Fi" },
                new Book { Title = "The Grapes of Wrath", FirstName = "John", LastName = "Steinbeck", TotalCopies = 50, CopiesInUse = 35, Type = "Hardcover", ISBN = "1234567899", Category = "Fiction" },
                new Book { Title = "The Hitchhiker's Guide to the Galaxy", FirstName = "Douglas", LastName = "Adams", TotalCopies = 50, CopiesInUse = 35, Type = "Paperback", ISBN = "1234567900", Category = "Non-Fiction" },
                new Book { Title = "Moby-Dick", FirstName = "Herman", LastName = "Melville", TotalCopies = 30, CopiesInUse = 8, Type = "Hardcover", ISBN = "8901234567", Category = "Fiction" },
                new Book { Title = "To Kill a Mockingbird", FirstName = "Harper", LastName = "Lee", TotalCopies = 20, CopiesInUse = 0, Type = "Paperback", ISBN = "9012345678", Category = "Non-Fiction" },
                new Book { Title = "The Catcher in the Rye", FirstName = "J.D.", LastName = "Salinger", TotalCopies = 10, CopiesInUse = 1, Type = "Hardcover", ISBN = "0123456789", Category = "Non-Fiction" }
            );

            ctx.SaveChanges();
        }
    }
}
