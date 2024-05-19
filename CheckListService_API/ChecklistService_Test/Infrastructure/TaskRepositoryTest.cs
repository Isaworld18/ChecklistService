namespace ChecklistService_Test.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ChecklistService_Domain.Interfaces;
    using ChecklistService_Domain.Models;
    using ChecklistService_Infrastructure.Repositories;

    public class TaskRepositoryTest
    {
        private ITaskRepository _taskRepository;

        private Work _singleData;
        private List<Work> _dataList;

        [SetUp]
        public void Setup()
        {
            _taskRepository = new TaskRepository();

            _singleData = new()
            { 
                Description = "TestWorkDesc",
            };

        }

        [Test]
        public async Task Add_ValidResult()
        {
            Work added = await _taskRepository.Add(_singleData);

            Assert.That(added, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(added.Id > 0, Is.True);
                Assert.That(_singleData.Description, Is.EqualTo(added.Description));
            });
        }

        [Test]
        public async Task Add_ErrorResult()
        {

        }

        [Test]
        public async Task Update_ValidResult()
        {

        }

        [Test]
        public async Task Update_ErrorResult()
        {

        }

        [Test]
        public async Task GetById_ValidResult()
        {

        }

        [Test]
        public async Task GetById_ErrorResult()
        {

        }

        [Test]
        public async Task GetDone_ValidResult()
        {

        }

        [Test]
        public async Task GetDone_ErrorResult()
        {


        }

        [Test]
        public async Task Exists_ValidResult()
        {

        }

        [Test]
        public async Task Exists_ErrorResult()
        {

        }

        [Test]
        public async Task Order_ValidResult()
        {

        }

        [Test]
        public async Task Order_ErrorResult()
        {

        }
    }
}
