using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using API_BaseDeDatos.Services;
using API_BaseDeDatos.Models;
using System.Collections.Generic;

namespace API_BaseDeDatos.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokemonService _pokemonService;

        public PokemonController(PokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        // Acción para listar Pokémon y mostrarlos en una vista
        public async Task<IActionResult> Index()
        {
            var pokemons = await _pokemonService.GetPokemonsAsync(20);
            // Protegemos contra null y pasamos una lista vacía si no hay resultados
            return View(pokemons?.Results ?? new List<Pokemon>());
        }

        // Acción para buscar por nombre
        public async Task<IActionResult> DetallePorNombre(string name)
        {
            var pokemon = await _pokemonService.GetPokemonByNameAsync(name);
            return View(pokemon);
        }

        // Acción para buscar por ID
        public async Task<IActionResult> DetallePorId(int id)
        {
            var pokemon = await _pokemonService.GetPokemonByIdAsync(id);
            return View(pokemon);
        }
      
    }
}
