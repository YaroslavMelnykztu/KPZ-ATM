using System;

public void Transfer(string targetCardNumber, double amount)
{
    var targetCard = FindCardInDatabase(targetCardNumber);

    if (targetCard != null && this.currentBalance >= amount)
    {
        this.currentBalance -= amount;
        targetCard.Balance += amount;

        LogToHistory("Переказ на карту " + targetCardNumber + ": " + amount);
        SaveAllData(); // Записуємо зміни у файл
    }
}
