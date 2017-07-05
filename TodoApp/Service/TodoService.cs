using System.Collections.Generic;
using System.Linq;
using TodoApp.Models;
using System.Data.Entity;

namespace TodoApp.Service
{
    public class TodoService: ITodoService
    {
        ApplicationDbContext db;

        public TodoService()
        {
            db = ApplicationDbContext.Create();
        }

        public IList<ToDo> GetAll()
        {
            return db.ToDos.ToList();
        }

        public ToDo GetById(int id)
        {
            if (id <= 0)
                return null;
            return db.ToDos.SingleOrDefault(x => x.Id == id);
        }

        public void Add(ToDo todo)
        {
            if(todo !=null)
            {
                db.ToDos.Add(todo);
                db.SaveChanges();
            }
        }

        public void Edit(ToDo todo)
        {
            if(todo != null)
            {
                var todoToEdit = db.ToDos.AsNoTracking().SingleOrDefault(x => x.Id == todo.Id);
                db.Entry(todo).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            if (id > 0)
            {
                var todoToDelete = db.ToDos.FirstOrDefault(x => x.Id == id);
                if (todoToDelete != null)
                {
                    db.ToDos.Remove(todoToDelete);
                    db.SaveChanges();
                }
            }
        }
    }
}