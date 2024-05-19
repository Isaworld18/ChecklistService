namespace ChecklistService_Application.Mapper
{
    using System.Collections.Generic;
    using ChecklistService_Application.Command;
    using ChecklistService_Domain.Models;

    public static class TaskMapper
    {
        public static TaskResponse ToResponse(Work entity)
        { 
            return new TaskResponse(entity);
        }

        public static List<TaskResponse> ToResponseList(List<Work> data)
        {
            List<TaskResponse> result = [];

            foreach (Work work in data) 
            {
                result.Add(ToResponse(work));
            }

            return result;
        }
    }
}
