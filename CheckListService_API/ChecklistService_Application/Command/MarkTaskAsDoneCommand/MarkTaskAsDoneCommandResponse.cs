namespace ChecklistService_Application.Command
{
    public class MarkTaskAsDoneCommandResponse
    {
        public TaskResponse? UpdatedTask { get; set; }

        public string ResponseMessage { get; set; }

        public MarkTaskAsDoneCommandResponse()
        { 
            UpdatedTask = null;
            ResponseMessage = string.Empty;
        }

        public MarkTaskAsDoneCommandResponse(TaskResponse? updatedTask, string responseMessage)
        {
            UpdatedTask = updatedTask;
            ResponseMessage = responseMessage;
        }
    }
}
