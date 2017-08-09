using RealmdigitalInterview.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RealmdigitalInterview.Core.Implementations
{
    public class MoqRepo : IRepoService
    {
        private List<object> moqCollection = new List<object>();

        private T InstanceMap<T>(object parameters) {
            var properties = typeof(T).GetProperties();
            T instance = Activator.CreateInstance<T>();
            foreach (var property in properties)
            {
                var name = property.Name;
                var parName = parameters.GetType().GetProperty(name);
                if (parName != null)
                {
                    var value = parName.GetValue(parameters, null);

                    property.SetValue(instance, value, null);
                }
            }            
            return instance;
        }

        private object FindById(object id) {
            var firstProperty = id.GetType().GetProperties().First();
            var idName = firstProperty.Name;
            var idValue = firstProperty.GetValue(id);
            var item = moqCollection.Single(x => x.GetType().GetProperty(idName).GetValue(x).ToString() == idValue.ToString());
            return item;
        }

        public T Add<T>(string command, object parameters)
        {
            T instance = InstanceMap<T>(parameters);
            moqCollection.Add(instance);
            return instance;
        }

        public T Delete<T>(string command, object id)
        {
            var item = FindById(id);
            var index = moqCollection.IndexOf(item);
            moqCollection.RemoveAt(index);
            T instance = InstanceMap<T>(item);
            return instance;
        }

        public T Edit<T>(string command, object parameters)
        {
            T instance = InstanceMap<T>(parameters);
            return instance;
        }

        public T GetModel<T>(string command, object id)
        {
            var item = FindById(id);
            T instance = InstanceMap<T>(item);

            return instance;
        }

        public List<T> GetCollection<T>(string command)
        {
            return moqCollection.Cast<T>().ToList();
        }

        public List<T> GetCollection<T>(string command, object filters)
        {
            var result = new List<T>();

            var filterProps = filters.GetType().GetProperties();

            foreach (var filterProp in filterProps)
            {
                var filterName = filterProp.Name;
                var filterValue = filterProp.GetValue(filters);
                
                foreach (var item in moqCollection)
                {
                    foreach (var prop in item.GetType().GetProperties())
                    {
                        var propName = prop.Name;
                        var propValue = prop.GetValue(item);

                        if (filterName.ToString() == propName.ToString()) {
                            if (filterValue.ToString() == propValue.ToString())
                            {
                                T instance = InstanceMap<T>(item);
                                result.Add(instance);
                            }
                        }
                    }
                }
            }
            
            return result;
        }
    }
}
