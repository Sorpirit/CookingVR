using Core.Food;
using System.Collections.Generic;
using UnityEngine;

namespace Core.CookingDevice
{
    public class FringPan : MonoBehaviour, IFoodContainer, IStoveCooker
    {
        private HashSet<FoodObject> _content;

        public void AddFood(FoodObject food)
        {
            bool result = _content.Add(food);
            Debug.Assert(result);
        }

        public void RemoveFood(FoodObject food)
        {
            bool result = _content.Remove(food);
            Debug.Assert(result);
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