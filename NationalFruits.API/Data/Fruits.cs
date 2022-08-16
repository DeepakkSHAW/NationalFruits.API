namespace NationalFruits.API.Data
{
    //public record Fruit(int Id, string FruitName, string National);
    public record Fruit()
    {
        public int Id { get; set; }
        public string FruitName { get; set; }
        public string National { get; set; }
    }
}
