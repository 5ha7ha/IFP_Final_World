namespace TravelTheWorld.Services.Games;

public sealed record QuizQuestion(string Country, string Text, string[] Options, int Correct, string Fact);

public static class QuizData
{
    public static readonly IReadOnlyList<QuizQuestion> Questions = new QuizQuestion[]
    {
        new("Yemen", "Which Yemeni port gave its name to a coffee flavor?",
            new[] { "Aden", "Mocha", "Hodeidah", "Mukalla" }, 1,
            "Mocha was once the world's main port for exporting coffee."),
        new("Yemen", "Which island is home to the umbrella-shaped dragon's blood tree?",
            new[] { "Kamaran", "Zanzibar", "Socotra", "Crete" }, 2,
            "Socotra is famous for plants that grow almost nowhere else on Earth."),

        new("South Korea", "Which fermented vegetable dish is served at almost every Korean meal?",
            new[] { "Bulgogi", "Tteokbokki", "Bibimbap", "Kimchi" }, 3,
            "Kimchi is usually made from cabbage and radish with chili and garlic."),
        new("South Korea", "Which king created the Korean alphabet, Hangul, in the 15th century?",
            new[] { "King Sejong", "King Gojong", "King Taejo", "King Yeongjo" }, 0,
            "Hangul was designed to be easy to learn, so more people could read."),

        new("Kazakhstan", "Which traditional two-stringed instrument is a symbol of Kazakh music?",
            new[] { "Oud", "Balalaika", "Dombra", "Sitar" }, 2,
            "The dombra is used to accompany songs and storytelling."),
        new("Kazakhstan", "Which Kazakh cosmodrome launched the first human into space in 1961?",
            new[] { "Plesetsk", "Baikonur", "Vostochny", "Kourou" }, 1,
            "Baikonur is the oldest and one of the biggest space launch sites in the world."),

        new("Spain", "Which architect designed La Sagrada Família in Barcelona?",
            new[] { "Antoni Gaudí", "Santiago Calatrava", "Norman Foster", "Oscar Niemeyer" }, 0,
            "Construction started in 1882 and it is still being finished."),
        new("Spain", "In which Spanish festival do people throw tomatoes at each other?",
            new[] { "San Fermín", "Las Fallas", "Semana Santa", "La Tomatina" }, 3,
            "La Tomatina takes place every year in the town of Buñol.")
    };
}