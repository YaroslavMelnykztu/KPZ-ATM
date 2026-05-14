using System;

namespace ATM.Services
{
    public class InputValidator
    {
        public bool IsValidAmount(string input, out double validAmount)
        {
            validAmount = 0;
            if (double.TryParse(input, out double amount))
            {
                if (amount > 0 && amount <= 100000)
                {
                    validAmount = amount;
                    return true;
                }
            }
            return false;
        }

        public bool IsValidCardNumber(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber))
            {
                return false;
            }

            if (cardNumber.Length < 4 || cardNumber.Length > 16)
            {
                return false;
            }

            foreach (char c in cardNumber)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsValidPin(string pin)
        {
            if (string.IsNullOrEmpty(pin))
            {
                return false;
            }

            if (pin.Length != 4)
            {
                return false;
            }

            foreach (char c in pin)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}