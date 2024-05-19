namespace ChecklistService_Application.Command
{
    using System;
    using ChecklistService_Domain.Models;

    public class AddNewTaskCommandResponse
    {
        public TaskResponse? AddedTask { get; set; }

        public string ResponseMessage { get; set; }

        public AddNewTaskCommandResponse()
        {
            AddedTask = null;
            ResponseMessage = string.Empty;
        }

        public AddNewTaskCommandResponse(TaskResponse newTask, string msg)
        {
            AddedTask = newTask;
            ResponseMessage = msg;
        }
    }

    public class TaskResponse
    {
        public int Id { get; set; }

        public string Description { get; set; } = null!;

        public bool Done { get; set; }

        public DateOnly? EndDate { get; set; }

        public TaskResponse() { }

        public TaskResponse(Work work)
        {
            Id = work.Id;
            Description = work.Description;
            Done = work.Done;
            EndDate = work.EndDate;
        }
    }
}
