using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    public class BadgeRepo
    {
        protected readonly Dictionary<int, List<string>> _badges = new Dictionary<int, List<string>>();

        public bool AddBadge(Badge badge)
        {
            int count = _badges.Count;
            _badges.Add(badge.BadgeId, badge.Doors);
            return count < _badges.Count;
        }
        public bool AddDoor(int id,string door)
        {
            if (_badges.ContainsKey(id))
            {
                _badges[id].Add(door);
                return true;
            }
            return false;
        }
        public Dictionary<int, List<string>> GetBadges()
        {
            Dictionary<int, List<string>> newDict = new Dictionary<int, List<string>>();
            foreach(KeyValuePair<int,List<string>> entry in _badges){
                newDict.Add(entry.Key, entry.Value);
            }
            return newDict;
        }
        public bool UpdateDoor(int id, string oldDoor, string newDoor)
        {
            foreach(string door in _badges[id])
            {
                if(door == oldDoor)
                {
                    oldDoor = newDoor;
                    return true;
                }
            }
            return false;
        }
        public bool DeleteDoor(int id, string door)
        {
            if(_badges.ContainsKey(id) & _badges[id].Contains(door))
            {
                _badges[id].Remove(door);
                return true;
            }
            return false;
        }
        public bool DeleteAllDoors(int id)
        {
            if (_badges.ContainsKey(id))
            {
                while(_badges[id].Count > 0)
                {
                    _badges[id].RemoveAt(0);
                }
                return true;
            }
            return false;
        }

    }
}
