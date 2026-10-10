using System;
using System.Collections.Generic;
using System.Text;
using GloboTicket.TicketManagement.Domain.Common;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagement.Persistence
{
    public class GloboTicketDbContext : DbContext
    {
        public GloboTicketDbContext(DbContextOptions<GloboTicketDbContext> options)
        : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GloboTicketDbContext).Assembly);

            // Seed data, added through migrations
            var concertGuid = Guid.Parse("6bd45eed-39cf-496d-9f02-2d59b8a72ef7");
            var musicalGuid = Guid.Parse("f9bbec3b-04b0-4631-873d-0e6b88852246");
            var playGuid = Guid.Parse("3b7481d7-f575-4881-82d2-6eb0bdd53032");
            var conferenceGuid = Guid.Parse("ad289308-701f-46f9-8372-5522738b04e6");

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = concertGuid,
                    Name = "Concerts"
                },
                new Category
                {
                    CategoryId = musicalGuid,
                    Name = "Musicals"
                },
                new Category
                {
                    CategoryId = playGuid,
                    Name = "Plays"
                },
                new Category
                {
                    CategoryId = conferenceGuid,
                    Name = "Conferences"
                });

            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    EventId = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
                    Name = "John Egbert Live",
                    Price = 65,
                    Artist = "John Egbert",
                    Date = new DateTime(2027, 3, 1),
                    Description =
                        "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.",
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg",
                    CategoryId = concertGuid
                },
                new Event
                {
                    EventId = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
                    Name = "The State of Affairs: Michael Live!",
                    Price = 85,
                    Artist = "Michael Johnson",
                    Date = new DateTime(2027, 6, 1),
                    Description = "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?",
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/michael.jpg",
                    CategoryId = concertGuid
                },
                new Event
                {
                    EventId = Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529319}"),
                    Name = "Clash of the DJs",
                    Price = 85,
                    Artist = "DJ 'The Mike'",
                    Date = new DateTime(2027, 1, 1),
                    Description = "DJs from all over the world will compete in this epic battle for eternal fame.",
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/dj.jpg",
                    CategoryId = concertGuid
                },
                new Event
                {
                    EventId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
                    Name = "Spanish guitar hits with Manuel",
                    Price = 25,
                    Artist = "Manuel Santinonisi",
                    Date = new DateTime(2027, 1, 15),
                    Description = "Get on the hype of Spanish Guitar concerts with Manuel.",
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/guitar.jpg",
                    CategoryId = concertGuid
                },
                new Event
                {
                    EventId = Guid.Parse("{1BABD057-E980-4CB3-9CD2-7FDD9E525668}"),
                    Name = "Techorama 2027",
                    Price = 400,
                    Artist = "Many",
                    Date = new DateTime(2027, 7, 1),
                    Description = "The best tech conference in the world",
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/conf.jpg",
                    CategoryId = conferenceGuid
                },
                new Event
                {
                    EventId = Guid.Parse("{ADC42C09-08C1-4D2C-9F96-2D15BB1AF299}"),
                    Name = "To the Moon and Back",
                    Price = 135,
                    Artist = "Nick Sailor",
                    Date = new DateTime(2027, 5, 1),
                    Description = "The critics are over the moon and so will you after you've watched this sing and dance extravaganza written by Nick Sailor, the man from 'My dad and sister'.",
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/musical.jpg",
                    CategoryId = musicalGuid
                });

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = Guid.Parse("599e26e5-89cc-4efc-a5d5-a8966de6f48c"),
                    OrderTotal = 400,
                    OrderPaid = true,
                    OrderPlaced = new DateTime(2026, 09, 01),
                    UserId = Guid.Parse("{A441EB40-9636-4EE6-BE49-A66C5EC1330B}")
                },
                new Order
                {
                    Id = Guid.Parse("83e35816-e5f1-446b-a8b6-5c88ea34dc7e"),
                    OrderTotal = 135,
                    OrderPaid = true,
                    OrderPlaced = new DateTime(2026, 09, 02),
                    UserId = Guid.Parse("{AC3CFAF5-34FD-4E4D-BC04-AD1083DDC340}")
                },
                new Order
                {
                    Id = Guid.Parse("d41920e4-5037-44f6-acd4-620ace463a30"),
                    OrderTotal = 85,
                    OrderPaid = true,
                    OrderPlaced = new DateTime(2026, 09, 03),
                    UserId = Guid.Parse("{D97A15FC-0D32-41C6-9DDF-62F0735C4C1C}")
                },
                new Order
                {
                    Id = Guid.Parse("e64d5aa7-8a5b-4ab1-a628-b95bef2ea394"),
                    OrderTotal = 245,
                    OrderPaid = true,
                    OrderPlaced = new DateTime(2026, 09, 04),
                    UserId = Guid.Parse("{4AD901BE-F447-46DD-BCF7-DBE401AFA203}")
                },
                new Order
                {
                    Id = Guid.Parse("d3cf4912-e7ca-4624-85be-8ce3a3ae39e9"),
                    OrderTotal = 142,
                    OrderPaid = true,
                    OrderPlaced = new DateTime(2026, 09, 05),
                    UserId = Guid.Parse("{7AEB2C01-FE8E-4B84-A5BA-330BDF950F5C}")
                },
                new Order
                {
                    Id = Guid.Parse("95fafb9a-02ae-4c5c-afe3-fb664cbb9516"),
                    OrderTotal = 40,
                    OrderPaid = true,
                    OrderPlaced = new DateTime(2026, 09, 06),
                    UserId = Guid.Parse("{F5A6A3A0-4227-4973-ABB5-A63FBE725923}")
                },
                new Order
                {
                    Id = Guid.Parse("af5e1fe7-a8d3-48ca-a6da-f2b486e3b990"),
                    OrderTotal = 116,
                    OrderPaid = true,
                    OrderPlaced = new DateTime(2026, 09, 07),
                    UserId = Guid.Parse("{7AEB2C01-FE8E-4B84-A5BA-330BDF950F5C}")
                });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "System";
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "System";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
