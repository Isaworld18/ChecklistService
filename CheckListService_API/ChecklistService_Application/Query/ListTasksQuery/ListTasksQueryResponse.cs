namespace ChecklistService_Application.Query
{
    using System.Collections.Generic;
    using ChecklistService_Application.Command;
    using ChecklistService_Application.Mapper;
    using ChecklistService_Domain.Models;

    public class ListTasksQueryResponse
    {
        public List<TaskResponse> ResultList { get; set; }

        public string ResponseMessage { get; set; }

        public ListTasksQueryResponse()
        {
            ResultList = [];

            ResponseMessage = string.Empty;
        }

        public ListTasksQueryResponse(List<Work> data, string msg)
        {
            ResultList = TaskMapper.ToResponseList(data);

            ResponseMessage = msg;
        }
    }
}
