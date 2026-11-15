using TravelTheWorld.Models;

namespace TravelTheWorld.Services;

public sealed class InMemoryCountryRepository : ICountryRepository
{
    public IReadOnlyList<Country> Countries { get; } = new List<Country>
    {
        new()
        {
            Key = "yemen", Name = "Yemen", Capital = "Sana'a City", Languages = new[] { "Arabic" },
            Currency = "Rial", Population = 34,
            Flag = "img/Yemen/yemenFlag.png", Map = "img/Yemen/yemen-bg.png",
            Accent = "#ce1126", HeroBg = "#1b1214", HeroGlow = "rgba(206, 17, 38, 0.4)",
            Quote = new("\"الحياة للشجعان! فالمؤمن القوي خيرٌ من المؤمن الضعيف\"", "ar", "rtl"),
            Facts = new[]
            {
                "Yemen is one of the first places in the world where coffee was grown. The port of Mocha even gave its name to a coffee flavor.",
                "About a third of the plants on Socotra Island grow nowhere else on Earth, including the umbrella-shaped dragon's blood tree.",
                "The Old City of Sana'a is a UNESCO World Heritage Site, famous for tall tower houses with white patterns and stained-glass windows.",
                "Aden, Yemen's port city, sits inside the crater of an extinct volcano."
            }
        },
        new()
        {
            Key = "spain", Name = "Spain", Capital = "Madrid", Languages = new[] { "Spanish" },
            Currency = "Euro", Population = 48,
            Flag = "img/Spain/spainFlag.png", Map = "img/Spain/spain_map_bg.png",
            Accent = "#c60b1e", HeroBg = "#2a1410", HeroGlow = "rgba(255, 196, 0, 0.4)",
            Quote = new("\"El que a buen árbol se arrima, buena sombra le cobija.\"", "es", "ltr"),
            Facts = new[]
            {
                "Spain produces nearly half of the world's olive oil, and most of it comes from the region of Andalusia.",
                "The Sagrada Família in Barcelona has been under construction since 1882 and is still not finished.",
                "Every August, the town of Buñol holds La Tomatina, a giant street fight where thousands of people throw tomatoes at each other.",
                "Sobrino de Botín in Madrid, opened in 1725, is recognized by Guinness World Records as the oldest restaurant in the world."
            }
        },
        new()
        {
            Key = "kazakhstan", Name = "Kazakhstan", Capital = "Astana", Languages = new[] { "Kazakh", "Russian" },
            Currency = "Tenge", Population = 20,
            Flag = "img/Kazakh/Flag-Kazakhstan.webp", Map = "img/Kazakh/Kazakhstan_Map_bg.png",
            Accent = "#00afca", HeroBg = "#0f2530", HeroGlow = "rgba(255, 200, 40, 0.35)",
            Quote = new("\"Жеті жұрттың тілін біл, жеті түрлі білім біл.\"", "kk", "ltr"),
            Facts = new[]
            {
                "Kazakhstan is the largest landlocked country in the world, bigger than all of Western Europe.",
                "The first person in space, Yuri Gagarin, was launched in 1961 from the Baikonur Cosmodrome in Kazakhstan, the world's first and largest space launch site.",
                "Scientists believe the wild apple forests near Almaty are the ancestors of the apples we eat today.",
                "The capital moved from Almaty to Astana in 1997."
            }
        },
        new()
        {
            Key = "korea", Name = "Korea", Capital = "Seoul", Languages = new[] { "Korean" },
            Currency = "Won", Population = 52,
            Flag = "img/Korea/Flag_of_South_Korea.svg", Map = "img/Korea/korea-map-bg.png",
            Accent = "#2f19f4", HeroBg = "#1a1413", HeroGlow = "rgba(21, 14, 219, 0.45)",
            Quote = new("\"너는 너대로, 나는 나대로. 그게 제일 좋은 거지.\"", "ko", "ltr"),
            Facts = new[]
            {
                "South Korea has one of the fastest average internet speeds in the world, with fiber connections reaching nearly every household.",
                "The Korean alphabet, Hangul, was created in 1443 by King Sejong the Great so that ordinary people could learn to read and write easily.",
                "Seoul's subway system is one of the longest and busiest in the world, and most trains have free Wi-Fi and phone chargers.",
                "Baduk (the board game known elsewhere as Go) has been played in Korea for over a thousand years and still has professional leagues today."
            }
        },
        new()
        {
            Key = "japan", Name = "Japan", Capital = "Tokyo", Languages = new[] { "Japanese" },
            Currency = "Yen", Population = 124,
            Flag = "img/Japan/japanFlag.webp", Map = "img/Japan/japan-map-bg.svg",
            Accent = "#bc002d", HeroBg = "#1a1214", HeroGlow = "rgba(188, 0, 45, 0.4)",
            Quote = new("\"七転び八起き\"", "ja", "ltr"),
            Facts = new[]
            {
                "Japan is made up of more than 14,000 islands, but most people live on just four main ones: Honshu, Hokkaido, Kyushu and Shikoku.",
                "The Shinkansen bullet train started running in 1964 and is famous for being punctual, with average delays of under a minute.",
                "Kyoto was the capital of Japan for over a thousand years, until the capital moved to Tokyo in 1868.",
                "Japan has millions of vending machines, selling everything from hot coffee to umbrellas."
            }
        },
        new()
        {
            Key = "germany", Name = "Germany", Capital = "Berlin", Languages = new[] { "German" },
            Currency = "Euro", Population = 84,
            Flag = "img/Germany/germanyFlag.webp", Map = "img/Germany/germany-map-bg.svg",
            Accent = "#ffce00", HeroBg = "#14161a", HeroGlow = "rgba(255, 206, 0, 0.35)",
            Quote = new("\"Aller Anfang ist schwer.\"", "de", "ltr"),
            Facts = new[]
            {
                "Parts of the German Autobahn have no general speed limit, which makes it one of the most famous road networks in the world.",
                "Johannes Gutenberg invented the movable-type printing press in Mainz around 1440, which changed how books were made across Europe.",
                "The Berlin Wall divided the city for 28 years and fell on November 9, 1989.",
                "The tradition of the Christmas tree started in Germany, and its Christmas markets are famous worldwide."
            }
        },
        new()
        {
            Key = "usa", Name = "United States", Capital = "Washington, D.C.", Languages = new[] { "English" },
            Currency = "US Dollar", Population = 340,
            Flag = "img/USA/usaFlag.webp", Map = "img/USA/usa-map-bg.svg",
            Accent = "#b22234", HeroBg = "#121826", HeroGlow = "rgba(60, 59, 110, 0.5)",
            Quote = new("\"Where there's a will, there's a way.\"", "en", "ltr"),
            Facts = new[]
            {
                "Yellowstone, created in 1872, was the first national park in the world.",
                "The Statue of Liberty was a gift from France and was dedicated in New York Harbor in 1886.",
                "The Wright brothers made the first powered airplane flight in 1903 at Kitty Hawk, North Carolina.",
                "In 1969, the Apollo 11 mission launched from Florida and put the first humans on the Moon."
            }
        },
        new()
        {
            Key = "canada", Name = "Canada", Capital = "Ottawa", Languages = new[] { "English", "French" },
            Currency = "Canadian Dollar", Population = 40,
            Flag = "img/Canada/canadaFlag.png", Map = "img/Canada/canada-map-bg.webp",
            Accent = "#d52b1e", HeroBg = "#1a1212", HeroGlow = "rgba(213, 43, 30, 0.4)",
            Quote = new("\"Petit à petit, l'oiseau fait son nid.\"", "fr", "ltr"),
            Facts = new[]
            {
                "Canada is the second-largest country in the world by area and has the longest coastline of any country.",
                "Canada has more lakes than the rest of the world combined.",
                "Most of the world's maple syrup comes from Canada, and the vast majority of it is made in Quebec.",
                "In winter, the Rideau Canal in Ottawa turns into one of the largest naturally frozen skating rinks in the world."
            }
        },
        new()
        {
            Key = "russia", Name = "Russia", Capital = "Moscow", Languages = new[] { "Russian" },
            Currency = "Ruble", Population = 144,
            Flag = "img/Russia/russiaFlag.webp", Map = "img/Russia/russia-map-bg.svg",
            Accent = "#0039a6", HeroBg = "#12151f", HeroGlow = "rgba(213, 43, 30, 0.4)",
            Quote = new("\"Без труда не вытащишь и рыбку из пруда.\"", "ru", "ltr"),
            Facts = new[]
            {
                "Russia is the largest country in the world and spans 11 time zones, so when people in Kaliningrad are having breakfast, people in Kamchatka are already finishing their day.",
                "Lake Baikal in Siberia is the deepest lake on Earth, at about 1,640 meters, and holds around a fifth of the world's unfrozen fresh water.",
                "The Trans-Siberian Railway is about 9,300 km long, the longest railway line in the world, and the full trip from Moscow to Vladivostok takes about a week.",
                "The Soviet Union launched Sputnik 1 in 1957, the first artificial satellite to orbit the Earth."
            }
        },
        new()
        {
            Key = "brazil", Name = "Brazil", Capital = "Brasília", Languages = new[] { "Portuguese" },
            Currency = "Real", Population = 217,
            Flag = "img/Brazil/brazilFlag.webp", Map = "img/Brazil/brazil-map-bg.svg",
            Accent = "#009c3b", HeroBg = "#0f1a14", HeroGlow = "rgba(255, 223, 0, 0.35)",
            Quote = new("\"Água mole em pedra dura, tanto bate até que fura.\"", "pt", "ltr"),
            Facts = new[]
            {
                "Brazil is home to about 60% of the Amazon rainforest, the largest tropical rainforest on Earth.",
                "Brazil has won the FIFA World Cup five times, more than any other country.",
                "Brasília, the capital, was built from scratch in the late 1950s and inaugurated in 1960 to move the country's center away from the coast.",
                "Brazil is the largest Portuguese-speaking country in the world, and the Rio Carnival is one of the biggest festivals on the planet."
            }
        },
        new()
        {
            Key = "saudi", Name = "Saudi Arabia", Capital = "Riyadh", Languages = new[] { "Arabic" },
            Currency = "Riyal", Population = 36,
            Flag = "img/Saudi/saudiFlag.webp", Map = "img/Saudi/saudi-map-bg.svg",
            Accent = "#006c35", HeroBg = "#101a14", HeroGlow = "rgba(0, 108, 53, 0.45)",
            Quote = new("\"من جدّ وجد، ومن زرع حصد\"", "ar", "rtl"),
            Facts = new[]
            {
                "Saudi Arabia is home to Makkah and Madinah, the two holiest cities in Islam, and millions of pilgrims visit them every year.",
                "The country has no permanent rivers, and much of its drinking water comes from desalination plants on the coast.",
                "The Empty Quarter (Rub' al Khali) is one of the largest continuous sand deserts in the world and stretches across the south of the country.",
                "Hegra in AlUla, with its tombs carved into rock, was the first place in Saudi Arabia to become a UNESCO World Heritage Site, in 2008."
            }
        }
    };

