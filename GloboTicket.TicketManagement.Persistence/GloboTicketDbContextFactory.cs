using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GloboTicket.TicketManagement.Persistence
{
    internal class GloboTicketDbContextFactory : IDesignTimeDbContextFactory<GloboTicketDbContext>
    {
        public GloboTicketDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<GloboTicketDbContext>()
                .UseSqlServer("Server = MIKELENOVO; Database = GloboTicketDb; User Id = sa; Password = nsimat;TrustServerCertificate=True; ")
                .Options;

            return new GloboTicketDbContext(options);
        }
    }
}
