namespace API_BaseDeDatos
{
    public class ApiSettings
    {
        public PokeApiSettings PokeApi { get; set; }
    }
    public class PokeApiSettings
    {
        public string BaseUrl { get; set; }
    }
}
