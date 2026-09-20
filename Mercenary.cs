using System;

namespace TF2Logic
{
    /// <summary>
    /// Класс, описывающий наёмника.
    /// Хранит идентификатор, имя, три вида оружия, здоровье и роль.
    /// </summary>
    public class Mercenary
    {
        /// <summary>
        /// Уникальный идентификатор наёмника.
        /// </summary>
        private int id;

        /// <summary>
        /// Имя наёмника.
        /// </summary>
        private string name;

        /// <summary>
        /// Основное оружие наёмника.
        /// </summary>
        private string primaryWeapon;

        /// <summary>
        /// Второстепенное оружие наёмника.
        /// </summary>
        private string secondaryWeapon;

        /// <summary>
        /// Оружие ближнего боя наёмника.
        /// </summary>
        private string meleeWeapon;

        /// <summary>
        /// Здоровье наёмника (HP).
        /// </summary>
        private int health;

        /// <summary>
        /// Роль наёмника (например, Атака, Защита, Поддержка).
        /// </summary>
        private string role;

        /// <summary>
        /// Уникальный идентификатор наёмника. Доступен только для чтения.
        /// </summary>
        public int Id
        {
            get { return id; }
        }

        /// <summary>
        /// Имя наёмника. Доступно только для чтения.
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// Основное оружие наёмника. Доступно только для чтения.
        /// </summary>
        public string PrimaryWeapon
        {
            get { return primaryWeapon; }
        }

        /// <summary>
        /// Второстепенное оружие наёмника. Доступно только для чтения.
        /// </summary>
        public string SecondaryWeapon
        {
            get { return secondaryWeapon; }
        }

        /// <summary>
        /// Оружие ближнего боя наёмника. Доступно только для чтения.
        /// </summary>
        public string MeleeWeapon
        {
            get { return meleeWeapon; }
        }

        /// <summary>
        /// Здоровье наёмника. Доступно только для чтения.
        /// </summary>
        public int Health
        {
            get { return health; }
        }

        /// <summary>
        /// Роль наёмника. Доступна только для чтения.
        /// </summary>
        public string Role
        {
            get { return role; }
        }

        /// <summary>
        /// Создаёт нового наёмника с заданными параметрами.
        /// </summary>
        /// <param name="id">Уникальный идентификатор наёмника.</param>
        /// <param name="name">Имя наёмника.</param>
        /// <param name="primary">Название основного оружия.</param>
        /// <param name="secondary">Название второстепенного оружия.</param>
        /// <param name="melee">Название оружия ближнего боя.</param>
        /// <param name="hp">Здоровье наёмника.</param>
        /// <param name="role">Роль наёмника.</param>
        public Mercenary(int id, string name, string primary, string secondary, string melee, int hp, string role)
        {
            this.id = id;
            this.name = name;
            this.primaryWeapon = primary;
            this.secondaryWeapon = secondary;
            this.meleeWeapon = melee;
            this.health = hp;
            this.role = role;
        }

        /// <summary>
        /// Возвращает строковое представление наёмника для вывода в консоль или таблицу.
        /// </summary>
        /// <returns>Строка с ID, именем, здоровьем, ролью и оружием.</returns>
        public override string ToString()
        {
            return "[" + Id + "] " + Name + " | HP: " + Health + " | Роль: " + Role + " | Стволы: " + PrimaryWeapon + " / " + SecondaryWeapon + " / " + MeleeWeapon;
        }
    }
}