namespace ChecklistService_Application.Query
{
    using System.Collections.Generic;
    using ChecklistService_Application.Command;
    using ChecklistService_Application.Mapper;
    using ChecklistService_Domain.Models;

    public class OrderTaskByQueryResponse
    {
        public List<TaskResponse> ResultList { get; set; }

        public string ResponseMessage { get; set; }

        public OrderTaskByQueryResponse()
        {
            ResultList = [];

            ResponseMessage = string.Empty;
        }

        public OrderTaskByQueryResponse(List<Work> data, string msg)
        {
            ResultList = TaskMapper.ToResponseList(data);

            ResponseMessage = msg;
        }
    }
}
