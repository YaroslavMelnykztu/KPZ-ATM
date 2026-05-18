using System;
using System.Text;

namespace ATM.Services
{
    // Інтерфейс будівельника чеків
    public interface IReceiptBuilder
    {
        IReceiptBuilder SetHeader();
        IReceiptBuilder SetOperationType(string type);
        IReceiptBuilder SetAmount(double amount);
        IReceiptBuilder SetDate(DateTime date);
        IReceiptBuilder SetDetails(string details);
        IReceiptBuilder SetFooter();
        string Build();
    }

    // Конкретний будівельник для текстових чеків
    public class TextReceiptBuilder : IReceiptBuilder
    {
        private StringBuilder _receipt;

        public TextReceiptBuilder()
        {
            _receipt = new StringBuilder();
        }

        public IReceiptBuilder SetHeader()
        {
            _receipt.AppendLine("---------- ЧЕК ----------");
            return this;
        }

        public IReceiptBuilder SetOperationType(string type)
        {
            _receipt.AppendLine("Тип операції: " + type);
            return this;
        }

        public IReceiptBuilder SetAmount(double amount)
        {
            _receipt.AppendLine("Сума: " + amount.ToString("F2") + " UAH");
            return this;
        }

        public IReceiptBuilder SetDate(DateTime date)
        {
            _receipt.AppendLine("Дата: " + date.ToString("dd.MM.yyyy HH:mm"));
            return this;
        }

        public IReceiptBuilder SetDetails(string details)
        {
            if (!string.IsNullOrEmpty(details))
            {
                _receipt.AppendLine("Деталі: " + details);
            }
            return this;
        }

        public IReceiptBuilder SetFooter()
        {
            _receipt.AppendLine("-------------------------");
            _receipt.AppendLine("Дякуємо, що обрали нас!");
            return this;
        }

        public string Build()
        {
            return _receipt.ToString();
        }
    }
}