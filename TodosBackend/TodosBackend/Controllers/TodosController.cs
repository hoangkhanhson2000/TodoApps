﻿using Microsoft.AspNetCore.Mvc;
using TodosBackend.Model;
using TodosBackend.Service.Todos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodosBackend.Controllers
{
    [Route("v1/api/todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodosService _todosService;
        public TodosController(ITodosService todosService)
        {
            _todosService=todosService;
        }


        // GET: api/<TodosController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_todosService.GetTodo());
        }

        // GET api/<TodosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TodosController>
        [HttpPost]
        public IActionResult Post(Todo todo)
        {
            return Ok(_todosService.AddTodo(todo));
        }

        // PUT api/<TodosController>/5
        [HttpPut()]
        public IActionResult Put(Todo todo)
        {
            return Ok(_todosService.UpdateTodo(todo));
        }

        // DELETE api/<TodosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_todosService.DeleteTodo(id));
        }
    }
}
