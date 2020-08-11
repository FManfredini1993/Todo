using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests
{
    [TestClass]
    public class TodoItemTests
    {
        private readonly TodoItem _validTodo = new TodoItem("Task Title", "Felipe", DateTime.Now);
        [TestMethod]
        public void GivenAnNewTask_TaskCantBeFinished()
        {
            Assert.AreEqual(_validTodo.Done, false);
        }
    }
}