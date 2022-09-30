using System.ComponentModel.DataAnnotations;

namespace DnDWebAPI.Models
{
    public class Character
    {
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
