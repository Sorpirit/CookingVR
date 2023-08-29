using Core.CookingDevice;
using Core.Food;
using Scripts.DependancyInjector;
using UnityEngine;

namespace CoreTest
{
    public class TestCounterContainer : MonoDependancyInjector, IFoodContainer
    {
        [SerializeField] private string _debugName;

        private int _counter;

        public override void InstallBindings()
        {
            RegisterSingle<IFoodContainer, TestCounterContainer>(this);
        }

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