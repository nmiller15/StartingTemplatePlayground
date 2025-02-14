using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Interfaces;

namespace Services
{
    public class RandomFactProvider : IRandomFactProvider
    {
        public enum FactTypes
        {
            Animal,
            Space,
            Historical
        }
        
        private string Fact { get; set; }

        private readonly string[] _animalFacts = new[]
        {
            "A cat has been mayor of Talkeetna, Alaska, for 15 years.",
            "A group of flamingos is called a flamboyance.",
            "A group of ferrets is called a business.",
            "A group of rhinos is called a crash.",
            "A group of kangaroos is called a mob.",
            "A group of crows is called a murder."
        };

        private readonly string[] _spaceFacts = new[]
        {
            "A day on Venus is longer than a year on Venus.",
            "There are more stars in the universe than grains of sand on all the Earth's beaches.",
            "Neutron stars can spin at a rate of 600 rotations per second.",
            "A spoonful of a neutron star would weigh about 6 billion tons.",
            "The footprints on the Moon will likely stay there for millions of years."
        };

        private readonly string[] _historicalFacts = new[]
        {
            "The shortest war in history was between Britain and Zanzibar on August 27, 1896. Zanzibar surrendered after 38 minutes.",
            "The first Olympic Games were held in 776 BC in ancient Greece.",
            "The Great Wall of China is over 13,000 miles long.",
            "Leonardo da Vinci could write with one hand and draw with the other at the same time.",
            "The Eiffel Tower can be 15 cm taller during the summer due to the expansion of iron in the heat."
        };

        public bool HasBeenUsed { get; set; } = false;

        public string GetFact(FactTypes factType)
        {
            var facts = factType switch
            {
                FactTypes.Animal => _animalFacts,
                FactTypes.Space => _spaceFacts,
                FactTypes.Historical => _historicalFacts
            };
            if (!HasBeenUsed)
            {
                var random = new Random();
                int index = random.Next(facts.Length);
                Fact = facts[index];
            }
            HasBeenUsed = true;
            return Fact;
        }

        public RandomFactProvider()
        {
            
        }
    }
}
