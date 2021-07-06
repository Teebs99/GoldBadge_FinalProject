using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOutings
{
    public class OutingRepo
    {
        protected readonly List<Outing> _repo = new List<Outing>();

        public bool AddOuting(Outing outing)
        {
            int count = _repo.Count;
            _repo.Add(outing);
            return count < _repo.Count;
        }
        public List<Outing> GetOutings()
        {
            return _repo;
        }
        public bool UpdateOuting(Outing oldOuting, Outing newOuting)
        {
            for(int i = 0; i < _repo.Count; i++)
            {
                if(_repo[i] == oldOuting)
                {
                    _repo[i] = newOuting;
                    return true;
                }
            }
            return false;
        }
        public bool DeleteOuting(Outing outing)
        {
            return _repo.Remove(outing);
        }
    }
}
