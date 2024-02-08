using Core.Food;
using System.Collections.Generic;
using UnityEngine;

namespace Core.CookingDevice
{
    public class FringPan : MonoBehaviour, IFoodContainer, IStoveCooker
    {
        [SerializeField]
        private Transform _foodRoot;

        private HashSet<FoodObject> _content = new();

        public void AddFood(FoodObject food)
        {
            bool result = _content.Add(food);
            Debug.Assert(result);

            //food.transform.SetParent(_foodRoot);
        }

        public void RemoveFood(FoodObject food)
        {
            bool result = _content.Remove(food);
            Debug.Assert(result);

            //food.transform.SetParent(_foodRoot);
        }

        public void StartCooking()
        {
            Debug.Log("Lets cook");
        }

        public void StopCooking()
        {
            Debug.Log("It was nice cooking with you");
        }
    }
}