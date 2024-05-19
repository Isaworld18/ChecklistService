namespace ChecklistService_Test.Helper
{
    using ChecklistService_Helper.Messages;

    public class ServiceMessageTest
    {
        [Test]
        public void GetMessage_ValidResult()
        {
            string msg = ServiceMessages.AddNewTask_Validation;

            Assert.IsTrue(!string.IsNullOrEmpty(msg));
        }
    }
}
