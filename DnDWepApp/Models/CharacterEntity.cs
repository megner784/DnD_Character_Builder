using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace DnDWepApp.Models
{
	public class CharacterEntity
	{
        public CharacterEntity()
        {
            // This is the no parameter constructor method. 
            // Set default values for several character attributes
            CharacterName    = "";
            PlayerName       = "";
            Race             = "";
            CharacterClass   = "";

            Level            = 1;

            Strength         = 15;
            Dexterity        = 14;
            Constitution     = 13;
            Intelligence     = 12;
            Wisdom           = 10;
            Charisma         =  8;

            ProficiencyBonus =  2;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your character's name.")]
        public string? CharacterName { get; set; }

        [Required(ErrorMessage = "Please enter your player name.")]
        public string? PlayerName { get; set; }

        
        public string? Race { get; set; }

        
        public string? CharacterClass { get; set; }

        [Required(ErrorMessage = "Please enter a character level.")]
        [Range(1, 20, ErrorMessage = "The character level must be between 1 and 20.")]
        public int? Level { get; set; }

        [Required(ErrorMessage = "Please enter your character's strength.")]
        [Range(3, 18, ErrorMessage = "The strength ability must be between 3 and 18.")]
        public int? Strength { get; set; }

        [Required(ErrorMessage = "Please enter your character's dexterity.")]
        [Range(3, 18, ErrorMessage = "The dexterity ability must be between 3 and 18.")]
        public int? Dexterity { get; set; }

        [Required(ErrorMessage = "Please enter your character's constitution.")]
        [Range(3, 18, ErrorMessage = "The constitution ability must be between 3 and 18.")]
        public int? Constitution { get; set; }

        [Required(ErrorMessage = "Please enter your character's intelligence.")]
        [Range(3, 18, ErrorMessage = "The intelligence ability must be between 3 and 18.")]
        public int? Intelligence { get; set; }

        [Required(ErrorMessage = "Please enter your character's wisdom.")]
        [Range(3, 18, ErrorMessage = "The wisdom ability must be between 3 and 18.")]
        public int? Wisdom { get; set; }

        [Required(ErrorMessage = "Please enter your character's charisma.")]
        [Range(3, 18, ErrorMessage = "The charisma ability must be between 3 and 18.")]
        public int? Charisma { get; set; }

        [Required(ErrorMessage = "Please enter your character's proficiency bonus.")]
        [Range(2, 6, ErrorMessage = "The proficiency bonus must be between 2 and 6.")]
        public int? ProficiencyBonus { get; set; }
    }

    public class GameCharacterClass
    {
        public string ClassID   { get; set; }
        public string ClassName { get; set; }
    }

    public class GameCharacterRace
    {
        public string RaceID { get; set; }
        public string RaceName { get; set; }
    }

}

