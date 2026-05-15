# ATM Project

Проєкт імітує роботу банкомата з візуальним інтерфейсом (Windows Forms).

## Запуск проєкту
Відкрийте рішення у Visual Studio, встановіть пакет Newtonsoft.Json через NuGet та запустіть програму. Файл бази даних `database.json` створиться автоматично.

## Опис функціональності
Програма підтримує такі основні функції:
* Авторизація користувачів за номером картки та захешованим пін-кодом (`ATM/UI/LoginForm.cs`).
* Перевірка та відображення поточного балансу (`ATM/Services/ATMService.cs`).
* Зняття готівки та поповнення рахунку (`ATM/UI/CashForm.cs`).
* Переказ коштів на інші картки (`ATM/UI/TransferForm.cs`).
* Оплата послуг (мобільний зв'язок, комуналка, інтернет) з генерацією чека (`ATM/UI/PaymentsForm.cs`, `ATM/Services/PaymentService.cs`).
* Перегляд історії транзакцій (`ATM/UI/HistoryForm.cs`).
* Валідація введених даних (`ATM/Services/InputValidator.cs`).

Усі дані зберігаються локально у файлі формату JSON (`ATM/Data/FileStorage.cs`).

## Programming Principles
1. Single Responsibility Principle (SRP): Кожен клас має одну зону відповідальності. Наприклад, `InputValidator.cs` відповідає лише за перевірку даних, а форми в `ATM/UI/` відповідають лише за відображення інтерфейсу.
2. Don't Repeat Yourself (DRY): Логіка отримання балансу винесена в окремий метод `GetBalance` в `ATMService.cs`, замість дублювання коду прямого доступу до бази в кожній формі.
3. Open/Closed Principle (OCP): Реалізовано через інтерфейс `ICommissionStrategy.cs`. Можна додавати нові типи комісій (наприклад, для кредитних карток), не змінюючи існуючий код сервісу.
4. Keep It Simple, Stupid (KISS): Код форм спрощений, складні розрахунки винесені у відповідні сервіси.
5. You Aren't Gonna Need It (YAGNI): У базі даних `Account.cs` зберігаються лише ті поля, які дійсно необхідні для поточної роботи банкомата.

## Design Patterns
1. Singleton (`ATM/Data/FileStorage.cs`): Використано для гарантії того, що система має лише одну точку доступу до файлу бази даних, запобігаючи конфліктам при одночасному читанні/запису.
2. Strategy (`ATM/Strategies/`): Використано для динамічного розрахунку комісії за транзакції. `ATMService` працює з абстракцією `ICommissionStrategy`, що дозволяє легко перемикатися між `DefaultCommission` та `FreeCommission`.
3. Factory Method (`ATM/Factories/TransactionFactory.cs`): Використано для централізованого створення різних типів об'єктів транзакцій (змінна комісія, різні цільові реквізити), ізолюючи логіку ініціалізації від основних сервісів.

## Refactoring Techniques
1. Extract Class: Створення `PaymentService` для розвантаження `ATMService`.
2. Extract Method: Винесення логіки збереження транзакцій у метод `LogTransaction`.
3. Replace Magic Literal: Заміна жорстко закодованих шляхів до файлів на змінні у класі `FileStorage`.
4. Remove Dead Code: Видалення файлу `DbContext`, який дублював функціонал.
5. Consolidate Duplicate Conditional Fragments: Винесення перевірок `InputValidator` за межі основних блоків виконання.