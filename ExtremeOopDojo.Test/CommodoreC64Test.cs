using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtremeOopDojo.Test
{
    [TestClass]
    public class CommodoreC64Test
    {
        [TestMethod]
        public void InterpretShouldHandleParseErrors()
        {
            //Arrange
            var classUnderTest = new CommodoreC64();
            var input = new UserInput("xxx");
            //Act
            var result = classUnderTest.Interpret(input);

            //Assert
            Assert.AreEqual("Error: xxx is not a valid expression", result);
        }

        [TestMethod]
        public void InterpretShouldReturnEmptyWhenGivenEmpty()
        {
            //Arrange
            var classUnderTest = new CommodoreC64();
            var input = new UserInput("");
            //Act
            var result = classUnderTest.Interpret(input);

            //Assert
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void InterpretShouldReturnNewLineWhenGivenPrint()
        {
            //Arrange
            var classUnderTest = new CommodoreC64();
            var input = new UserInput("PRINT");
            //Act
            var result = classUnderTest.Interpret(input);

            //Assert
            Assert.AreEqual(Environment.NewLine, result);
        }

        [TestMethod]
        public void InterpretShouldReturnStringWhenGivenString()
        {
            //Arrange
            var classUnderTest = new CommodoreC64();
            var input = new UserInput(@"PRINT ""Hello, World!""");
            //Act
            var result = classUnderTest.Interpret(input);

            //Assert
            Assert.AreEqual("Hello, World!" + Environment.NewLine, result);
        }

        [TestMethod]
        public void InterpretShouldHandleMultipleStatements()
        {
            //Arrange
            var classUnderTest = new CommodoreC64();
            var input = new UserInput(@"PRINT;PRINT ""Hi"";PRINT ""There"";PRINT""!""");
            //Act
            var result = classUnderTest.Interpret(input);

            //Assert
            Assert.AreEqual( Environment.NewLine+"Hi" + Environment.NewLine +
                            "There" + Environment.NewLine +
                            "!" + Environment.NewLine,
                            result);
        }

        [TestMethod]
        public void InterpretShouldHandlePrintWithIntegerOperand()
        {
            //Arrange
            var classUnderTest = new CommodoreC64();
            var input = new UserInput(@"PRINT 123");
            //Act
            var result = classUnderTest.Interpret(input);

            //Assert
            Assert.AreEqual("123" + Environment.NewLine,result);
        }

        [TestMethod]
        public void InterpretShouldHandlePrintWithNegativeIntegerOperand()
        {
            //Arrange
            var classUnderTest = new CommodoreC64();
            var input = new UserInput(@"PRINT -5");
            //Act
            var result = classUnderTest.Interpret(input);

            //Assert
            Assert.AreEqual("-5" + Environment.NewLine, result);
        }
    }
}
