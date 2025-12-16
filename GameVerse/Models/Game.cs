namespace GameVerse.Models
{
    public class Game
    {
        public int GameID { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
