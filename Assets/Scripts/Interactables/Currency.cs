using SO;
using UnityEngine;
using User;

namespace Interactables
{
    public class Currency : Interactable
    {
        [SerializeField] private SCurrency currencySettings;
        
        protected override void OnInteract(Collider other)
        {
            other.GetComponent<UserCurrency>().AddCurrency(currencySettings.CurrencyValue);
        }
    }
}
