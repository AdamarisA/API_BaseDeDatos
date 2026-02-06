namespace API_BaseDeDatos.Models
{
    public class Pokemon
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class PokemonListResponse 
    {
        public int Count { get; set; } 
        public List<Pokemon> Results { get; set; } = new List<Pokemon>(); 
    }
}
