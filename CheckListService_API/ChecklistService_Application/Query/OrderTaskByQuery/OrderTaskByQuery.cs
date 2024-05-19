namespace ChecklistService_Application.Query
{
    using ChecklistService_Helper.Enum;
    using MediatR;

    public class OrderTaskByQuery : IRequest<OrderTaskByQueryResponse>
    {
        public TasksOrder OrderBy { get; set; }

        public OrderTaskByQuery(TasksOrder orderBy)
        {
            OrderBy = orderBy;
        }
    }
}
