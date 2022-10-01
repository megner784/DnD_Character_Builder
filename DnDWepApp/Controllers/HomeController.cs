using DnDWepApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace DnDWepApp.Controllers
{
    public class HomeController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();

        CharacterEntity _oCharacter = new CharacterEntity();
        List<CharacterEntity> _oCharacters = new List<CharacterEntity>();

        private readonly ILogger<HomeController> _logger;

        // Need the base URL to the DnDWebAPI 
        string baseURL = "https://localhost:7098/";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        // This action will retrieve all game characters
        public async Task<IActionResult> Index()
        {
            _oCharacters = new List<CharacterEntity>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync(baseURL + "api/Characters"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oCharacters = JsonConvert.DeserializeObject<List<CharacterEntity>>(apiResponse);
                }
            }

            // Bind to the view model
            ViewData.Model = _oCharacters;
            
            return View();
        }

        // This action will ADD a new game character
        public async Task<ActionResult<String>> AddCharacter(CharacterEntity gamechar)
        {
            List<GameCharacterClass> GameCharClassList = new List<GameCharacterClass>();

            GameCharClassList.Add(new GameCharacterClass { ClassID = "Barbarian",  ClassName = "Barbarian" });
            GameCharClassList.Add(new GameCharacterClass { ClassID = "Bard",       ClassName = "Bard" });
            GameCharClassList.Add(new GameCharacterClass { ClassID = "Cleric",     ClassName = "Cleric" });
            GameCharClassList.Add(new GameCharacterClass { ClassID = "Druid",      ClassName = "Druid" });
            GameCharClassList.Add(new GameCharacterClass { ClassID = "Fighter",    ClassName = "Fighter" });
            GameCharClassList.Add(new GameCharacterClass { ClassID = "Monk",       ClassName = "Monk" });
            GameCharClassList.Add(new GameCharacterClass { ClassID = "Paladin",    ClassName = "Paladin" });
            GameCharClassList.Add(new GameCharacterClass { ClassID = "Ranger",     ClassName = "Ranger" });
            GameCharClassList.Add(new GameCharacterClass { ClassID = "Rogue",      ClassName = "Rogue" });
            GameCharClassList.Add(new GameCharacterClass { ClassID = "Sorcerer",   ClassName = "Sorcerer" });
            GameCharClassList.Add(new GameCharacterClass { ClassID = "Warlock",    ClassName = "Warlock" });
            GameCharClassList.Add(new GameCharacterClass { ClassID = "Wizard",     ClassName = "Wizard" });

            ViewBag.ClassList = GameCharClassList;

            List<GameCharacterRace> GameCharRaceList = new List<GameCharacterRace>();

            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Dragonborn",          RaceName = "Dragonborn" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Dragonborn (BlacK)",  RaceName = "Dragonborn (Black)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Dragonborn (Blue)",   RaceName = "Dragonborn (Blue)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Dragonborn (Brass)",  RaceName = "Dragonborn (Brass)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Dragonborn (Bronze)", RaceName = "Dragonborn (Bronze)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Dragonborn (Copper)", RaceName = "Dragonborn (Copper)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Dragonborn (Gold)",   RaceName = "Dragonborn (Gold)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Dragonborn (Green)",  RaceName = "Dragonborn (Green)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Dragonborn (Red)",    RaceName = "Dragonborn (Red)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Dragonborn (Silver)", RaceName = "Dragonborn (Silver)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Dragonborn (White)",  RaceName = "Dragonborn (White)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Dwarf",               RaceName = "Dwarf" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Dwarf (Hill)",        RaceName = "Dwarf (Hill)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Dwarf (Mountain)",    RaceName = "Dwarf (Mountain)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Elf",                 RaceName = "Elf" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Elf (Dark/Drow)",     RaceName = "Elf (Dark/Drow)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Elf (Half)",          RaceName = "Elf (Half)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Elf (High)",          RaceName = "Elf (High)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Elf (Wood)",          RaceName = "Elf (Wood)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Gnome",               RaceName = "Gnome" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Gnome (Forest)",      RaceName = "Gnome (Forest)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Gnome (Rock)",        RaceName = "Gnome (Rock)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Gnome (Deep)",        RaceName = "Gnome (Deep)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Halfling",            RaceName = "Halfling" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Halfling (Light)",    RaceName = "Halfling (Light)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Halfling (Stout)",    RaceName = "Halfling (Stout)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Human",               RaceName = "Human" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Human (Calishite)",   RaceName = "Human (Calishite)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Human (Chondathan)",  RaceName = "Human (Chondathan)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Human (Damarian)",    RaceName = "Human (Damarian)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Human (Illuskan)",    RaceName = "Human (Illuskan)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Human (Mulan)",       RaceName = "Human (Mulan)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Human (Rashemi)",     RaceName = "Human (Rashemi)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Human (Shou)",        RaceName = "Human (Shou)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Human (Tethyrian)",   RaceName = "Human (Tethyrian)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Human (Turami)",      RaceName = "Human (Turami)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Orc (Half)",          RaceName = "Orc (Half)" });
            GameCharRaceList.Add(new GameCharacterRace { RaceID = "Tiefling",            RaceName = "Tiefling" });

            ViewBag.RaceList = GameCharRaceList;

            CharacterEntity obj = new CharacterEntity()
            {
                CharacterName    = gamechar.CharacterName,
                PlayerName       = gamechar.PlayerName,
                Race             = gamechar.Race,
                CharacterClass   = gamechar.CharacterClass,
                Level            = gamechar.Level,
                Strength         = gamechar.Strength,
                Dexterity        = gamechar.Dexterity,
                Constitution     = gamechar.Constitution,
                Intelligence     = gamechar.Intelligence,
                Wisdom           = gamechar.Wisdom,
                Charisma         = gamechar.Charisma,
                ProficiencyBonus = gamechar.ProficiencyBonus,
            };

            // Check if user entered a valid character name
            if (gamechar.CharacterName != null || gamechar.CharacterName.Length > 0)
            {

                using (var httpClient = new HttpClient(_clientHandler))
                {
                    httpClient.BaseAddress = new Uri(baseURL);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //HttpResponseMessage getData = await client.PostAsJsonAsync("api/Character", obj);
                    var getData = await httpClient.PostAsJsonAsync("api/Character", obj);

                    if (getData.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        Console.WriteLine("Error calling DnDWebAPI!");
                    }
                }
            }

            // Bind to the view model
            ViewData.Model = obj;

            return View();
        }

        // This action will UPDATE a game character
        public async Task<ActionResult<CharacterEntity>> UpdateCharacter(CharacterEntity gamechar)
        {
            CharacterEntity obj = new CharacterEntity()
            {
                Id               = gamechar.Id,
                CharacterName    = gamechar.CharacterName,
                PlayerName       = gamechar.PlayerName,
                Race             = gamechar.Race,
                CharacterClass   = gamechar.CharacterClass,
                Level            = gamechar.Level,
                Strength         = gamechar.Strength,
                Dexterity        = gamechar.Dexterity,
                Constitution     = gamechar.Constitution,
                Intelligence     = gamechar.Intelligence,
                Wisdom           = gamechar.Wisdom,
                Charisma         = gamechar.Charisma,
                ProficiencyBonus = gamechar.ProficiencyBonus,
            };

            var jsonString = JsonConvert.SerializeObject(obj);

            var characterContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient(_clientHandler))
            {
                var response = await httpClient.PutAsync(baseURL + "api/Character/" + obj.Id, characterContent);
            }

            return RedirectToAction("Index", "Home");
        }

        // This action will retrieve a game character by Id
        public async Task<ActionResult<CharacterEntity>> ViewCharacter(int Id)
        {
            _oCharacter = new CharacterEntity();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync(baseURL + "api/Character/" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oCharacter = JsonConvert.DeserializeObject<CharacterEntity>(apiResponse);
                }
            }

            // Bind to the view model
            ViewData.Model = _oCharacter;

            return View();
        }

        // This action will DELETE a game character
        public async Task<ActionResult<String>> DeleteCharacter(int Id)
        {
            //string message = "";

            using (var httpClient = new HttpClient(_clientHandler))
            {
                httpClient.BaseAddress = new Uri(baseURL);

                using (var response = await httpClient.DeleteAsync("api/Character/" + Id))
                {
                    //message = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            return RedirectToAction("Index", "Home");

        }

        // This action will view a customized game character sheet by Id
        public async Task<ActionResult<CharacterEntity>> ViewSheet(int Id)
        {
            _oCharacter = new CharacterEntity();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync(baseURL + "api/Character/" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oCharacter = JsonConvert.DeserializeObject<CharacterEntity>(apiResponse);
                }
            }

            // Bind to the view model
            ViewData.Model = _oCharacter;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult GameHelp()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}