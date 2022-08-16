using NationalFruits.API.Data;

namespace NationalFruits.API.Services
{
    public interface IFruitsRepo
    {
        public void AddFruit(Fruit nf);
        //public Task<List<Fruit>> AllFruits();
        public List<Fruit> AllFruits();
        public Fruit GetFruitById(int id);
        public void RemoveFruit(int id);
        public void UpdateFruit(Fruit nf);
    }
}