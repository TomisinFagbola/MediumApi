using Medium.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medium.Api.Contexts
{
    public  class MediumApiContext : DbContext
    {
        public MediumApiContext(DbContextOptions<MediumApiContext> options)
         : base(options)
        {

            //  Database.EnsureCreated();
        }
      
        public DbSet<Post> Posts { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<PostTag> PostTags { get; set; }

        public DbSet<Picture> Pics { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Author>()
                .HasKey(a => a.AuthorId);
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Posts)
                .WithOne(p => p.Author)
                ;


            modelBuilder.Entity<Post>()
                .ToTable("Posts");
            modelBuilder.Entity<Post>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Post>()
            .HasOne(p => p.Author)
            .WithMany(a => a.Posts)
            .HasForeignKey(p => p.AuthorId);
            modelBuilder.Entity<Post>()
             .Property(p => p.CreatedDate)
             .IsRequired()
             .HasColumnType("Date")
             .HasDefaultValueSql("getutcdate()");
           
            modelBuilder.Entity<Post>()
              .Property(p => p.Title)
              .IsRequired();

            modelBuilder.Entity<Post>()
                .Property(p => p.NoOfClaps)
                .IsRequired();
            modelBuilder.Entity<Post>()
             .Property(p => p.Content)
             .IsRequired();


            modelBuilder.Entity<Tag>()
                .HasMany(t => t.PostTags)
                .WithOne(pt => pt.Tag);

            modelBuilder.Entity<Picture>()
                .HasOne(p => p.Post)
                .WithMany(p => p.pic)
                .HasForeignKey(i => i.PostId);

            modelBuilder.Entity<Picture>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Post>()
           .HasMany(p => p.Tags)
           .WithMany(p=> p.Posts)
           .UsingEntity<PostTag>(
               j => j
                   .HasOne(pt => pt.Tag)
                   .WithMany(t => t.PostTags)
                   .HasForeignKey(pt => pt.TagId),
               j => j
                   .HasOne(pt => pt.Post)
                   .WithMany(p => p.PostTags)
                   .HasForeignKey(pt => pt.PostId),
               j =>
               {
                   j.Property(pt => pt.PublicationDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                   j.HasKey(t => new { t.PostId, t.TagId });
               });

            modelBuilder.Entity<Author>().HasData(
            new Author()
            {
                AuthorId = 1,
                Name = "Ayo Michael",
            },
            new Author()
            {
                AuthorId = 2,
                Name = "Raji Fashola",
            },
            new Author()
            {
                AuthorId = 3,
                Name = "Tomi Fagbola",
            }
           );
            modelBuilder.Entity<Tag>().HasData(
                new Tag()
                {
                    Id = 1,
                    Name = "leadership",
                },
                new Tag()
                {
                    Id = 2,
                    Name = "Programming",
                },
                
                new Tag()
                {
                    Id = 3,
                    Name = "JavaScript"
                });
            
            modelBuilder.Entity<Post>().HasData(
                new Post()
                {
                    Id = 1,
                    AuthorId = 1,
                    Title = "Microservices Design Pattern",
                    Content = "The one with that big park.",
                    NoOfClaps = 22000,
                    
                },
                new Post()
                {
                    Id = 2,
                    AuthorId = 2,
                    Title = "Backend Developer Roadmap",
                    Content = "For those who have little to do with software development, it sounds very cryptic, so they end up thinking I “do something with computers”. OMG! Maybe connect printers, swap hard drives and install Windows on discount computers. Far from it, of course.",
                    NoOfClaps = 15000,
                    
                },
                new Post()
                {
                    Id = 3,
                    AuthorId =2,
                    Title = "Why I Like Using UUIDs on Database Tables",
                    Content = "When working with relational DBs we usually assign auto-incrementing integer IDs to tables: the first row has ID 1, the second ID 2 and so on",
                    NoOfClaps = 20000,
                   
                },
                new Post()
                {
                    Id = 4,
                    AuthorId = 2,
                    Title = "Thoughts of a passionate IT freelancer",
                    Content = "I been thinking about doing this post for a while, this list contains the top 10 apps I use on a daily basis as a Software Engineer; the list also includes a few examples on how I use the app and how much they cost.",
                    NoOfClaps = 10000,
                 },
                new Post()
                {
                    Id = 5,
                    AuthorId = 3,
                    Title = "Best coding practices every developer should do",
                    Content = "In recent years, the front-end has developed very fast, and the prosperity of SPA has made front-end engineering more and more important. In many scenarios, the complexity and difficulty of the front end have already surpassed that of the back end. But with the rapid development, the front-end has gradually exposed many problems. As we all know, front-end practitioners rarely talk about program design principles or design ideas. This inevitably leads to the front-end code being written as spaghetti. Under the premise of the development model based on the MVVM-like framework, the front-end code naturally has component-level abstraction and is still written as spaghetti. If it is the MVC era of slash and burn, it is even more unimaginable.",
                    NoOfClaps = 9000,
                    
                });

            modelBuilder.Entity<PostTag>().HasData(
                new PostTag()
                {
                    PostId = 1,
                    TagId = 1,
                },
                new PostTag()
                {
                    PostId = 1,
                    TagId = 2,
                },
                new PostTag()
                {
                    PostId = 1,
                    TagId = 3,

                },
                new PostTag()
                {
                    PostId =2,
                    TagId = 1,
                },
                new PostTag()
                {
                    PostId = 2,
                    TagId = 2,
                },
                new PostTag()
                {
                    PostId = 2,
                    TagId =3,
                });
            modelBuilder.Entity<Picture>().HasData(
                new Picture()
                {
                    Id = 1,
                    Pic = Picture.ToBase64(@"C:\Users\dell\Downloads\flower1.jpg"),
                    PostId = 1,
                },
                new Picture()
                {
                    Id = 2,
                    Pic = Picture.ToBase64(@"C:\Users\dell\Downloads\flower.jpg"),
                    PostId = 2,
                },
                new Picture()
                {
                    Id = 3,
                    Pic = Picture.ToBase64(@"C:\Users\dell\Downloads\flower.jpg"),
                    PostId = 3,
                },
                new Picture()
                {
                    Id = 4,
                    Pic = Picture.ToBase64(@"C:\Users\dell\Downloads\flower.jpg") ,
                    PostId = 4,
                },
                new Picture()
                {
                    Id = 5,
                    Pic = Picture.ToBase64(@"C:\Users\dell\Downloads\flower.jpg"),
                    PostId = 5,
                }
                );

                
                     
                


        }
    }
}
