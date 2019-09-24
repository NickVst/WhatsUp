using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WhatsUp.Models;

namespace WhatsUp.Repositories
{
    public class WhatsUpContext : DbContext
    {
        public WhatsUpContext() : base("WhatsUpContext")
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<PrivateChat> PrivateChats { get; set; }
        public DbSet<GroupChat> GroupChats { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class DatabaseInitialization : DropCreateDatabaseIfModelChanges<WhatsUpContext>
    {
        protected override void Seed(WhatsUpContext context)
        {
            var Accounts = new List<Account>
            {
                new Account {
                    Name = "Nick Versteeg",
                    Username = "nick",
                    Password = "admin123"
                },
                new Account {
                    Name = "Ander Account",
                    Username = "nick2",
                    Password = "admin456"
                },
                new Account {
                    Name = "Nummer Drie",
                    Username = "nick3",
                    Password = "admin789"
                }
            };
            Accounts.ForEach(x => context.Accounts.Add(x));

            var Messages = new List<Message>
            {
                // Private chat messages
                new Message {
                    DateTime = DateTime.Now.AddDays(-2),
                    Sender  = Accounts[0],
                    Text = "Example Message 1"
                },
                new Message {
                    DateTime = DateTime.Now.AddDays(-1),
                    Sender = Accounts[1],
                    Text = "Example Message 2"
                },
                new Message {
                    DateTime = DateTime.Now.AddDays(-1).AddHours(1),
                    Sender = Accounts[1],
                    Text = "A bit of a longer example " +
                        "message, showing how potential linebreaks would work " +
                        "in the application and whether or not the application " +
                        "would completely fail to work in this case."
                },

                // Group chat messages
                new Message {
                    Sender = Accounts[0],
                    Text = "Nick"
                },
                new Message {
                    Sender = Accounts[1],
                    Text = "Ander"
                },
                new Message {
                    Sender = Accounts[2],
                    Text = "Nummer"
                }
            };
            Messages.ForEach(x => context.Messages.Add(x));

            var PrivateChats = new List<PrivateChat>
            {
                new PrivateChat {
                    Member1 = Accounts[0],
                    Member2 = Accounts[1],
                    Messages = new List<Message> {
                        Messages[0],
                        Messages[1],
                        Messages[2]
                    }
                }
            };
            PrivateChats.ForEach(x => context.PrivateChats.Add(x));

            var GroupChats = new List<GroupChat>
            {
                new GroupChat {
                    Members = new List<Account>
                    {
                        Accounts[0],
                        Accounts[1],
                        Accounts[2]
                    },
                    Messages = new List<Message>
                    {
                        Messages[3],
                        Messages[4],
                        Messages[5]
                    }
                }
            };
            GroupChats.ForEach(x => context.GroupChats.Add(x));

            context.SaveChanges();
        }
    }
}