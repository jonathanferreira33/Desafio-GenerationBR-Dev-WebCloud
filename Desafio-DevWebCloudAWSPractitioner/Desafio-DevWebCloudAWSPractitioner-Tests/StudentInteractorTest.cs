using Desafio_DevWebCloudAWSPractitioner.Domain.Entities;

namespace Desafio_DevWebCloudAWSPractitioner_Tests
{
    public class StudentInteractorTest
    {
        [Fact]
        public void CreateStudentOk()
        {
            //AAA
            //ARRANGE
            var student = new Student()
            {

            };

            //ACT

            //ASSERT
            Assert.True(2+2 == 4);
        }

        [Fact]
        public void CreateStudentNotOk()
        {
            //AAA
            //ARRANGE

            //ACT

            //ASSERT
            Assert.False(2 + 3 == 4);
        }

        [Fact]
        public void GetStudensDoesExists()
        {
           
            Assert.True(2 + 2 == 4);
        }

        [Fact]
        public void GetStudensDoesNotExists()
        {
            
            Assert.True(2 + 2 == 4);
        }
    }
}