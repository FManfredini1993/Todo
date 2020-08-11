using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Tarefa 1", "Felipe", DateTime.Now);
        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRopository());
        private GenericCommandResult _result = new GenericCommandResult();
        public CreateTodoHandlerTests() { }
        [TestMethod]
        public void GivenAnInvalidCommand_ShouldStopExecution()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(_result.Success, false);
        }
        [TestMethod]
        public void GivenAnValidCommand_ShouldCreateTask()
        {
            _result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }
    }
}