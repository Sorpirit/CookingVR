using UnityEngine;
using Core.Food;

namespace Core.CookingDevice
{
    public class FoodContainerTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject _container;

        private IFoodContainer _foodContainer;

        private void Awake()
        {
            Debug.Assert(_container.TryGetComponent<IFoodContainer>(out var container), "No valid container is assigned to the tigger");
            InitFoodContainer(container);
        }

        public void InitFoodContainer(IFoodContainer foodContainer)
        {
            _foodContainer = foodContainer;
        }

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