    public IReadOnlyList<ContentItem> Dishes { get; } = new List<ContentItem>
    {
        new("yemen", "Zurbian", "Spiced rice cooked with meat in one pot until everything is tender and full of flavor.", "img/Yemen/Zurbian.jpeg"),
        new("yemen", "Fahsa", "A rich stew of lamb or beef, cooked slowly until it falls apart and eaten with Yemeni flatbread.", "img/Yemen/Fahsa-dish.jpg"),
        new("yemen", "Braota", "A hearty meat dish cooked with spices, served with bread or rice.", "img/Yemen/Braota-dish.jpeg"),

        new("spain", "Paella", "Rice cooked in a wide pan with saffron, vegetables, and meats like chicken, rabbit, or seafood.", "img/Spain/paella.jpg"),
        new("spain", "Gazpacho", "A cold, refreshing soup from Andalusia made from blended ripe tomatoes, cucumbers, peppers, and olive oil.", "img/Spain/gazpacho.jpg"),
        new("spain", "Croquetas", "Small fried croquettes filled with seafood or meat, often served as an appetizer.", "img/Spain/croquetas.jpg"),

        new("kazakhstan", "Beshbarmak", "The national dish: boiled meat served over wide flat noodles with onion broth. Its name means \"five fingers\" because it is traditionally eaten by hand.", "img/Kazakh/beshbarmak.jpeg"),
        new("kazakhstan", "Baursak", "Golden puffs of fried dough, served with tea and at almost every celebration.", "img/Kazakh/baursak.jpeg"),
        new("kazakhstan", "Manti", "Large steamed dumplings filled with spiced meat and onion.", "img/Kazakh/manti.webp"),

        new("korea", "Bibimbap", "A warm rice bowl topped with mixed vegetables, chili paste (gochujang), meat, and a fried egg.", "img/Korea/bibimbap.jpg"),
        new("korea", "Tteokbokki", "Chewy cylindrical rice cakes cooked in a sweet and spicy chili sauce.", "img/Korea/tteokbokki.jpg"),
        new("korea", "Japchae", "Stir-fried glass noodles with vegetables and meat, seasoned with soy sauce and sesame oil.", "img/Korea/japchae.jpg"),

        new("japan", "Sushi", "Vinegared rice paired with fresh fish, seafood or vegetables, served as bite-sized pieces or rolls.", "img/Japan/sushi.jpg"),
        new("japan", "Ramen", "Wheat noodles in a rich broth, topped with sliced pork, a soft egg and green onions.", "img/Japan/ramen.webp"),
        new("japan", "Takoyaki", "Crispy round balls of batter with a piece of octopus inside, topped with sauce and bonito flakes.", "img/Japan/takoyaki.jpg"),

        new("germany", "Bratwurst", "A grilled pork sausage, often eaten in a bread roll with mustard or served with sauerkraut.", "img/Germany/bratwurst.jpg"),
        new("germany", "Schnitzel", "A thin cutlet of meat, breaded and fried until golden, usually served with potatoes and a slice of lemon.", "img/Germany/schnitzel.webp"),
        new("germany", "Pretzel", "A twisted baked bread with a dark crust and coarse salt, a classic snack in Bavaria.", "img/Germany/pretzel.jpg"),

        new("usa", "Hamburger", "A grilled beef patty in a soft bun with lettuce, tomato, cheese and sauces, one of the most iconic American foods.", "img/USA/hamburger.webp"),
        new("usa", "Buffalo Wings", "Fried chicken wings coated in a spicy, tangy sauce and served with celery and a creamy dip.", "img/USA/buffalo-wing.jpg"),
        new("usa", "Apple Pie", "A sweet baked pie with a flaky crust and a cinnamon-spiced apple filling, often served warm.", "img/USA/apple-pie.jpg"),

        new("canada", "Poutine", "French fries topped with cheese curds and hot gravy, a famous dish from Quebec.", "img/Canada/poutine.webp"),
        new("canada", "Tourtière", "A savory meat pie with spiced pork or beef, traditionally eaten at Christmas in Quebec.", "img/Canada/tourtiere.jpg"),
        new("canada", "Nanaimo Bars", "A no-bake dessert with a chocolate and coconut base, custard cream in the middle and chocolate on top.", "img/Canada/nanaimo-bars.webp"),

        new("russia", "Borscht", "A bright red beetroot soup with cabbage, potatoes and meat, usually served with sour cream.", "img/Russia/borscht.jpg"),
        new("russia", "Pelmeni", "Small dumplings filled with minced meat, boiled and eaten with butter, vinegar or sour cream.", "img/Russia/pelmeni.jpg"),
        new("russia", "Blini", "Thin, soft pancakes served with jam, honey, sour cream or caviar, especially during Maslenitsa.", "img/Russia/blini.jpg"),

        new("brazil", "Feijoada", "A rich stew of black beans and pork, served with rice, collard greens and orange slices. It is often called the national dish.", "img/Brazil/feijoada.jpg"),
        new("brazil", "Pão de Queijo", "Small, chewy cheese breads made with tapioca flour, popular for breakfast and snacks.", "img/Brazil/pao-de-queijo.jpg"),
        new("brazil", "Brigadeiro", "A chocolate truffle made from condensed milk and cocoa, rolled in sprinkles, found at every birthday party.", "img/Brazil/brigadeiro.jpg"),

        new("saudi", "Kabsa", "The most famous dish of the country: spiced rice cooked with chicken or lamb, often topped with nuts and raisins.", "img/Saudi/kabsa.jpg"),
        new("saudi", "Mutabbaq", "A stuffed, folded pan-fried pastry filled with minced meat, egg and spices, a popular street food.", "img/Saudi/mutabbaq.jpg"),
        new("saudi", "Jareesh", "A creamy dish of crushed wheat cooked with meat or chicken and spices, eaten especially in the Najd region.", "img/Saudi/jareesh.avif"),
    };

