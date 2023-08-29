using Core.CookingDevice;
using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Scripts.Core.CookingDevice
{
    public class Stove : MonoBehaviour
    {
        [SerializeField] private XRSocketInteractor interactor;

        private GameObject cookingDevice;
        private IStoveCooker cooker;

        private void OnEnable()
        {
            interactor.selectEntered.AddListener(StartCooking);
            interactor.selectExited.AddListener(StopCooking);
        }

        private void OnDisable()
        {
            interactor.selectEntered.RemoveListener(StartCooking);
            interactor.selectExited.RemoveListener(StopCooking);
        }

        private void StopCooking(SelectExitEventArgs arg0)
        {
            cooker?.StopCooking();
            cooker = null;
            cookingDevice = null;
        }

        private void StartCooking(SelectEnterEventArgs arg0)
        {
            var interactableGO = arg0.interactorObject.GetOldestInteractableSelected().transform.gameObject;
            Debug.Log(interactableGO);
            var result = interactableGO.TryGetComponent(out cooker);
            Debug.Assert(result);
            cookingDevice = interactableGO;
            cooker?.StartCooking();
        }
    }
}
