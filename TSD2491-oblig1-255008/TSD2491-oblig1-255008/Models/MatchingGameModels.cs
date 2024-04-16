using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Timers;

namespace TSD2491_oblig1_255008
{
    public class MatchingGameModels
    {
        public int matchesFound = 0;

        static List<string> animalEmoji = new List<string>()
        {
            "🐶", "🐶",
            "🐺", "🐺",
            "🐮", "🐮",
            "🦊", "🦊",
            "🐱", "🐱",
            "🦁", "🦁",
            "🐯", "🐯",
            "🐭", "🐭",
        };

        static Random random = new Random();
        public List<string> animals = animalEmoji;

        public MatchingGameModels()
        {
            SetUpGame();
        }

        private void SetUpGame()
        {
            Random random = new Random();
            animals = animalEmoji.OrderBy(items => random.Next()).ToList();

            matchesFound = 0;
        }

        string lastAnimalFound = string.Empty;
        string lastDescription = string.Empty;


      
    }
}