    public IReadOnlyList<ContentItem> Places { get; } = new List<ContentItem>
    {
        new("yemen", "Socotra Island", "A remote island with dragon's blood trees, white sand beaches and wildlife seen nowhere else.", "img/Yemen/Sqtra.jpeg"),
        new("yemen", "Old Sana'a", "A walled old city of tall tower houses, narrow lanes and busy markets, one of the oldest lived-in cities in the world.", "img/Yemen/old-sanaa.jpg"),
        new("yemen", "Aden", "A port city on the Arabian Sea, built around an old volcano crater, with beaches and a historic harbor.", "img/Yemen/Aden.jpeg"),

        new("spain", "Barcelona", "Home to Gaudí's Sagrada Família, this Catalan port city mixes Gothic alleys with modernist buildings", "img/Spain/barcelona.jpg"),
        new("spain", "Madrid", "The EU's highest capital, home to the Prado Museum, Retiro Park, and a famous late-night tapas scene", "img/Spain/madrid.jpg"),
        new("spain", "Andalusia", "The birthplace of flamenco, where Moorish landmarks like the Alhambra and Córdoba's Mezquita still stand.", "img/Spain/andalusia.jpg"),

        new("kazakhstan", "Charyn Canyon", "A huge red-rock canyon more than 150 km long, often compared to the Grand Canyon. Its most famous part is called the Valley of Castles.", "img/Kazakh/charyn-canyon.avif"),
        new("kazakhstan", "Bayterek Tower, Astana", "A 97-meter tower in the capital with a golden glass sphere on top. It stands for a legendary tree of life, and you can go up for a view over the city.", "img/Kazakh/baterek.webp"),
        new("kazakhstan", "Big Almaty Lake", "A turquoise mountain lake high in the Tien Shan mountains, about 2,500 meters above sea level, close to the city of Almaty.", "img/Kazakh/almaty-lake.jpg"),

        new("korea", "Seoul", "The capital of South Korea, known for its vibrant culture, historic palaces, and modern skyline.", "img/Korea/seoul.jpg"),
        new("korea", "Busan", "The second-largest city in South Korea, known for its beautiful beaches, vibrant nightlife, and the Gukje Market.", "img/Korea/busan.jpg"),
        new("korea", "Jeju", "An island province known for its natural beauty, including volcanic landscapes, cherry blossoms, and unique culture.", "img/Korea/jeju.jpg"),

        new("japan", "Tokyo", "A huge capital where neon-lit streets, quiet shrines, anime culture and some of the world's best food sit side by side.", "img/Japan/tokyo.webp"),
        new("japan", "Kyoto", "The old imperial capital, known for its thousands of temples, wooden teahouses and the red gates of Fushimi Inari.", "img/Japan/kyoto.jpg"),
        new("japan", "Mount Fuji", "Japan's highest mountain at 3,776 meters, a sacred symbol of the country that you can climb in summer.", "img/Japan/mount-fuji.jpg"),

        new("germany", "Neuschwanstein Castle", "A fairy-tale castle on a hill in the Bavarian Alps, built in the 19th century by King Ludwig II.", "img/Germany/neuschwanstein.jpg"),
        new("germany", "Berlin", "The capital, where you can see the Brandenburg Gate, remains of the Berlin Wall and Museum Island.", "img/Germany/berlin.jpg"),
        new("germany", "Black Forest", "A large, dark forested mountain region in the southwest, known for hiking trails, lakes and small villages.", "img/Germany/black-forest.jpg"),

        new("usa", "New York City", "The city of skyscrapers, Times Square, Central Park and the Statue of Liberty.", "img/USA/new-york.webp"),
        new("usa", "Grand Canyon", "A giant canyon in Arizona carved by the Colorado River, about 446 km long and up to 1.8 km deep.", "img/USA/grand-canyon.jpg"),
        new("usa", "Yellowstone", "The world's first national park, famous for the Old Faithful geyser, hot springs, bison and bears.", "img/USA/yellowstone.webp"),

        new("canada", "Banff National Park", "Canada's oldest national park in the Rocky Mountains, with turquoise lakes like Lake Louise and Moraine Lake.", "img/Canada/banff.jpg"),
        new("canada", "Niagara Falls", "A group of huge waterfalls on the border with the USA, where you can take a boat right up to the mist.", "img/Canada/niagara-falls.webp"),
        new("canada", "Quebec City", "A walled city with cobblestone streets and the Château Frontenac, which feels like a small piece of Europe.", "img/Canada/quebec-city.webp"),

        new("russia", "Red Square, Moscow", "The famous square in the center of Moscow, with the colorful domes of Saint Basil's Cathedral and the walls of the Kremlin.", "img/Russia/red-square.jpg"),
        new("russia", "Saint Petersburg", "A city of canals, white nights and palaces, home to the Hermitage Museum, one of the largest art museums in the world.", "img/Russia/saint-petersburg.jpg"),
        new("russia", "Lake Baikal", "The deepest and one of the oldest lakes on Earth, with crystal-clear water that freezes into transparent ice in winter.", "img/Russia/lake-baikal.jpeg"),

        new("brazil", "Rio de Janeiro", "A coastal city famous for Copacabana beach, Sugarloaf Mountain and the Christ the Redeemer statue.", "img/Brazil/rio.jpg"),
        new("brazil", "Iguazu Falls", "A huge system of about 275 waterfalls on the border with Argentina, surrounded by rainforest.", "img/Brazil/iguazu-falls.jpg"),
        new("brazil", "Amazon Rainforest", "The largest tropical rainforest in the world, home to millions of species of plants and animals and the mighty Amazon River.", "img/Brazil/amazon.webp"),

        new("saudi", "AlUla", "A desert valley with sandstone cliffs and Hegra, an ancient Nabataean city with tombs carved into the rock.", "img/Saudi/alula.avif"),
        new("saudi", "Makkah", "The holiest city in Islam, home to the Kaaba inside Masjid al-Haram. Millions of Muslims travel here every year for Hajj and Umrah.", "img/Saudi/makkah.jpg"),
        new("saudi", "Edge of the World", "A dramatic cliff edge near Riyadh, part of the Tuwaiq Escarpment, with views over a vast plain that seems to have no end.", "img/Saudi/edge-of-the-world.jpg"),
    };

    public Country? FindCountry(string? key) =>
        Countries.FirstOrDefault(c => c.Key == key);

    public IReadOnlyList<ContentItem> DishesFor(string countryKey) =>
        Dishes.Where(d => d.CountryKey == countryKey).ToList();

    public IReadOnlyList<ContentItem> PlacesFor(string countryKey) =>
        Places.Where(p => p.CountryKey == countryKey).ToList();
}