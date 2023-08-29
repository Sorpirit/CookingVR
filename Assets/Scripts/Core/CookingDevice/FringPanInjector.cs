using Core.CookingDevice;
using Scripts.DependancyInjector;
using UnityEngine;

namespace Scripts.Core.CookingDevice
{
    public class FringPanInjector : MonoDependancyInjector
    {
        [SerializeField] private FringPan fringPan;

        public override void InstallBindings()
        {
            RegisterSingle<IFoodContainer, FringPan>(fringPan);
        }
    }
}
