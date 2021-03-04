namespace simaira_backend_playground.Recursive
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Menu
    {
        public static void Start()
        {
            IList<CheckMenuItem> cacheData = new List<CheckMenuItem>();
            IList<CheckMenuItem> menus = new List<CheckMenuItem>(); ;

            menus.Add(new CheckMenuItem { Id = 1, Modifiers = new List<CheckMenuItem>() });
            menus.Add(new CheckMenuItem { Id = 2, Modifiers = new List<CheckMenuItem>() });
            menus.Add(new CheckMenuItem { Id = 4, Modifiers = new List<CheckMenuItem>() });
            menus[1].Modifiers.Add(new CheckMenuItem { Id = 7, Modifiers = new List<CheckMenuItem>() });
            menus[1].Modifiers.Add(new CheckMenuItem { Id = 8, Modifiers = new List<CheckMenuItem>() });
            menus[1].Modifiers[1].Modifiers.Add(new CheckMenuItem { Id = 11, Modifiers = new List<CheckMenuItem>() });
            menus[2].Modifiers.Add(new CheckMenuItem { Id = 17, Modifiers = new List<CheckMenuItem>() });
            IList<long> menuIds = new List<long>();
            PrepareMenusForProcess(menus, menuIds);
            var filter = cacheData?.Where(menu => menuIds.Any(id => menu.Id == id));
        }

        public static void PrepareMenusForProcess(IEnumerable<CheckMenuItem> menus, IList<long> menuIds)
        {
            foreach (var menu in menus)
            {
                if (!menuIds.Contains(menu.Id))
                {
                    menuIds.Add(menu.Id);
                }
                if (menu.Modifiers != null && menu.Modifiers.Any())
                {
                    PrepareMenusForProcess(menu.Modifiers, menuIds);
                }
            }
        }
    }

    public class CheckMenuItem
    {
        public long Id { get; set; }

        public IList<CheckMenuItem> Modifiers
        {
            get; set;
        }
    }
}
