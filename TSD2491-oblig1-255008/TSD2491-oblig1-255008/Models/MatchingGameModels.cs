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


        public void ButtonClick(string animal, string animalDescription)
        {
            if (lastAnimalFound == string.Empty)
            {
                // First selection of the pari.  Remember it
                lastAnimalFound = animal;
                lastDescription = animalDescription;
            }
            else if ((lastAnimalFound == animal) && (animalDescription != lastDescription))
            {
                // Match found! Reset for the next pair.
                lastAnimalFound = string.Empty;

                animals = animals
                    .Select(a => a.Replace(animal, string.Empty))
                    .ToList();
                matchesFound++;
                if (matchesFound == 8)
                {
                    SetUpGame();
                }
            }
            else
            {
                lastAnimalFound = string.Empty;
            }
        }
    }
}