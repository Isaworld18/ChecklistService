namespace ChecklistService_Application.Command
{
    using MediatR;

    public class MarkTaskAsDoneCommand : IRequest<MarkTaskAsDoneCommandResponse>
    {
        public int TaskId { get; }

        public MarkTaskAsDoneCommand(int taskId)
        {
            TaskId = taskId;
        }   
    }
}
