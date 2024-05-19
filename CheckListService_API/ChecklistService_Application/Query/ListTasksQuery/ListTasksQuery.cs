namespace ChecklistService_Application.Query
{
    using MediatR;

    public class ListTasksQuery : IRequest<ListTasksQueryResponse>
    {
        public bool AreDone { get; }

        public ListTasksQuery(bool areDone)
        {
            AreDone = areDone;
        }
    }
}
