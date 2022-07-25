using ContosoEventApi.Model;
using ContosoEventApi.Tests.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContosoEventApi.Tests
{
    public class GetTests : EventsControllerTests
    {
        private static readonly Event FirstItem = new Event { EventId = 1, EventName = "Cricket", EventDetails = "Live on hotsport", EventStartDate = new DateTime(2022, 05, 16), EventEndDate = new DateTime(2022, 05, 16), EventLanguage = "Hindi", EventLocaion = "Bangalore" };
        private static readonly Event SecondItem = new Event { EventId = 2, EventName = "Tennis", EventDetails = "Live on hotsport", EventStartDate = new DateTime(2022, 05, 16), EventEndDate = new DateTime(2022, 05, 16), EventLanguage = "Hindi", EventLocaion = "Bangalore" };
        public GetTests() : base(new List<Event>() { FirstItem })
        {
        }


        [Fact]
        public async void Task_GetEvents_Return_OkResult()
        {
            //Arrange
            



            //Act
            var data = await ControllerUnderTest.GetEvents();



            //Assert        

            Assert.IsType<ActionResult<IEnumerable<Event>>>(data);
        }



        [Fact]
        public async Task GetEvent_StateUnderTest_Expected_NotNull()
        {
            // Arrange
            int EventId = 1;

            // Act
            var data = await ControllerUnderTest.GetEvent(
                EventId);

            // Assert

            Assert.IsType<ActionResult<Event>>(data);


        }
        [Fact]
        public async void Task_GetEventById_Return_NotFoundResult()
        {
            //Arrange
            var EventId = 30;



            //Act
            var data = await ControllerUnderTest.GetEvent(EventId);



            //Assert
            Assert.IsType<ActionResult<Event>>(data);
        }

        [Fact]
        public async void Task_Add_ValidData_Return_OkResult()
        {
            //Arrange
            var Event = new Event { EventId = 3, EventName = "Basketball", EventDetails = "Live on hotsport", EventStartDate = new DateTime(2022, 05, 16), EventEndDate = new DateTime(2022, 05, 16), EventLanguage = "Hindi", EventLocaion = "Bangalore" };



            //Act
            var data = await ControllerUnderTest.PostEvent(Event);



            //Assert
            Assert.IsType<ActionResult<Event>>(data);
        }
        [Fact]
        public async void Task_Add_InvalidData_Return_BadRequest()
        { 
            //Arrange
            var Event = new Event { EventId = 3, EventName = "Basketball", EventDetails = "Live on hotsport", EventStartDate = new DateTime(2022, 05, 16), EventEndDate = new DateTime(2022, 05, 16), EventLanguage = "Hindi", EventLocaion = "Bangalore" };



            //Act
            var data = await ControllerUnderTest.PostEvent(Event);



            //Assert
            Assert.IsType<ActionResult<Event>>(data);
        }

      
        //delete

        [Fact]
        public async void Task_Delete_Event_Return_OkResult()
        {
            //Arrange
            var Event = new Event { EventId = 3, EventName = "Basketball", EventDetails = "Live on hotsport", EventStartDate = new DateTime(2022, 05, 16), EventEndDate = new DateTime(2022, 05, 16), EventLanguage = "Hindi", EventLocaion = "Bangalore" };
            var EventId = 1;



            //Act
            var data = await ControllerUnderTest.DeleteEvent(EventId);



            //Assert
            Assert.IsType<BadRequestResult>(data);
        }
        [Fact]
        public async void Task_Delete_Event_Return_NotFoundResult()
        {
            //Arrange
            var EventId = 1;
            var Event = new Event { EventId = 3, EventName = "Basketball", EventDetails = "Live on hotsport", EventStartDate = new DateTime(2011, 11, 19, 00, 00, 00), EventEndDate = new DateTime(2022, 05, 16), EventLanguage = "Hindi", EventLocaion = "Bangalore" };





            //Act
            var data = await ControllerUnderTest.DeleteEvent(EventId);



            //Assert
            Assert.IsType<BadRequestResult>(data);
        }
    }


}

