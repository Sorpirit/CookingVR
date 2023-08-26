using Core.Food;

namespace Core.CookingDevice
{
    public interface IFoodContainer
    {
        void AddFood(FoodObject food);
        void RemoveFood(FoodObject food);
    }
}
