using NationalFruits.API.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NationalFruits.API.Services
{
    public class FruitsRepo : IFruitsRepo
    {
        private readonly List<Fruit> _fruits = new();
        public FruitsRepo()
        {
            _fruits = new() {
            new Fruit{Id = 1, National = "Australia", FruitName= "Riberry" },
            new Fruit{Id = 2, National = "India", FruitName= "Mango"},
            new Fruit{Id = 3, National = "Russia", FruitName= "Stroberry"},
            new Fruit{Id = 4, National = "Belgium", FruitName= "Apple"},
            };
        }
        //public async Task<List<string>> Test_Convert2Async()
        //{
        //    return await Task.FromResult(new List<string>() { "",""});
        //}

        //public async Task<List<Fruit>> AllFruits()
        //{
        //    return await Task.FromResult(_fruits.ToList());
        //}
        public List<Fruit> AllFruits()
        {
            //System.Diagnostics.Debug.WriteLine(_fruits.Count());
            return _fruits;
        }
        public Fruit GetFruitById(int id)
        {
            return _fruits.FirstOrDefault(i => i.Id == id);
        }
        public void AddFruit(Fruit nf)
        {
            var nextId = _fruits.Max(i => i.Id);
            nf.Id = ++nextId;
            _fruits.Add(nf);
        }
        public void RemoveFruit(int id)
        {
            var nf = _fruits.FirstOrDefault(i => i.Id == id);
            if (nf != null) _fruits.Remove(nf);
        }
        public void UpdateFruit(Fruit nf)
        {
            var fruit = _fruits.FirstOrDefault(i => i.Id == nf.Id);
            if (fruit != null)
            {
                fruit.FruitName = nf.FruitName;
                fruit.National = nf.National;
            }
        }
    }
}
