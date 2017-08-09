using RealmdigitalInterview.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RealmdigitalInterview.Core.Implementations
{
    public class MoqRepo : IRepoService
    {
        private static List<object> moqCollection = new List<object>();

        private T InstanceMap<T>(object parameters)
        {
            if (parameters != null)
            {
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
            return default(T);
        }

        private object FindById<T>(object id)
        {
            var subCollection = moqCollection.OfType<T>().ToList();

            var firstProperty = id.GetType().GetProperties().First();
            var idName = firstProperty.Name;
            var idValue = firstProperty.GetValue(id);
            if (subCollection != null && subCollection.Count > 0)
            {
                var item = subCollection.Single(x => x.GetType().GetProperty(idName).GetValue(x).ToString() == idValue.ToString());
                return item;
            }
            return null;
        }

        public T Add<T>(string command, object parameters)
        {
            T instance = InstanceMap<T>(parameters);

            //assume first parameter will always be the primary key and is always an int.
            //assign incremented primary key
            try
            {
                instance.GetType().GetProperties()[0].SetValue(instance, moqCollection.Count + 1);
            }
            catch (Exception)
            {
                throw;
            }

            moqCollection.Add(instance);
            return instance;
        }

        public T Delete<T>(string command, object id)
        {
            var item = FindById<T>(id);
            var index = moqCollection.IndexOf(item);
            if (index >= 0)
            {
                moqCollection.RemoveAt(index);
            }
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
            var item = FindById<T>(id);
            T instance = InstanceMap<T>(item);

            return instance;
        }

        public List<T> GetCollection<T>(string command)
        {
            return moqCollection.OfType<T>().ToList();
        }

        public List<T> GetCollection<T>(string command, object filters)
        {
            var result = new List<T>();
            var subCollection = moqCollection.OfType<T>().ToList();

            var filterProps = filters.GetType().GetProperties();

            foreach (var filterProp in filterProps)
            {
                var filterName = filterProp.Name;
                var filterValue = filterProp.GetValue(filters);

                foreach (var item in subCollection)
                {
                    foreach (var prop in item.GetType().GetProperties())
                    {
                        var propName = prop.Name;
                        var propValue = prop.GetValue(item);

                        if (filterName.ToString() == propName.ToString())
                        {
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
