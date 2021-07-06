using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_FinalProject
{
    public class MenuRepository
    {
        protected readonly List<Menu> _menu = new List<Menu>();

        public MenuRepository() { }

        public bool AddMenuItem(Menu item)
        {
            int count = _menu.Count;
            _menu.Add(item);
            return count < _menu.Count;
        }
        public List<Menu> GetMenu()
        {
            return _menu;
        }
        public bool DeleteItem(Menu item)
        {
            return _menu.Remove(item);
        }
        
    }
}
