using UnityEngine;

namespace User
{
    public class UserCurrency : MonoBehaviour
    {
        public int CurrentCurrency { get; private set; }

        public void AddCurrency(int amount) => CurrentCurrency += amount;

        public bool SpendCurrency(int amount)
        {
            if (CurrentCurrency < amount) return false;
            CurrentCurrency -= amount;
            return true;
        }
    }
}
