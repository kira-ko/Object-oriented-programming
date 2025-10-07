using System;
using System.Collections.Generic;
using System.Text;

class Product
{
    public string Name { get; }
    public int Price { get; }
    public int Quantity { get; private set; }

    public Product(string name, int price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public bool Buy()
    {
        if (Quantity > 0)
        {
            Quantity--;
            return true;
        }
        return false;
    }

    public void Refill(int amount)
    {
        Quantity += amount;
    }
}

class VendingMachine
{
    private List<Product> products = new();
    private int balance = 0;
    private int collectedMoney = 0;
    private int[] coinDenominations = new int[] { 50, 20, 10, 5, 2, 1 }; // для выдачи сдачи

    public VendingMachine()
    {
        products.Add(new Product("Кола", 78, 5));
        products.Add(new Product("Кола без сахара", 78, 5));
        products.Add(new Product("Вода", 50, 10));
        products.Add(new Product("Чипсы Lays с паприкой", 120, 3));
        products.Add(new Product("Milka молочная", 109, 4));
        products.Add(new Product("Мармелад Chupa Chups", 128, 6));
        products.Add(new Product("Цезарь ролл", 275, 2));
        products.Add(new Product("M&M", 92, 5));
    }


    public void ShowProducts()
    {
        Console.WriteLine("\nСписок товаров:");
        for (int i = 0; i < products.Count; i++)
        {
            var p = products[i];
            Console.WriteLine($"{i + 1}. {p.Name} - {p.Price} руб. (осталось {p.Quantity})");
        }
        Console.WriteLine($"Ваш баланс: {balance} руб.\n");
    }

    public void InsertCoin(int coin)
    {
        if (coin <= 0)
        {
            Console.WriteLine("Неверный номинал!");
            return;
        }

        balance += coin;
        Console.WriteLine($"Баланс: {balance} руб.");
    }

    public void BuyProduct(int index)
    {
        if (index < 1 || index > products.Count)
        {
            Console.WriteLine("Такого товара нет.");
            return;
        }

        var p = products[index - 1];

        if (p.Quantity == 0)
        {
            Console.WriteLine("Товара нет в наличии.");
            return;
        }

        if (balance >= p.Price)
        {
            balance -= p.Price;
            collectedMoney += p.Price;
            p.Buy();
            Console.WriteLine($"Вы купили {p.Name}. Остаток: {balance} руб.");
        }
        else
        {
            Console.WriteLine($"Недостаточно средств! Нужно ещё {p.Price - balance} руб.");
        }
    }

    public void ReturnCoins()
    {
        if (balance == 0)
        {
            Console.WriteLine("Нет денег для возврата.");
            return;
        }

        Console.WriteLine("\nВозврат сдачи:");

        int remaining = balance;
        Dictionary<int, int> coinsToReturn = new();

        // Жадный метод — выдаём по номиналам от больших к малым
        foreach (int coin in coinDenominations)
        {
            int count = remaining / coin;
            if (count > 0)
            {
                coinsToReturn[coin] = count;
                remaining -= coin * count;
            }
        }

        // Выводим сдачу
        foreach (var kvp in coinsToReturn)
        {
            Console.WriteLine($"{kvp.Key} руб.: {kvp.Value} шт.");
        }

        // Остаток — нестандартные монеты
        if (remaining > 0)
        {
            Console.WriteLine($"Нестандартные монеты (не делятся на стандартные номиналы): {remaining} руб.");
        }

        balance = 0; // сброс баланса после возврата
    }

    public void EnterAdminMode()
    {
        Console.Write("Введите пароль администратора: ");
        string pass = Console.ReadLine() ?? "";
        if (pass != "admin")
        {
            Console.WriteLine("Неверный пароль.");
            return;
        }

        while (true)
        {
            Console.WriteLine("\n--- Админ-меню ---");
            Console.WriteLine("1 - Пополнить товар");
            Console.WriteLine("2 - Просмотр/снятие собранных средств");
            Console.WriteLine("0 - Выйти");
            Console.Write("Выберите действие: ");

            string cmd = Console.ReadLine() ?? "";

            if (cmd == "0") break;

            if (cmd == "1")
            {
                ShowProducts();
                Console.Write("Номер товара для пополнения: ");
                if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= products.Count)
                {
                    Console.Write("Количество для добавления: ");
                    if (int.TryParse(Console.ReadLine(), out int qty) && qty > 0)
                    {
                        products[idx - 1].Refill(qty);
                        Console.WriteLine("Товар пополнен.");
                    }
                    else
                    {
                        Console.WriteLine("Неверное количество.");
                    }
                }
                else
                {
                    Console.WriteLine("Неверный выбор.");
                }
            }
            else if (cmd == "2")
            {
                Console.WriteLine($"Собрано всего: {collectedMoney} руб.");
                Console.Write("Снять собранные средства? (y/n): ");
                string answer = Console.ReadLine() ?? "";
                if (answer.Trim().ToLower() == "y")
                {
                    Console.WriteLine($"Снято {collectedMoney} руб.");
                    collectedMoney = 0;
                }
            }
            else
            {
                Console.WriteLine("Неизвестная команда.");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        VendingMachine vm = new();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1 - Показать товары");
            Console.WriteLine("2 - Вставить монету");
            Console.WriteLine("3 - Купить товар");
            Console.WriteLine("4 - Вернуть сдачу");
            Console.WriteLine("5 - Выйти");
            Console.WriteLine("6 - Админ-режим");
            Console.Write("> ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    vm.ShowProducts();
                    break;
                case "2":
                    Console.Write("Введите номинал монеты: ");
                    if (int.TryParse(Console.ReadLine(), out int coin))
                        vm.InsertCoin(coin);
                    else
                        Console.WriteLine("Ошибка: введите число.");
                    break;
                case "3":
                    vm.ShowProducts();
                    Console.Write("Выберите номер товара: ");
                    if (int.TryParse(Console.ReadLine(), out int num))
                        vm.BuyProduct(num);
                    else
                        Console.WriteLine("Ошибка: введите число.");
                    break;
                case "4":
                    vm.ReturnCoins();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("До свидания!");
                    break;
                case "6":
                    vm.EnterAdminMode();
                    break;
                default:
                    Console.WriteLine("Неизвестная команда.");
                    break;
            }
        }
    }
}


