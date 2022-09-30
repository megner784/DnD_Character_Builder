using System.ComponentModel.DataAnnotations;

namespace DnDWepApp.Models
{
	public class CharacterEntity
	{
        public CharacterEntity()
        {
            // This is the no parameter constructor method. 
            // Set default values to a character's ability scores
            Strength     = 15;
            Dexterity    = 14;
            Constitution = 13;
            Intelligence = 12;
            Wisdom       = 10;
            Charisma     =  8;

            ProficiencyBonus = 0;
        }

        public int Id { get; set; }

        [Required]
        public string CharacterName { get; set; }

        [Required]
        public string PlayerName { get; set; }

        public string Race { get; set; }

        public string CharacterClass { get; set; }

        public int Level { get; set; }

        public int Strength { get; set; }

        public int Dexterity { get; set; }

        public int Constitution { get; set; }

        public int Intelligence { get; set; }

        public int Wisdom { get; set; }

        public int Charisma { get; set; }

        public int ProficiencyBonus { get; set; }
    }
}

