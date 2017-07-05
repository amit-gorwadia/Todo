using System.Collections.Generic;
using TodoApp.Models;

namespace TodoApp.Service
{
    public interface ITodoService
    {
        IList<ToDo> GetAll();

        ToDo GetById(int id);

        void Add(ToDo todo);

        void Edit(ToDo todo);

        void Delete(int id);
    }
}
