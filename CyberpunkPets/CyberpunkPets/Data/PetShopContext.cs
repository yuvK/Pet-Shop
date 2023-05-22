using CyberpunkPets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CyberpunkPets.Data
{
    public class PetShopContext : DbContext
    {
        public PetShopContext(DbContextOptions<PetShopContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Mammals" },
                new Category { CategoryId = 2, Name = "Reptiles" },
                new Category { CategoryId = 3, Name = "Fish" },
                new Category { CategoryId = 4, Name = "Birds" },
                new Category { CategoryId = 5, Name = "Amphibians" }
                );

            modelBuilder.Entity<Animal>().HasData(
                new
                {
                    AnimalId = 1,
                    Name = "Ape",
                    Age = 8,
                    PictureName = "ape.png",
                    Description = "Apes are a clade of Old World simians native to sub-Saharan " +
                "Africa and Southeast Asia (though they were more widespread in Africa, " +
                "most of Asia, and as well as Europe in prehistory), which together with its sister " +
                "group Cercopithecidae form the catarrhine clade, cladistically making them monkeys",
                    CategoryId = 1
                },
                new
                {
                    AnimalId = 2,
                    Name = "Tiger",
                    Age = 9,
                    PictureName = "tiger.png",
                    Description = "The tiger is the largest living cat species and a member " +
                "of the genus Panthera. It is most recognisable for its dark vertical stripes on orange fur with a white underside. An apex predator, " +
                "it primarily preys on ungulates, such as deer and wild boar.",
                    CategoryId = 1
                },
                new
                {
                    AnimalId = 3,
                    Name = "Platypus",
                    Age = 3,
                    PictureName = "platypus.png",
                    Description = "The platypus (Ornithorhynchus anatinus), " +
                "sometimes referred to as the duck-billed platypus, is a semiaquatic, egg-laying mammal endemic to eastern Australia, including Tasmania. " +
                "The platypus is the sole living representative or monotypic taxon of its family (Ornithorhynchidae) and genus (Ornithorhynchus), " +
                "though a number of related species appear in the fossil record.",
                    CategoryId = 1
                },
                new
                {
                    AnimalId = 4,
                    Name = "Owl",
                    Age = 4,
                    PictureName = "owl.png",
                    Description = "Owls are birds from the order Strigiformes, " +
                "which includes over 200 species of mostly solitary and nocturnal birds of prey typified by an upright stance, a large, broad head, " +
                "binocular vision, binaural hearing, sharp talons, and feathers adapted for silent flight. Exceptions include the diurnal northern " +
                "hawk-owl and the gregarious burrowing owl.",
                    CategoryId = 4
                },
                new
                {
                    AnimalId = 5,
                    Name = "Condor",
                    Age = 5,
                    PictureName = "condor.png",
                    Description = "Condor is the common name for two species of " +
                "New World vultures, each in a monotypic genus. The name derives from the Quechua kuntur.They are the largest flying land birds in the Western Hemisphere.",
                    CategoryId = 4
                },
                new
                {
                    AnimalId = 6,
                    Name = "Giraffe",
                    Age = 8,
                    PictureName = "giraffe.png",
                    Description = "The giraffe is a large African hoofed mammal " +
                "belonging to the genus Giraffa. It is the tallest living terrestrial animal and the largest ruminant on Earth. Traditionally, " +
                "giraffes were thought to be one species, Giraffa camelopardalis, with nine subspecies.",
                    CategoryId = 1
                },
                new
                {
                    AnimalId = 7,
                    Name = "Hippo",
                    Age = 9,
                    PictureName = "hippo.png",
                    Description = "The hippopotamus is a large semiaquatic mammal " +
                "native to sub-Saharan Africa. It is one of only two extant species in the family Hippopotamidae, the other being the pygmy hippopotamus",
                    CategoryId = 1
                },
                new
                {
                    AnimalId = 8,
                    Name = "Elephant",
                    Age = 13,
                    PictureName = "elephant.png",
                    Description = "Elephants are the largest existing land animals. " +
                "Three living species are currently recognised: the African bush elephant, the African forest elephant, and the Asian elephant. " +
                "They are the only surviving members of the family Elephantidae and the order Proboscidea. The order was formerly much more diverse " +
                "during the Pleistocene, but most species became extinct during the Late Pleistocene epoch.",
                    CategoryId = 1
                },
                new
                {
                    AnimalId = 9,
                    Name = "Panda",
                    Age = 12,
                    PictureName = "panda.png",
                    Description = "The giant panda (Ailuropoda melanoleuca), also known as " +
                "the panda bear (or simply the panda), is a bear species endemic to China. It is characterised by its bold black-and-white coat and rotund body.",
                    CategoryId = 1
                },
                new
                {
                    AnimalId = 10,
                    Name = "Iguana",
                    Age = 3,
                    PictureName = "iguana.png",
                    Description = "iguana, any of eight genera and roughly 30 species of the larger " +
                "members of the lizard family Iguanidae. The name iguana usually refers only to the members of the subfamily Iguaninae. The best-known species is the common, " +
                "or green, iguana (Iguana iguana), which occurs from Mexico southward to Brazil. Males of this species reach a maximum length of over 2 metres (6.6 feet) and " +
                "6 kg (13.2 pounds). It is often seen basking in the sun on the branches of trees overhanging water, into which it will plunge if disturbed.",
                    CategoryId = 2
                },
                new
                {
                    AnimalId = 11,
                    Name = "SeaHorse",
                    Age = 4,
                    PictureName = "seahorse.png",
                    Description = "A seahorse (also written sea-horse and sea horse) is any of 46 species of small marine fish in the genus Hippocampus." +
                    " \"Hippocampus\" comes from the Ancient Greek hippókampos (ἱππόκαμπος), itself from híppos (ἵππος) meaning \"horse\" and kámpos (κάμπος) meaning \"sea monster\" or \"sea animal\".",
                    CategoryId = 3
                },
                new
                {
                    AnimalId = 12,
                    Name = "Tuna",
                    Age = 4,
                    PictureName = "tuna.png",
                    Description = "A tuna is a saltwater fish that belongs to the tribe Thunnini, a subgrouping of the Scombridae (mackerel) family. " +
                    "The Thunnini comprise 15 species across five genera,[2] the sizes of which vary greatly, ranging from the bullet tuna (max length: " +
                    "50 cm or 1.6 ft, weight: 1.8 kg or 4 lb) up to the Atlantic bluefin tuna (max length: 4.6 m or 15 ft, weight: 684 kg or 1,508 lb), " +
                    "which averages 2 m (6.6 ft) and is believed to live up to 50 years.",
                    CategoryId = 3
                }
                );

            modelBuilder.Entity<Comment>().HasData(
                new { CommentId = 1, AnimalId = 9, Content = "The cutest animal alive" },
                new { CommentId = 2, AnimalId = 9, Content = "I Love It!" },
                new { CommentId = 3, AnimalId = 9, Content = "I had one like this when i was a child" },
                new { CommentId = 4, AnimalId = 4, Content = "What is this?..." },
                new { CommentId = 5, AnimalId = 4, Content = "very smart animal" },
                new { CommentId = 6, AnimalId = 7, Content = "Beutiful animal, inside and out" }
                );
        }
    }
}
