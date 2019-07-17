using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebAPI2Aurimas.Infrastructure;

namespace Db
{
    public class DbManager
    {
        //private readonly List<Hug> _hugs = new List<Hug>(); //Tas pats kaip konstruktorius be parametru, readonly tik vienakart priskirtas objektas
        private static List<Hug> _hugs = new List<Hug>();
        static DbManager()
        {
            _hugs.Add(new Hug { Id = 1, From = "H", To = "B", Reason = "Reason 1", Created = DateTime.Now });
            _hugs.Add(new Hug { Id = 2, From = "E", To = "T", Reason = "Reason 2", Created = DateTime.Now });
            _hugs.Add(new Hug { Id = 3, From = "F", To = "J", Reason = "Reason 3", Created = DateTime.Now });
            _hugs.Add(new Hug { Id = 4, From = "S", To = "S", Reason = "Reason 4", Created = DateTime.Now });
        }

        private readonly IMyLogger _logger;

        public DbManager(IMyLogger logger)
        {
            _logger = logger;
        }

        public List<Hug> GetHugs()
        {
            var logger = new DebugLogger();
            logger.Log("Put started");
            return _hugs;
        }

        public void DeleteHug(int id)
        {
            var itemToRemove = _hugs.Single(h => h.Id == id);
            _hugs.Remove(itemToRemove);
        }

        public void InsertHug(Hug model)
        {
            _hugs.Add(model);
        }

        public void UpdateHug(Hug model)
        {
            var itemToUpdate = _hugs.Single(h => h.Id == model.Id);
            itemToUpdate.Id = model.Id;
            itemToUpdate.From = model.From;
            itemToUpdate.To = model.To;
            itemToUpdate.Reason = model.Reason;
            itemToUpdate.Created = model.Created;
        }
        /*
        public static bool CheckNullOrEmpty<T>(T value)
       {
           if (typeof(T) == typeof(string))
               return string.IsNullOrEmpty(value as string);

           return value == null || value.Equals(default(T));
       }

        public void SemiUpdateHug(Hug semimodel)
        {
            PropertyInfo[] properties = semimodel.GetType().GetProperties();
            for (int i = 0; i < properties.Length - 1; i++)
            {
                if (properties[i] != null)
                {
                    var itemToUpdate = _hugs.Single(h => h.Id == semimodel.Id);
                    itemToUpdate.GetType().GetProperty(properties[i]).GetValue(itemToUpdate, null) = semimodel.element;
                    
                }
            }
            
        }
        */


    }
}
