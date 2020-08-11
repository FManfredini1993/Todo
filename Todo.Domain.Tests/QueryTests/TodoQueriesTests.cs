using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]
    public class TodoQueryTests
    {
        private List<TodoItem> _items;

        public TodoQueryTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", "UsuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 2", "UsuarioB", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 3", "Elon Musk", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 4", "UsuarioD", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 5", "Elon Musk", DateTime.Now));
        }

        [TestMethod]
        public void GivenAnQuery_ShouldReturnTasksOfASpecificUser()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("Elon Musk"));
            Assert.AreEqual(2, result.Count());
        }
    }
}