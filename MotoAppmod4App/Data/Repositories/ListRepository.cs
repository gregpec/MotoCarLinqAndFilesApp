﻿namespace MotoAppmod4App.Data.Repositories

{
    using Microsoft.Extensions.DependencyInjection;
    using MotoAppmod4App.Data;
    using System.Security.Principal;
    using MotoAppmod4App.Data.Entities;

    public class ListRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly List<T> _items = new();
        public IEnumerable<T> GetAll()
        {
            return _items.ToList();
        }
        public T GetById(int id)
        {
            // return default(T);
            return _items.Single(item => item.Id == id); // wyrazenie lambda z parametrem item i zapytaniem item.Id = id  /////// () => operator
        }

        public void Add(T item)
        {
            // item.Id = _items.Count + 1;  // ID ograniczenia
            item.Id = _items.Count + 1;  // ID ograniczenia nieokreslony Is z innej klasy albo interdesu  
            _items.Add(item);

            // w tym miejscu zapisujemy fane do listy
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }


        public void Save()
        {
            //   foreach (var item in _items)
            //  {
            //     Console.WriteLine(item.ToString()); // uzycie przeslonietej metody tostring

            // wyrzucenie drukowania wartosci na ekran w listach tego nie potrzebujemy
            // zapisujemy w Add
        }
    }



}


