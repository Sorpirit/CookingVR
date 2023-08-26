using UnityEngine;

namespace Core.Food
{
    /// <summary>
    /// Base food class
    /// </summary>
    public class FoodObject : MonoBehaviour
    {
        [SerializeField]
        private string _debugName;

        public override string ToString()
        {
            return "FoodObject: " + _debugName;
        }
    }
}