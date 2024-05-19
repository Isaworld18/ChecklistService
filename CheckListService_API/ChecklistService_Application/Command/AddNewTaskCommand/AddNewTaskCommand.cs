namespace ChecklistService_Application.Command
{
    using MediatR;

    public class AddNewTaskCommand : IRequest<AddNewTaskCommandResponse>
    {
        public string NewWorkDescription { get; }

        public AddNewTaskCommand(string desc)
        { 
            NewWorkDescription = desc;
        }
    }
}
