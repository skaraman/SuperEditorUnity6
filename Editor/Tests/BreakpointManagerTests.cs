using System;
using UnityEngine;
using NUnit.Framework;

namespace SuperEditor.Tests
{
    /// <summary>
    /// Tests for the breakpoint debugging functionality
    /// </summary>
    [TestFixture]
    public class BreakpointManagerTests
    {
        [SetUp]
        public void Setup()
        {
            // Clear any existing breakpoints before each test
            var breakpoints = BreakpointManager.GetBreakpoints();
            foreach (var bp in breakpoints)
            {
                BreakpointManager.RemoveBreakpoint(bp.Id);
            }
        }

        [Test]
        public void AddBreakpoint_CreatesNewBreakpoint()
        {
            // Arrange
            string testFile = "TestScript.cs";
            int testLine = 10;

            // Act
            BreakpointManager.AddBreakpoint(testFile, testLine);

            // Assert
            var breakpoints = BreakpointManager.GetBreakpoints();
            Assert.AreEqual(1, breakpoints.Count);
            Assert.AreEqual(testFile, breakpoints[0].FilePath);
            Assert.AreEqual(testLine, breakpoints[0].LineNumber);
            Assert.IsTrue(breakpoints[0].IsEnabled);
        }

        [Test]
        public void AddBreakpoint_WithCondition_CreatesConditionalBreakpoint()
        {
            // Arrange
            string testFile = "TestScript.cs";
            int testLine = 15;
            string condition = "x == 5";

            // Act
            BreakpointManager.AddBreakpoint(testFile, testLine, condition);

            // Assert
            var breakpoints = BreakpointManager.GetBreakpoints();
            Assert.AreEqual(1, breakpoints.Count);
            Assert.AreEqual(condition, breakpoints[0].Condition);
        }

        [Test]
        public void RemoveBreakpoint_RemovesExistingBreakpoint()
        {
            // Arrange
            BreakpointManager.AddBreakpoint("TestScript.cs", 10);
            var breakpoints = BreakpointManager.GetBreakpoints();
            string breakpointId = breakpoints[0].Id;

            // Act
            BreakpointManager.RemoveBreakpoint(breakpointId);

            // Assert
            var remainingBreakpoints = BreakpointManager.GetBreakpoints();
            Assert.AreEqual(0, remainingBreakpoints.Count);
        }

        [Test]
        public void ShouldPauseAtLocation_ReturnsTrueForActiveBreakpoint()
        {
            // Arrange
            string testFile = "TestScript.cs";
            int testLine = 20;
            BreakpointManager.AddBreakpoint(testFile, testLine);

            // Act
            bool shouldPause = BreakpointManager.ShouldPauseAtLocation(testFile, testLine);

            // Assert
            Assert.IsTrue(shouldPause);
        }

        [Test]
        public void ShouldPauseAtLocation_ReturnsFalseForNonExistentBreakpoint()
        {
            // Arrange
            string testFile = "TestScript.cs";
            int testLine = 25;

            // Act
            bool shouldPause = BreakpointManager.ShouldPauseAtLocation(testFile, testLine);

            // Assert
            Assert.IsFalse(shouldPause);
        }

        [Test]
        public void ShouldPauseAtLocation_ReturnsFalseForDisabledBreakpoint()
        {
            // Arrange
            string testFile = "TestScript.cs";
            int testLine = 30;
            BreakpointManager.AddBreakpoint(testFile, testLine);
            var breakpoints = BreakpointManager.GetBreakpoints();
            breakpoints[0].IsEnabled = false;

            // Act
            bool shouldPause = BreakpointManager.ShouldPauseAtLocation(testFile, testLine);

            // Assert
            Assert.IsFalse(shouldPause);
        }

        [Test]
        public void PauseAtBreakpoint_IncrementsHitCount()
        {
            // Arrange
            string testFile = "TestScript.cs";
            int testLine = 35;
            BreakpointManager.AddBreakpoint(testFile, testLine);
            var mockContext = new { testVar = "testValue" };

            // Act
            BreakpointManager.PauseAtBreakpoint(testFile, testLine, mockContext);

            // Assert
            var breakpoints = BreakpointManager.GetBreakpoints();
            Assert.AreEqual(1, breakpoints[0].HitCount);
        }

        [Test]
        public void PauseAtBreakpoint_CapturesVariableState()
        {
            // Arrange
            string testFile = "TestScript.cs";
            int testLine = 40;
            BreakpointManager.AddBreakpoint(testFile, testLine);
            var mockContext = new MockTestContext
            {
                TestString = "Hello World",
                TestNumber = 42,
                TestBoolean = true
            };

            // Act
            BreakpointManager.PauseAtBreakpoint(testFile, testLine, mockContext);

            // Assert
            var variables = BreakpointManager.GetVariableState();
            Assert.IsTrue(variables.ContainsKey("TestString"));
            Assert.IsTrue(variables.ContainsKey("TestNumber"));
            Assert.IsTrue(variables.ContainsKey("TestBoolean"));
            Assert.AreEqual("Hello World", variables["TestString"]);
            Assert.AreEqual(42, variables["TestNumber"]);
            Assert.AreEqual(true, variables["TestBoolean"]);
        }

        [Test]
        public void RemoveBreakpointsForFile_RemovesAllFileBreakpoints()
        {
            // Arrange
            string testFile = "TestScript.cs";
            string otherFile = "OtherScript.cs";
            BreakpointManager.AddBreakpoint(testFile, 10);
            BreakpointManager.AddBreakpoint(testFile, 20);
            BreakpointManager.AddBreakpoint(otherFile, 30);

            // Act
            BreakpointManager.RemoveBreakpointsForFile(testFile);

            // Assert
            var breakpoints = BreakpointManager.GetBreakpoints();
            Assert.AreEqual(1, breakpoints.Count);
            Assert.AreEqual(otherFile, breakpoints[0].FilePath);
        }

        private class MockTestContext
        {
            public string TestString { get; set; }
            public int TestNumber { get; set; }
            public bool TestBoolean { get; set; }
        }
    }
}