using UnityEngine;
using Core.Food;
using Scripts.DependancyInjector;

namespace Core.CookingDevice
{
    public class FoodContainerTrigger : MonoBehaviour
    {
        [Inject]
        private IFoodContainer _foodContainer;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Assert(_foodContainer != null);
            if (other.TryGetComponent<FoodObject>(out var food))
                _foodContainer.AddFood(food);
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Assert(_foodContainer != null);
            if (other.TryGetComponent<FoodObject>(out var food))
                _foodContainer.RemoveFood(food);
        }
    }
}