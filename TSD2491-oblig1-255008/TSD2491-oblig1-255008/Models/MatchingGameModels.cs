using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Timers;
using System.ComponentModel;
using TSD2491_oblig1_255008;
using TSD2491_oblig1_255008.Models;

namespace TSD2491_oblig1_255008
{
    public class MatchingGameModels
    {
        public int matchesFound = 0;
        public int GamesPlayed = 0;

        public string GameStatus { get; set; }
        public User CurrentUser { get; set; }

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

        static List<string> sweetEmoji = new List<string>()
        {
            "🍦","🍦",
            "🍡","🍡",
            "🍪","🍪",
            "🍬","🍬",
            "🎂","🎂",
            "🍫","🍫",
            "🍭","🍭",
            "📍","📍",

        };




        static List<string> ballEmoji = new List<string>()
        {
            "⚽","⚽",
            "⚾","⚾",
            "🥎","🥎",
            "🏀","🏀",
            "🏐","🏐",
            "🏈","🏈",
            "🏉","🏉",
            "🎱","🎱",
            
        };
        public MatchingGameModels()
                {
                    SetUpGame();
                }


        static Random random = new Random();
        public List<string> shuffledEmoji = pickRandomEmoji();

        static List<string> pickRandomEmoji()
        {
            int randomIndex = random.Next(0, 3);

            switch (randomIndex)
            {
                case 0:
                    return ballEmoji = ballEmoji.OrderBy(items => random.Next()).ToList(); ;
                case 1:
                    return animalEmoji = animalEmoji.OrderBy(items => random.Next()).ToList(); ;
                case 2:
                    return sweetEmoji = sweetEmoji.OrderBy(items => random.Next()).ToList(); ;
              
              
                default:
                    throw new Exception("Invalid random index");
            }
        }
        public void SetUpGame()
        {
            Random random = new Random();
            shuffledEmoji = pickRandomEmoji();

            matchesFound = 0;
        }

        string lastAnimalFound = string.Empty;
        string lastDescription = string.Empty;


        public void ButtonClick(string animal, string animalDescription)
        {
            if(matchesFound == 0)
            {
                GameStatus = "Game Running";
            }
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

                shuffledEmoji = shuffledEmoji
                    .Select(a => a.Replace(animal, string.Empty))
                    .ToList();
                matchesFound++;
                if (matchesFound == 8)
                {
                    GameStatus = "Game Finished";
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