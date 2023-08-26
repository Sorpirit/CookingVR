using Core.CookingDevice;
using Core.Food;
using UnityEngine;

namespace CoreTest
{
    public class TestCounterContainer : MonoBehaviour, IFoodContainer
    {
        [SerializeField] private string _debugName;

        private int _counter;

        public void AddFood(FoodObject food)
        {
            _counter++;
            Debug.Log($"{_debugName} (count: {_counter}) Added {{ {food} }}");
        }

        public void RemoveFood(FoodObject food)
        {
            _counter--;
            Debug.Log($"{_debugName} (count: {_counter}) Removed {{ {food} }}");
        }
    }
}