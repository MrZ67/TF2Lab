using System.Collections.Generic;

namespace TF2Logic
{
    /// <summary>
    /// Класс бизнес-логики. Хранит список наёмников и предоставляет методы
    /// для работы с ними: создание, удаление, чтение, изменение и поиск.
    /// </summary>
    public class Logic
    {
        /// <summary>
        /// Внутренний список всех наёмников.
        /// </summary>
        private List<Mercenary> roster = new List<Mercenary>();

        /// <summary>
        /// Счётчик для выдачи уникальных идентификаторов новым наёмникам.
        /// </summary>
        private int idCounter = 1;

        /// <summary>
        /// Создаёт нового наёмника и добавляет его в список.
        /// Если имя или роль пустые, либо HP отрицательное — возвращает false.
        /// </summary>
        /// <param name="name">Имя наёмника.</param>
        /// <param name="primary">Основное оружие.</param>
        /// <param name="secondary">Второстепенное оружие.</param>
        /// <param name="melee">Оружие ближнего боя.</param>
        /// <param name="hp">Здоровье наёмника.</param>
        /// <param name="role">Роль наёмника.</param>
        /// <returns>true — если наёмник создан; false — если данные некорректны.</returns>
        public bool CreateMerc(string name, string primary, string secondary, string melee, int hp, string role)
        {
            if (name == "" || role == "")
            {
                return false;
            }
            if (hp < 0)
            {
                return false;
            }
            if (primary == "") primary = "Нет";
            if (secondary == "") secondary = "Нет";
            if (melee == "") melee = "Нет";
            Mercenary newMerc = new Mercenary(idCounter, name, primary, secondary, melee, hp, role);
            idCounter++;
            roster.Add(newMerc);
            return true;
        }

        /// <summary>
        /// Удаляет наёмника с указанным идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор наёмника.</param>
        /// <returns>true — если наёмник найден и удалён; иначе false.</returns>
        public bool DeleteMerc(int id)
        {
            for (int i = 0; i < roster.Count; i++)
            {
                if (roster[i].Id == id)
                {
                    roster.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Возвращает копию списка всех наёмников.
        /// </summary>
        /// <returns>Список объектов <see cref="Mercenary"/>.</returns>
        public List<Mercenary> ReadAll()
        {
            return new List<Mercenary>(roster);
        }

        /// <summary>
        /// Находит наёмника по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор наёмника.</param>
        /// <returns>Объект <see cref="Mercenary"/>, либо null, если наёмник не найден.</returns>
        public Mercenary GetMercById(int id)
        {
            for (int i = 0; i < roster.Count; i++)
            {
                if (roster[i].Id == id)
                {
                    return roster[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Обновляет данные существующего наёмника.
        /// Если имя или роль пустые, либо HP отрицательное — возвращает false.
        /// </summary>
        /// <param name="id">Идентификатор наёмника для обновления.</param>
        /// <param name="name">Новое имя.</param>
        /// <param name="primary">Новое основное оружие.</param>
        /// <param name="secondary">Новое второстепенное оружие.</param>
        /// <param name="melee">Новое оружие ближнего боя.</param>
        /// <param name="hp">Новое значение здоровья.</param>
        /// <param name="role">Новая роль.</param>
        /// <returns>true — если обновление выполнено; иначе false.</returns>
        public bool UpdateMerc(int id, string name, string primary, string secondary, string melee, int hp, string role)
        {
            if (name == "" || role == "")
            {
                return false;
            }
            if (hp < 0)
            {
                return false;
            }
            if (primary == "") primary = "Нет";
            if (secondary == "") secondary = "Нет";
            if (melee == "") melee = "Нет";
            for (int i = 0; i < roster.Count; i++)
            {
                if (roster[i].Id == id)
                {
                    roster.RemoveAt(i);
                    Mercenary updated = new Mercenary(id, name, primary, secondary, melee, hp, role);
                    roster.Add(updated);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Формирует текстовый отчёт о наёмниках, сгруппированных по ролям.
        /// </summary>
        /// <returns>Список строк с заголовками ролей и перечнем наёмников.</returns>
        public List<string> GetRolesReport()
        {
            List<string> report = new List<string>();
            List<string> uniqueRoles = new List<string>();
            foreach (Mercenary m in roster)
            {
                bool alreadyHave = false;
                foreach (string r in uniqueRoles)
                {
                    if (r == m.Role)
                    {
                        alreadyHave = true;
                    }
                }
                if (alreadyHave == false)
                {
                    uniqueRoles.Add(m.Role);
                }
            }
            foreach (string role in uniqueRoles)
            {
                report.Add("--- Роль: " + role + " ---");
                foreach (Mercenary m in roster)
                {
                    if (m.Role == role)
                    {
                        report.Add("   " + m.Name + " (HP: " + m.Health + ")");
                    }
                }
                report.Add("");
            }
            return report;
        }

        /// <summary>
        /// Ищет наёмников, у которых встречается указанная подстрока.
        /// </summary>
        /// <param name="weaponName">Часть названия оружия для поиска.</param>
        /// <returns>Список наёмников, у которых найдено совпадение.</returns>
        public List<Mercenary> FindByWeapon(string weaponName)
        {
            List<Mercenary> found = new List<Mercenary>();
            string search = weaponName.ToLower();
            foreach (Mercenary m in roster)
            {
                string p = m.PrimaryWeapon.ToLower();
                if (p.Contains(search))
                {
                    found.Add(m);
                }
            }
            return found;
        }
    }
}