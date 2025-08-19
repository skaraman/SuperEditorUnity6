using System;
using UnityEngine;
using NUnit.Framework;

namespace SuperEditor.Tests
{
    /// <summary>
    /// Tests for the enhanced debugger interface functionality
    /// </summary>
    [TestFixture]
    public class DebuggerInterfaceTests
    {
        [SetUp]
        public void Setup()
        {
            // Ensure debugging is disabled before each test
            if (DebuggerInterface.IsDebuggingEnabled)
            {
                DebuggerInterface.DisableDebugging();
            }
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up after each test
            if (DebuggerInterface.IsDebuggingEnabled)
            {
                DebuggerInterface.DisableDebugging();
            }
        }

        [Test]
        public void EnableDebugging_EnablesDebuggingState()
        {
            // Act
            DebuggerInterface.EnableDebugging();

            // Assert
            Assert.IsTrue(DebuggerInterface.IsDebuggingEnabled);
        }

        [Test]
        public void DisableDebugging_DisablesDebuggingState()
        {
            // Arrange
            DebuggerInterface.EnableDebugging();

            // Act
            DebuggerInterface.DisableDebugging();

            // Assert
            Assert.IsFalse(DebuggerInterface.IsDebuggingEnabled);
        }

        [Test]
        public void EnableDebugging_FiresDebuggingStateChangedEvent()
        {
            // Arrange
            bool eventFired = false;
            DebuggerInterface.DebuggingStateChanged += (enabled) => { eventFired = enabled; };

            // Act
            DebuggerInterface.EnableDebugging();

            // Assert
            Assert.IsTrue(eventFired);
        }

        [Test]
        public void DisableDebugging_FiresDebuggingStateChangedEvent()
        {
            // Arrange
            DebuggerInterface.EnableDebugging();
            bool eventFired = true; // Start as true since we expect it to become false
            DebuggerInterface.DebuggingStateChanged += (enabled) => { eventFired = enabled; };

            // Act
            DebuggerInterface.DisableDebugging();

            // Assert
            Assert.IsFalse(eventFired);
        }

        [Test]
        public void SetContextVariable_AddsVariableToContext()
        {
            // Arrange
            DebuggerInterface.EnableDebugging();
            string variableName = "testVar";
            string variableValue = "testValue";

            // Act
            DebuggerInterface.SetContextVariable(variableName, variableValue);

            // Assert
            var context = DebuggerInterface.GetExecutionContext();
            Assert.IsTrue(context.ContainsKey(variableName));
            Assert.AreEqual(variableValue, context[variableName]);
        }

        [Test]
        public void GetCurrentDebugInfo_ReturnsCorrectState()
        {
            // Arrange
            DebuggerInterface.EnableDebugging();

            // Act
            var debugInfo = DebuggerInterface.GetCurrentDebugInfo();

            // Assert
            Assert.IsNotNull(debugInfo);
            Assert.IsTrue(debugInfo.IsDebugging);
            Assert.IsNotNull(debugInfo.Variables);
        }

        [Test]
        public void EvaluateExpression_ReturnsCorrectValue()
        {
            // Arrange
            DebuggerInterface.EnableDebugging();
            string variableName = "testVar";
            string variableValue = "testValue";
            DebuggerInterface.SetContextVariable(variableName, variableValue);

            // Act
            var result = DebuggerInterface.EvaluateExpression(variableName);

            // Assert
            Assert.AreEqual(variableValue, result);
        }

        [Test]
        public void EvaluateExpression_EvaluatesSimpleComparison()
        {
            // Arrange
            DebuggerInterface.EnableDebugging();
            DebuggerInterface.SetContextVariable("x", "5");

            // Act
            var result = DebuggerInterface.EvaluateExpression("x == 5");

            // Assert
            Assert.IsTrue((bool)result);
        }

        [Test]
        public void PauseExecution_FiresExecutionPausedEvent()
        {
            // Arrange
            DebuggerInterface.EnableDebugging();
            bool eventFired = false;
            DebugInfo capturedDebugInfo = null;
            DebuggerInterface.ExecutionPaused += (debugInfo) => 
            { 
                eventFired = true; 
                capturedDebugInfo = debugInfo;
            };

            // Act
            DebuggerInterface.PauseExecution("Test pause");

            // Assert
            Assert.IsTrue(eventFired);
            Assert.IsNotNull(capturedDebugInfo);
            Assert.AreEqual("Test pause", capturedDebugInfo.Reason);
        }

        [Test]
        public void ResumeExecution_FiresExecutionResumedEvent()
        {
            // Arrange
            DebuggerInterface.EnableDebugging();
            bool eventFired = false;
            DebuggerInterface.ExecutionResumed += () => { eventFired = true; };

            // Simulate paused state
            DebuggerInterface.PauseExecution("Test pause");

            // Act
            DebuggerInterface.ResumeExecution();

            // Assert
            Assert.IsTrue(eventFired);
        }

        [Test]
        public void ForceBreak_PausesExecution()
        {
            // Arrange
            DebuggerInterface.EnableDebugging();
            bool pauseEventFired = false;
            DebuggerInterface.ExecutionPaused += (debugInfo) => { pauseEventFired = true; };

            // Act
            DebuggerInterface.ForceBreak();

            // Assert
            Assert.IsTrue(pauseEventFired);
        }

        [Test]
        public void DebugInfo_ToString_ReturnsCorrectFormat()
        {
            // Arrange
            var debugInfo = new DebugInfo
            {
                Reason = "Test reason",
                IsPlaying = true,
                IsPaused = true,
                Variables = new System.Collections.Generic.Dictionary<string, object> { { "test", "value" } }
            };

            // Act
            string result = debugInfo.ToString();

            // Assert
            Assert.IsTrue(result.Contains("Test reason"));
            Assert.IsTrue(result.Contains("Playing: True"));
            Assert.IsTrue(result.Contains("Paused: True"));
            Assert.IsTrue(result.Contains("Variables: 1"));
        }

        private class MockContext
        {
            public string TestProperty { get; set; } = "MockValue";
            public int TestNumber { get; set; } = 123;
        }

        [Test]
        public void PauseExecution_WithContext_CapturesVariables()
        {
            // Arrange
            DebuggerInterface.EnableDebugging();
            var mockContext = new MockContext();
            DebugInfo capturedDebugInfo = null;
            DebuggerInterface.ExecutionPaused += (debugInfo) => { capturedDebugInfo = debugInfo; };

            // Act
            DebuggerInterface.PauseExecution("Test with context", mockContext);

            // Assert
            Assert.IsNotNull(capturedDebugInfo);
            Assert.IsTrue(capturedDebugInfo.Variables.ContainsKey("TestProperty"));
            Assert.IsTrue(capturedDebugInfo.Variables.ContainsKey("TestNumber"));
            Assert.AreEqual("MockValue", capturedDebugInfo.Variables["TestProperty"]);
            Assert.AreEqual(123, capturedDebugInfo.Variables["TestNumber"]);
        }
    }
}