using SmartEdu.Models;

namespace SmartEdu.Helpers.TimetableRandomer
{
    public static class TimetableRandomer
    {
        public static LectureTime[] MorningTimes { get; set; } =
        {
            new LectureTime
            {
                    From = new DateTime(1,1,1, 7, 30, 0),
                    To = new DateTime(1,1,1, 8, 30, 0),
            },
                new LectureTime
            {
                    From = new DateTime(1,1,1, 8, 30, 0),
                    To = new DateTime(1,1,1, 9, 30, 0)
            },
                new LectureTime
            {
                    From = new DateTime(1,1,1, 10, 0, 0),
                    To = new DateTime(1,1,1, 11, 0, 0)
            },
                new LectureTime
            {
                    From = new DateTime(1,1,1, 11, 0, 0),
                    To = new DateTime(1,1,1, 12, 0, 0)
            }
        };
        public static LectureTime[] AfternoonTimes { get; set; } =
        {
            new LectureTime
            {
                    From = new DateTime(1,1,1, 13, 0, 0),
                    To = new DateTime(1,1,1, 14, 0, 0)
            },
            new LectureTime
            {
                    From = new DateTime(1,1,1, 14, 0, 0),
                    To = new DateTime(1,1,1, 15, 0, 0)
            },
            new LectureTime
            {
                    From = new DateTime(1,1,1, 15, 30, 0),
                    To = new DateTime(1,1,1, 16, 30, 0)
            },
            new LectureTime
            {
                    From = new DateTime(1,1,1, 16, 30, 0),
                    To = new DateTime(1,1,1, 17, 30, 0)
            }
        };
        public static string[][] Topics { get; set; } =
        {
            new string[]
            {
                "Intercepts and Curves",
                "Perpendicular Lines",
                "Quadratic Equations and Inequalities"
            },
            new string[]
            {
                "Portrayal of women in Othello",
                "Relationships in Pride and Prejudice",
                "Romance in Thomas Hardy"
            },
            new string[]
            {
                "Future perfect tense",
                "Present continuous",
                "Adverb and Its Kinds"
            },
            new string[]
            {
                "One-dimensional motion",
                "Forces and Newton's laws of motion",
                "Uniform circular motion and gravitation"
            },
            new string[]
            {
                "Chemical equilibrium",
                "Electrochemistry",
                "Atomic Structure"
            },
            new string[]
            {
                "Electrochemistry",
                "The circulatory and respiratory systems",
                "Human body systems: Unit test"
            },
            new string[]
            {
                "Industrial Revolution",
                "Great Depression",
                "American Civil War"
            },
            new string[]
            {
                "Macrogeographical Regions & Subregions of the World",
                "Metageography: Definition & Examples",
                "Landforms, Geology & Life"
            },
            new string[]
            {
                "Communication networks",
                "Advanced spreadsheet uses",
                "Internet and the World Wide Web"
            },
            new string[]
            {
                "Citizenship & Nationalism",
                "Human Rights",
                "Public service in Democracy"
            },
            new string[]
            {
                "Hand-to-hand combat and weapons training",
                "Basic rifle marksmanship",
                "Fundamentals of soldiering"
            },
            new string[]
            {
                "Air Squat & Hinge",
                "Plateau, Regression and Reversibility",
                "Warm-up/Cool-down"
            },
            new string[]
            {
                "Understanding the Concept of Kanji",
                "Hiragana and katakana",
                "Beginning Kanji & Stockpiling Kanji Knowledge"
            },
            new string[]
            {
                "Le passé composé",
                "L'imperatif",
                "Conjugation"
            },
        };
    }

}