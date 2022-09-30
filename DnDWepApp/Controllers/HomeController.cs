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
            if (gamechar.CharacterName != null)
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
            string message = "";

            using (var httpClient = new HttpClient(_clientHandler))
            {
                httpClient.BaseAddress = new Uri(baseURL);

                using (var response = await httpClient.DeleteAsync("api/Character/" + Id))
                {
                    message = await response.Content.ReadAsStringAsync();

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