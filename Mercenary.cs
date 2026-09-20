using System;

namespace TF2Logic
{
    public class Mercenary
    {
        private int id;
        private string name;
        private string primaryWeapon;
        private string secondaryWeapon;
        private string meleeWeapon;
        private int health;
        private string role;

        public int Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
        }

        public string PrimaryWeapon
        {
            get { return primaryWeapon; }
        }

        public string SecondaryWeapon
        {
            get { return secondaryWeapon; }
        }

        public string MeleeWeapon
        {
            get { return meleeWeapon; }
        }

        public int Health
        {
            get { return health; }
        }

        public string Role
        {
            get { return role; }
        }

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

        public override string ToString()
        {
            return "[" + Id + "] " + Name + " | HP: " + Health + " | Роль: " + Role + " | Стволы: " + PrimaryWeapon + " / " + SecondaryWeapon + " / " + MeleeWeapon;
        }
    }
}