using System;
using Moq;
using MOQExamples.SystemsUnderTest;
using Xunit;

namespace MOQExamples.B_Advanced
{
    public class C_CallBacks
    {
        [Fact]
        public void Should_Call_Back_After_Executing_Mocked_Function()
        {
            var mockRepo = new Mock<IRepo>();
            mockRepo.Setup(x => x.Find(It.IsAny<int>()))
                .Callback(() => Console.WriteLine("Before Execution"))
                .Returns(new Customer())
                .Callback(() => Console.WriteLine("After Execution"));
        }
    }
}