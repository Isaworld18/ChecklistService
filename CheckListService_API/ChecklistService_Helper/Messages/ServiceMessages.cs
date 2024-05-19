namespace ChecklistService_Helper.Messages
{
    public static class ServiceMessages
    {
        public static string Api_ExceptionLogTitle = GetMessage("Api_ExceptionLogTitle");

        public static string Api_Exception = GetMessage("Api_Exception");

        public static string QueryHandler_ExceptionLogTitle = GetMessage("QueryHandler_ExceptionLogTitle");

        public static string CommandHandler_ExceptionLogTitle = GetMessage("CommandHandler_ExceptionLogTitle");

        public static string AddNewTask_Validation = GetMessage("AddNewTask_Validation");

        public static string AddNewTask_ValidOperation = GetMessage("AddNewTask_ValidOperation");

        public static string AddNewTask_Exception = GetMessage("AddNewTask_Exception");

        public static string MarkTaskDone_Validation = GetMessage("MarkTaskDone_Validation");

        public static string MarkTaskDone_ValidOperation = GetMessage("MarkTaskDone_ValidOperation");

        public static string MarkTaskDone_Exception = GetMessage("MarkTaskDone_Exception");

        public static string ListTask_ValidOperation = GetMessage("ListTask_ValidOperation");

        public static string ListTask_Exception = GetMessage("ListTask_Exception");

        public static string OrderTaskBy_Validation = GetMessage("OrderTaskBy_Validation");

        private static string GetMessage(string name) => Messages.ResourceManager.GetString(name);
    }
}
