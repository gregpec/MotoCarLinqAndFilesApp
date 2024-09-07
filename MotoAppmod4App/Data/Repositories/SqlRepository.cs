
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MotoAppmod4App.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using MotoAppmod4App.Data.Entities;
using System.Runtime.CompilerServices;
using System.Security.Principal;



//public class SqlRepository // zblizone do klas generycznych


//dodanie delegatu
//public delegate void ItemAdded(object item);


//dodanie generycznosci


//usuniecie delegatu wprowadZnienie delegatu Actiomn zaimplementowanego w Bibotece dot Net
//public delegate void ItemAdded<in T>(T item);


public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
{
    private readonly DbSet<T> _dbSet;
    private readonly DbContext _dbContext;
    private readonly Action<T>? _itemAddedCallback; // delegat generyczny


    //zmienna prywatna

    //private readonly ItemAdded? _itemAddedCallback; // delegat callback 


    //private readonly ItemAdded<T>? _itemAddedCallback; // delegat generyczny




    //public SqlRepository(DbContext dbContext, ItemAdded? itemAddedCallback = null)



    public SqlRepository(DbContext dbContext, Action<T>? itemAddedCallback = null)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();

        //
        //dodanie linijki
        _itemAddedCallback = itemAddedCallback;
        // przepisanie callbacka do zmiennej 
    }


    //dodanie eventu handlera

    public event EventHandler<T> ItemAdded;

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
        // return _dbSet.OrderBy(item => item.Id).ToList();

        // posortowanie
    }


    public T? GetById(int id)
    {
        return _dbSet.Find(id);
        // db Set udostepnia Find



    }

    public void Add(T item)
    {
        _dbSet.Add(item);

        // z użyciem metody Invoke delegat z callbackiem call back delegat zwracajacy informacje op ododaniu pracownika


        _itemAddedCallback?.Invoke(item);// dodanie nowego parametru 

        //

        ItemAdded?.Invoke(this, item); // eventhandler


        //db Set udoastepnia remove

        //dodanie strzałów
    }



    public void Remove(T item)
    {
        _dbSet.Remove(item);

        //db Set udoastepnia remove
    }
    public void Save()
    {
        _dbContext.SaveChanges();



        //dodanie strzałów

        //db Set udoastepnia remove
    }
}





