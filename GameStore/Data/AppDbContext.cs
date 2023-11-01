using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<GameReceipt> GameReceipts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=;database=native_gamestore",
                ServerVersion.Parse("8.0.30")
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Nodig voor many-to-many:
            // https://learn.microsoft.com/en-us/ef/core/modeling/relationships/many-to-many#many-to-many-with-class-for-join-entity
            modelBuilder.Entity<Receipt>()
                .HasMany(r => r.Games)
                .WithMany(g => g.Receipts)
                .UsingEntity<GameReceipt>();

            // Games
            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    Id = 1,
                    Barcode = "1234567891023",
                    Name = "Pacman",
                    Price = 2.49M
                },
                new Game
                {
                    Id = 2,
                    Barcode = "1234567891024",
                    Name = "Super Mario",
                    Price = 5.99M
                },
                new Game
                {
                    Id = 3,
                    Barcode = "1234567891025",
                    Name = "Zelda",
                    Price = 6.49M
                },
                new Game
                {
                    Id = 4,
                    Barcode = "1234567891026",
                    Name = "Minecraft",
                    Price = 15.99M
                },
                new Game
                {
                    Id = 5,
                    Barcode = "1234567891027",
                    Name = "Sonic",
                    Price = 4.99M
                },
                new Game
                {
                    Id = 6,
                    Barcode = "1234567891028",
                    Name = "Metroid",
                    Price = 7.49M
                },
                new Game
                {
                    Id = 7,
                    Barcode = "1234567891029",
                    Name = "Street Fighter",
                    Price = 8.99M
                },
                new Game
                {
                    Id = 8,
                    Barcode = "1234567891030",
                    Name = "Final Fantasy",
                    Price = 9.99M
                },
                new Game
                {
                    Id = 9,
                    Barcode = "1234567891031",
                    Name = "Tetris",
                    Price = 3.49M
                },
                new Game
                {
                    Id = 10,
                    Barcode = "1234567891032",
                    Name = "Donkey Kong",
                    Price = 5.29M
                },
                new Game
                {
                    Id = 11,
                    Barcode = "1234567891033",
                    Name = "Mortal Kombat",
                    Price = 6.99M
                },
                new Game
                {
                    Id = 12,
                    Barcode = "1234567891034",
                    Name = "Doom",
                    Price = 12.49M
                },
                new Game
                {
                    Id = 13,
                    Barcode = "1234567891035",
                    Name = "SimCity",
                    Price = 11.99M
                },
                new Game
                {
                    Id = 14,
                    Barcode = "1234567891036",
                    Name = "Starcraft",
                    Price = 13.99M
                },
                new Game
                {
                    Id = 15,
                    Barcode = "1234567891037",
                    Name = "Halo",
                    Price = 14.99M
                },
                new Game
                {
                    Id = 16,
                    Barcode = "1234567891038",
                    Name = "Red Dead Redemption",
                    Price = 19.99M
                },
                new Game
                {
                    Id = 17,
                    Barcode = "1234567891039",
                    Name = "The Elder Scrolls",
                    Price = 20.99M
                },
                new Game
                {
                    Id = 18,
                    Barcode = "1234567891040",
                    Name = "Grand Theft Auto",
                    Price = 24.99M
                },
                new Game
                {
                    Id = 19,
                    Barcode = "1234567891041",
                    Name = "The Witcher",
                    Price = 21.49M
                },
                new Game
                {
                    Id = 20,
                    Barcode = "1234567891042",
                    Name = "Mass Effect",
                    Price = 18.49M
                },
                new Game
                {
                    Id = 21,
                    Barcode = "1234567891043",
                    Name = "Call of Duty",
                    Price = 22.99M
                }
            );

            // Receipts
            modelBuilder.Entity<Receipt>().HasData(
                new Receipt
                {
                    Id = 1,
                    CreatedAt = DateTime.Now,
                },
                new Receipt
                {
                    Id = 2,
                    CreatedAt = DateTime.Now,
                },
                new Receipt
                {
                    Id = 3,
                    CreatedAt = DateTime.Now,
                },
                new Receipt
                {
                    Id = 4,
                    CreatedAt = DateTime.Now,
                },
                new Receipt
                {
                    Id = 5,
                    CreatedAt = DateTime.Now,
                }
            );

            // GameReceipts
            modelBuilder.Entity<GameReceipt>().HasData(
                new GameReceipt
                {
                    ReceiptId = 1,
                    GameId = 1,
                    Amount = 1,
                    UnitPrice = 2.49M
                },
                new GameReceipt
                {
                    ReceiptId = 2,
                    GameId = 2,
                    Amount = 1,
                    UnitPrice = 5.99M
                },
                new GameReceipt
                {
                    ReceiptId = 3,
                    GameId = 3,
                    Amount = 1,
                    UnitPrice = 6.49M
                },
                new GameReceipt
                {
                    ReceiptId = 4,
                    GameId = 4,
                    Amount = 1,
                    UnitPrice = 15.99M
                },
                new GameReceipt
                {
                    ReceiptId = 5,
                    GameId = 2,  // Super Mario
                    Amount = 2,
                    UnitPrice = 5.99M
                },
                new GameReceipt
                {
                    ReceiptId = 2,
                    GameId = 5, // Sonic
                    Amount = 2,
                    UnitPrice = 4.99M
                },
                new GameReceipt
                {
                    ReceiptId = 3,
                    GameId = 6, // Metroid
                    Amount = 3,
                    UnitPrice = 7.49M
                },
                new GameReceipt
                {
                    ReceiptId = 4,
                    GameId = 7, // Street Fighter
                    Amount = 1,
                    UnitPrice = 8.99M
                },
                new GameReceipt
                {
                    ReceiptId = 5,
                    GameId = 8,  // Final Fantasy
                    Amount = 1,
                    UnitPrice = 9.99M
                }
            );
        }
    }
}
