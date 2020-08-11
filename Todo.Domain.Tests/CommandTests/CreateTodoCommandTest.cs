using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using System;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateCommandTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Tarefa 1", "Felipe", DateTime.Now);
        public CreateCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }
        [TestMethod]
        public void GivenAnInvalidCommand()
        {
            Assert.AreEqual(_invalidCommand.Valid, false);
        }
        [TestMethod]
        public void GivenAnValidCommand()
        {
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}