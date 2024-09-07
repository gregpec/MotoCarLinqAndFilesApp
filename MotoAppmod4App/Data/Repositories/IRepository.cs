namespace MotoAppmod4App.Data.Repositories;
using MotoAppmod4App.Data.Entities;

/*
public  interface IRepository<out T> where T : class,IEntity  // ograniczenia T klasą i encją
{
    // brakuje kowariancji
    //słówko out konwersja z podstawowego na ogólny kowariancja KOWARIANCJA


    
    IEnumerable<T> GetAll(); // dochodzi jedna metoda ktora operuje na Enumerable

    // dzięki temu operujemy na całej kolekcji enumerable
    T GetById(int id);
    void Add(T item); //BRAKUJE KONTRAWARIANCJI
    void Remove(T item); //BRAKUJE KONTRAWARIANCJI dziedziczenie interfejsu
    void Save();

    
    
    
    // przepiecie wszystkich implementacji 
    // generic repository Sql repository

}
*/

public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>


    // wersja z kowariancja i kontrawariancją IReadrepository IWriterepository
    // dziedziczenie po IReadRepository i IWriteRepository
    //?????????
    where T : class, IEntity

{

}

