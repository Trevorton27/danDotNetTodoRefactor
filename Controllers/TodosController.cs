using Microsoft.AspNetCore.Mvc;
using dotNetTodoReview.Models;
using System.Collections.Generic;
using dotNetTodoReview.Services;

namespace dotNetTodoReview.Controllers
{
    public class TodosController
    {
        [Route("api/[controller]")]
        [ApiController]

        public class ToDosController : ControllerBase
        {


            // GET: api/<ToDosController>
            [HttpGet]
            public List<ToDoModel> Get()
            {
                var getToDoService = new GetToDoService();
                var todos = getToDoService.GetTodos();

                return todos;

            }

            // GET api/<ToDosController>/5
            [HttpGet("{id}")]
            public string Get(int id)
            {
                return "value";
            }

            // POST api/<ToDosController>
            [HttpPost]
            public ToDoModel Post([FromBody] ToDoModel todo)
            {
                var postToDoService = new PostToDoService();
                var text = todo.Text;

                return postToDoService.PostToDo(text);
            }

            // PUT api/<ToDosController>/5
            [HttpPut("{id}")]
            public ToDoModel Put(int id, [FromBody] ToDoModel todo)
            {
                var updateToDoService = new UpdateToDoService();
                int todoId = id;
                var isComplete = todo.IsComplete;

                return updateToDoService.UpdateToDo(todoId, isComplete);
            }

            // DELETE api/<ToDosController>/5
            [HttpDelete("{id}")]
            public ToDoModel Delete(int id)
            {
                var deleteToDoService = new DeleteToDoService();
                int todoId = id;

                return deleteToDoService.DeleteToDo(todoId);
            }
        }
    }
}

