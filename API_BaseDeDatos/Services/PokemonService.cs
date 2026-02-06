using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using API_BaseDeDatos.Models;
using API_BaseDeDatos.Services;
using System.Collections.Generic;

namespace API_BaseDeDatos.Services
{
    public class PokemonService
    {
        private readonly HttpClient _httpClient; 
        private readonly string _baseUrl; 
        public PokemonService(HttpClient httpClient, IOptions<ApiSettings> options) 
        { _httpClient = httpClient; _baseUrl = options.Value.PokeApi.BaseUrl; } 

        // 1. Listar Pokémon
        public async Task<PokemonListResponse> GetPokemonsAsync(int limit = 10) 
        {
            var response = await _httpClient.GetStringAsync($"{_baseUrl}pokemon?limit={limit}");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var result = JsonSerializer.Deserialize<PokemonListResponse>(response, options);
            return result ?? new PokemonListResponse { Results = new List<Pokemon>() };
        } 

        // 2. Obtener detalle por nombre
        public async Task<PokemonDetail> GetPokemonByNameAsync(string name)
        { 
            var response = await _httpClient.GetStringAsync($"{_baseUrl}pokemon/{name}");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<PokemonDetail>(response, options);
        } 

        // 3. Obtener detalle por ID
        public async Task<PokemonDetail> GetPokemonByIdAsync(int id) 
        { 
            var response = await _httpClient.GetStringAsync($"{_baseUrl}pokemon/{id}");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<PokemonDetail>(response, options);
        }
    }
}
