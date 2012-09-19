﻿using System.Collections.Generic;
using System.Diagnostics;
using Moq;
using Xunit;
using zasz.me.Controllers;
using zasz.me.Services.Contracts;

namespace zasz.health.ControllerTests
{
    public class PortfolioControllerTests
    {
        private readonly PortfolioController controller;

        public PortfolioControllerTests()
        {
            var mock = new Mock<ISofuService>();
            controller = new PortfolioController(mock.Object);
        }

        [Fact]
        public void ShouldBeAbleToGetMyQuestions()
        {
            var stackExchange = controller.StackExchange();
            var model = (List<int>)stackExchange.Model;
            Debug.WriteLine(string.Join(", ", model));
        }
    }
}