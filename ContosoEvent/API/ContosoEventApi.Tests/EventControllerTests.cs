using ContosoEventApi.Controllers;
using ContosoEventApi.Model;
using ContosoEventApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ContosoEventApi.Tests.Controllers
{
    public abstract class EventsControllerTests
    {

        protected readonly ActionResult<IEnumerable<Event>> Items;
        protected readonly Mock<IEvent> MockService;
        protected readonly EventsController ControllerUnderTest;

        protected EventsControllerTests(ActionResult<IEnumerable<Event>> items)
        {
            //items = events;
            Items = items;
            MockService = new Mock<IEvent>();
            MockService.Setup(svc => svc.GetEvents()).ReturnsAsync(Items);
            ControllerUnderTest = new EventsController(MockService.Object);
        }

    }

}