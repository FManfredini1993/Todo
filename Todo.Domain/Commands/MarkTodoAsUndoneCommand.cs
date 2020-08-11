using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class MarkTodoAsundoneCommand : Notifiable, ICommand
    {
        public MarkTodoAsundoneCommand() { }
        public MarkTodoAsundoneCommand(Guid id, string user)
        {
            this.Id = id;
            User = user;
        }
        public Guid Id { get; set; }
        public string User { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(User, 6, "User", "Usuário inválido")
            );
        }
    }
}