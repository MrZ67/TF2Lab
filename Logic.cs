using System.Collections.Generic;

namespace TF2Logic
{
    public class Logic
    {
        private List<Mercenary> roster = new List<Mercenary>();
        private int idCounter = 1;

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

        public List<Mercenary> ReadAll()
        {
            return new List<Mercenary>(roster);
        }

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

        public List<Mercenary> FindByWeapon(string weaponName)
        {
            List<Mercenary> found = new List<Mercenary>();
            string search = weaponName.ToLower();

            foreach (Mercenary m in roster)
            {
                string p = m.PrimaryWeapon.ToLower();
                string s = m.SecondaryWeapon.ToLower();
                string ml = m.MeleeWeapon.ToLower();

                if (p.Contains(search) || s.Contains(search) || ml.Contains(search))
                {
                    found.Add(m);
                }
            }

            return found;
        }
    }
}