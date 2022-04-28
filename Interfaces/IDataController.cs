using System;
using System.Collections.Generic;

namespace Interfaces;
public interface IDataController<T, O>
{
    public T findById(int id);

    public List<T> getAll();

    public void update(T obj);

    public void delete(T obj);

    public T convertModelToDTO();
}