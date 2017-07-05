namespace TodoApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;
    using TodoApp.Models;
    using TodoApp.Service;
    public class TodoController : ApiController
    {
        private ITodoService service;
        //private ApplicationDbContext db;
        public TodoController()
        {
            service = new TodoService();
            //db = ApplicationDbContext.Create();
        }

        // GET: api/Todo
        /// <summary>
        /// Collection of <see cref="ToDo"/>
        /// </summary>
        /// <returns><see cref="ToDo"/> collection </returns>
        [ResponseType(typeof(IList<ToDo>))]
        public IHttpActionResult GetAll()
        {
            var todos = service.GetAll();
            return Ok(todos);
        }

        //public async Task<IHttpActionResult> GetAll()
        //{
        //    var todos = await db.ToDos.ToListAsync();

        //    return Ok(todos);
        //}

        // GET: api/Todo/5
        /// <summary>
        /// Get <see cref="ToDo"/> item by Id
        /// </summary>
        /// <param name="id">parameter</param>
        /// <returns>Individual <see cref="ToDo"/> item</returns>
        [ResponseType(typeof(ToDo))]
        public IHttpActionResult GetById(int id)
        {
            var todo = service.GetById(id);
            if (todo == null)
                return NotFound();
            return Ok(todo);
        }

        //public async Task<IHttpActionResult> GetById(int id)
        //{
        //    var todo = await db.ToDos.Where(item => item.Id == id).SingleOrDefaultAsync();
        //    if (todo == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(todo);
        //}

        // POST: api/Todo
        [ResponseType(typeof(ToDo))]
        public IHttpActionResult Post([FromBody] ToDo todo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            service.Add(todo);
            return Created(new Uri(Request.RequestUri, todo.Id.ToString()), todo);
        }
        //public async Task<IHttpActionResult> Post([FromBody] ToDo todo)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    db.ToDos.Add(todo);
        //    await db.SaveChangesAsync();
        //    return Created(new Uri(Request.RequestUri, todo.Id.ToString()), todo);
        //}

        // PUT: api/Todo/5
        public IHttpActionResult Put(ToDo todo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            service.Edit(todo);
            return StatusCode(HttpStatusCode.NoContent);
        }
        //public async Task<IHttpActionResult> Put(ToDo todo)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var todoToUpdate = await db.ToDos.AsNoTracking().Where(item => item.Id == todo.Id).SingleOrDefaultAsync();
        //    db.Entry(todo).State = EntityState.Modified;

        //    await db.SaveChangesAsync();

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // DELETE: api/Todo/5
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return NotFound();
            service.Delete(id);
            return Ok();
        }
        //public async Task<IHttpActionResult> Delete(int id)
        //{
        //    var todoToDelete = await db.ToDos.Where(item => item.Id == id).FirstOrDefaultAsync();

        //    if (todoToDelete == null)
        //    {
        //        return NotFound();
        //    }
        //    db.ToDos.Remove(todoToDelete);
        //    await db.SaveChangesAsync();

        //    return Ok();
        //}
    }
}
