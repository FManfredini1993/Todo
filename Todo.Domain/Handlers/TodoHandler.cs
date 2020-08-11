using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler :
        Notifiable,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<MarkTodoAsDoneCommnad>,
        IHandler<MarkTodoAsundoneCommand>
    {
        private readonly ITodoRepository _repo;

        public TodoHandler(ITodoRepository repo)
        {
            _repo = repo;
        }
        public ICommandResult Handle(CreateTodoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Existe algo errado na sua tarefa.", command.Notifications);

            var todo = new TodoItem(command.Title, command.User, command.Date);

            _repo.Create(todo);
            return new GenericCommandResult(true, "Criado com sucesso", todo);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Existe algo errado na sua tarefa", command.Notifications);

            var todo = _repo.GetById(command.Id, command.User);

            todo.UpdateTitle(command.Title);

            _repo.Update(todo);

            return new GenericCommandResult(true, "Alterado com sucesso", todo);
        }

        public ICommandResult Handle(MarkTodoAsundoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao atualizar tarefa", command.Notifications);

            var todo = _repo.GetById(command.Id, command.User);

            todo.MarkAsUndone();

            _repo.Update(todo);

            return new GenericCommandResult(true, "Tarefa salva", command.Notifications);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommnad command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao atualizar tarefa", command.Notifications);

            var todo = _repo.GetById(command.Id, command.User);

            todo.MarkAsDone();

            _repo.Update(todo);

            return new GenericCommandResult(true, "Tarefa salva", command.Notifications);
        }
    }
}