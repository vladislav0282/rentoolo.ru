﻿using System;
using System.Collections.Generic;
using System.Linq;
using Chat.Dal.Dto;

namespace Chat.Dal.IntegrationTests.Dto
{
    public static class TestObjectBuilder
    {
        public static Chat.Dal.Dto.Room CreateRoom()
        {
            var res = new Room()
            {
                CreatedTime = new DateTime(2019, 8, 3),
                Name = "asp.net",
                Softdelete = false,
                
            };
            return res;
        }

        public static T Update<T>(T srcInstance, int salt = 0)
        {
            T instance = (T)Activator.CreateInstance(typeof(T));

            var props = typeof(T).GetProperties();
            foreach (var propertyInfo in props)
            {
                if (propertyInfo.Name.ToLowerInvariant() == "id")
                {
                    // do not change id
                    var value = propertyInfo.GetValue(srcInstance);
                    propertyInfo.SetValue(instance, value, null);
                }
                else if (propertyInfo.PropertyType == typeof(string))
                {
                    var value = (string)propertyInfo.GetValue(srcInstance) + salt;
                    propertyInfo.SetValue(instance, value, null);
                }
                else if (propertyInfo.PropertyType == typeof(int))
                {
                    var value = (int)propertyInfo.GetValue(srcInstance) + salt;
                    propertyInfo.SetValue(instance, value, null);
                }
                else if (propertyInfo.PropertyType == typeof(DateTime))
                {
                    var value = ((DateTime) propertyInfo.GetValue(srcInstance)).AddSeconds(-1d * salt);
                    propertyInfo.SetValue(instance, value, null);
                }
                else if (propertyInfo.PropertyType == typeof(DateTimeOffset))
                {
                    var value = ((DateTimeOffset) propertyInfo.GetValue(srcInstance)).AddSeconds(-1d * salt);
                    propertyInfo.SetValue(instance, value, null);
                }
            }

            return instance;
        }

        public static T Create<T>(int salt = 0)
        {
            T instance = (T)Activator.CreateInstance(typeof(T));

            var props = typeof(T).GetProperties();
            foreach (var propertyInfo in props)
            {
                if (propertyInfo.Name.ToLowerInvariant() == "id")
                {
                    continue; //id should be generated by db
                }
                else if (propertyInfo.PropertyType == typeof(string))
                {
                    var value = propertyInfo.Name + salt;
                    propertyInfo.SetValue(instance, value, null);
                }
                else if (propertyInfo.PropertyType == typeof(int))
                {
                    var value = 100500 + salt;
                    propertyInfo.SetValue(instance, value, null);
                }
                else if (propertyInfo.PropertyType == typeof(DateTime))
                {
                    var value = DateTime.UtcNow.AddSeconds(-1d * salt);
                    propertyInfo.SetValue(instance, value, null);
                }
                else if (propertyInfo.PropertyType == typeof(DateTimeOffset))
                {
                    var value = DateTimeOffset.UtcNow.AddSeconds(-1d * salt);
                    propertyInfo.SetValue(instance, value, null);
                }
            }

            return instance;
        }

        public static IEnumerable<T> CreateMany<T>(int count)
        {
            var rangeList = Enumerable.Range(0, count).ToList();
            var result = rangeList.Select(x => Create<T>(x));
            return result;
        }

        public static IEnumerable<T> UpdateMany<T>(int salt, params T[] srcInstance)
        {
            var result = srcInstance.Select(x => Update<T>(x));
            return result;
        }
    }
}