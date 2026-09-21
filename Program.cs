using System;
using System.Collections.Generic;
using TF2Logic;

namespace TF2Console
{
    /// <summary>
    /// Консольное представление программы: меню и работа с пользователем.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Точка входа в консольное приложение.
        /// Показывает меню и обрабатывает выбор пользователя.
        /// </summary>
        /// <param name="args">Аргументы командной строки (не используются).</param>
        static void Main(string[] args)
        {
            Logic logic = new Logic();

            logic.CreateMerc("Солдат", "Ракетница", "Дробовик", "Лопака", 200, "Атака");
            logic.CreateMerc("Медик", "Арбалет крестоносца", "Лечебная пушка", "Убер-пила", 150, "Поддержка");
            logic.CreateMerc("Хэви", "Миниган", "Бутерброд", "Горящие рукавицы ускорения", 300, "Оборона");

            string choice = "";

            do
            {
                Console.Clear();
                Console.WriteLine("=== TF2: Профиль 10-го класса ===");
                Console.WriteLine("1. Показать всех");
                Console.WriteLine("2. Нанять бойца");
                Console.WriteLine("3. Уволить бойца");
                Console.WriteLine("4. Переписать бойца");
                Console.WriteLine("5. Отчёт по ролям");
                Console.WriteLine("6. Поиск по оружию");
                Console.WriteLine("0. Выход");
                Console.Write("Выбери пункт: ");

                choice = Console.ReadLine();

                if (choice == "1")
                {
                    try
                    {
                        List<Mercenary> all = logic.ReadAll();
                        if (all.Count == 0)
                        {
                            Console.WriteLine("Пусто.");
                        }
                        foreach (Mercenary m in all)
                        {
                            Console.WriteLine(m.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка: " + ex.Message);
                    }
                    Pause();
                }
                else if (choice == "2")
                {
                    try
                    {
                        Console.Write("Имя: ");
                        string name = Console.ReadLine();
                        if (name == "")
                        {
                            Console.WriteLine("Имя не может быть пустым!");
                            Pause();
                            continue;
                        }

                        Console.Write("Основное оружие: ");
                        string prim = Console.ReadLine();
                        Console.Write("Второстепенное: ");
                        string sec = Console.ReadLine();
                        Console.Write("Ближний бой: ");
                        string mel = Console.ReadLine();

                        Console.Write("Здоровье: ");
                        int hp;
                        while (int.TryParse(Console.ReadLine(), out hp) == false)
                        {
                            Console.Write("Цифру давай: ");
                        }

                        if (hp < 0)
                        {
                            Console.WriteLine("HP не может быть отрицательным!");
                            Pause();
                            continue;
                        }

                        Console.Write("Роль: ");
                        string role = Console.ReadLine();
                        if (role == "")
                        {
                            Console.WriteLine("Роль не может быть пустой!");
                            Pause();
                            continue;
                        }

                        bool ok = logic.CreateMerc(name, prim, sec, mel, hp, role);
                        if (ok == true)
                        {
                            Console.WriteLine("Наняли!");
                        }
                        else
                        {
                            Console.WriteLine("Не получилось. Проверь имя, роль и HP.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка: " + ex.Message);
                    }
                    Pause();
                }
                else if (choice == "3")
                {
                    try
                    {
                        Console.Write("ID бойца на увольнение: ");
                        int id;
                        if (int.TryParse(Console.ReadLine(), out id) == false)
                        {
                            Console.WriteLine("ID должно быть числом!");
                            Pause();
                            continue;
                        }

                        bool ok = logic.DeleteMerc(id);
                        if (ok == true) Console.WriteLine("Уволен.");
                        else Console.WriteLine("Нет такого ID.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка: " + ex.Message);
                    }
                    Pause();
                }
                else if (choice == "4")
                {
                    try
                    {
                        Console.Write("ID для правки: ");
                        int id;
                        if (int.TryParse(Console.ReadLine(), out id) == false)
                        {
                            Console.WriteLine("ID должно быть числом!");
                            Pause();
                            continue;
                        }

                        Console.Write("Новое имя: ");
                        string name = Console.ReadLine();
                        if (name == "")
                        {
                            Console.WriteLine("Имя не может быть пустым!");
                            Pause();
                            continue;
                        }

                        Console.Write("Новое основное: ");
                        string prim = Console.ReadLine();
                        Console.Write("Новое второстепенное: ");
                        string sec = Console.ReadLine();
                        Console.Write("Новый ближний бой: ");
                        string mel = Console.ReadLine();

                        Console.Write("Новое HP: ");
                        int hp;
                        while (int.TryParse(Console.ReadLine(), out hp) == false)
                        {
                            Console.Write("Цифру давай: ");
                        }

                        if (hp < 0)
                        {
                            Console.WriteLine("HP не может быть отрицательным!");
                            Pause();
                            continue;
                        }

                        Console.Write("Новая роль: ");
                        string role = Console.ReadLine();
                        if (role == "")
                        {
                            Console.WriteLine("Роль не может быть пустой!");
                            Pause();
                            continue;
                        }

                        bool ok = logic.UpdateMerc(id, name, prim, sec, mel, hp, role);
                        if (ok == true) Console.WriteLine("Обновлено.");
                        else Console.WriteLine("Не нашли или плохие данные.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка: " + ex.Message);
                    }
                    Pause();
                }
                else if (choice == "5")
                {
                    try
                    {
                        List<string> report = logic.GetRolesReport();
                        if (report.Count == 0)
                        {
                            Console.WriteLine("Список бойцов пуст.");
                        }
                        foreach (string line in report)
                        {
                            Console.WriteLine(line);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка: " + ex.Message);
                    }
                    Pause();
                }
                else if (choice == "6")
                {
                    try
                    {
                        Console.Write("Введи название пушки (частично): ");
                        string search = Console.ReadLine();
                        if (search == "")
                        {
                            Console.WriteLine("Пустой запрос!");
                            Pause();
                            continue;
                        }

                        List<Mercenary> found = logic.FindByWeapon(search);

                        if (found.Count == 0)
                        {
                            Console.WriteLine("Ничего не найдено.");
                        }
                        else
                        {
                            foreach (Mercenary m in found)
                            {
                                Console.WriteLine(m.ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка: " + ex.Message);
                    }
                    Pause();
                }

            } while (choice != "0");
        }

        /// <summary>
        /// Приостанавливает выполнение программы до нажатия Enter.
        /// Используется, чтобы пользователь успел прочитать вывод на экране.
        /// </summary>
        static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Нажми Enter...");
            Console.ReadLine();
        }
    }
}