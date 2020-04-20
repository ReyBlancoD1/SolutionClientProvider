using Customer.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Persistence.Database.Configuration
{
    public class ClientConfiguration
    {
        public ClientConfiguration(EntityTypeBuilder<Client> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.ClientId);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            //Clients by default
            var clients = new List<Client>();
            for (var i = 1; i < 20; i++)
            {
                Random r = new Random();
                string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
                string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
                string clientName = "";
                clientName += consonants[r.Next(consonants.Length)].ToUpper();
                clientName += vowels[r.Next(vowels.Length)];
                int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
                while (b < 20)
                {
                    clientName += consonants[r.Next(consonants.Length)];
                    b++;
                    clientName += vowels[r.Next(vowels.Length)];
                    b++;
                }

                clients.Add(new Client { 
                    ClientId = i,
                    Name = clientName
                });

                
            }

            entityBuilder.HasData(clients);
        }
    }
}
