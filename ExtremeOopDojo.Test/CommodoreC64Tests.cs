using System;
using ExtremeOopDojo.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtremeOopDojo.Test
{
    [TestClass]
    public class CommodoreC64Tests
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
        public void InterpretShouldReturnEmptyWhenGivenEmpty() // An empty program produces no output
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
        public void InterpretShouldReturnNewLineWhenGivenPrint() // A bare “print” statement produces a single newline
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
        public void InterpretShouldReturnStringWhenGivenString() // A “print” statement can have a constant string as an argument. The output is the constant string
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
        public void InterpretShouldHandleMultipleStatements() // Two or more statements in a sequence are executed one after the other
        {
            //Arrange
            var classUnderTest = new CommodoreC64();
            var input = new UserInput(@"PRINT;PRINT ""Hi"";PRINT ""There"";PRINT""!""");
            //Act
            var result = classUnderTest.Interpret(input);

            //Assert
            Assert.AreEqual(Environment.NewLine + "Hi" + Environment.NewLine +
                            "There" + Environment.NewLine +
                            "!" + Environment.NewLine,
                            result);
        }

        [TestMethod]
        public void InterpretShouldHandlePrintWithIntegerOperand() // : The “print” statement can output number constants.
        {
            //Arrange
            var classUnderTest = new CommodoreC64();
            var input = new UserInput(@"PRINT 123");
            //Act
            var result = classUnderTest.Interpret(input);

            //Assert
            Assert.AreEqual("123" + Environment.NewLine, result);
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

        [TestMethod]
        public void InterpretShouldHandlePrintOfVariables() // A single letter is a variable. The print statement can print its value. The default value for a variable 0
        {
            //Arrange
            var classUnderTest = new CommodoreC64();
            var input = new UserInput(@"PRINT A");
            //Act
            var result = classUnderTest.Interpret(input);

            //Assert
            Assert.AreEqual("0" + Environment.NewLine, result);
        }

        [TestMethod]
        public void InterpretShouldHandleVariableAssignment() // An assignment statement binds a value to a variable.
        {
            //Arrange
            var classUnderTest = new CommodoreC64();
            var input = new UserInput(@"A = 12;PRINT A");
            //Act
            var result = classUnderTest.Interpret(input);

            //Assert
            Assert.AreEqual("12" + Environment.NewLine, result);
        }

        [TestMethod]
        public void InterpretShouldHandleAddition() // Two numeric constants can be added together.
        {
            //Arrange
            var classUnderTest = new CommodoreC64();
            var input = new UserInput(@"PRINT 3 + 7");
            //Act
            var result = classUnderTest.Interpret(input);

            //Assert
            Assert.AreEqual("10" + Environment.NewLine, result);
        }

        [TestMethod]
        public void InterpretShouldHandleMultipleAddition() // A numeric expression can have more than two terms.
        {
            //Arrange
            var classUnderTest = new CommodoreC64();
            var input = new UserInput(@"PRINT 4 + 4 + 12");
            //Act
            var result = classUnderTest.Interpret(input);

            //Assert
            Assert.AreEqual("20" + Environment.NewLine, result);
        }

        [TestMethod]
        public void InterpretShouldHandleVariablesAndConstants() // A numeric expression can be built with variables and/or constants
        {
            //Arrange
            var classUnderTest = new CommodoreC64();
            var input = new UserInput(@"A=2;B=7;PRINT A + 1;PRINT A + B;PRINT 99 + B");
            //Act
            var result = classUnderTest.Interpret(input);

            //Assert
            Assert.AreEqual("3" + Environment.NewLine + "9" + Environment.NewLine + "106" + Environment.NewLine, result);
        }

        [TestMethod]
        public void InterpretShouldHandleSubtraction() // Two numeric expressions can be subtracted
        {
            //Arrange
            var classUnderTest = new CommodoreC64();
            var input = new UserInput(@"PRINT 1 - 2");
            //Act
            var result = classUnderTest.Interpret(input);

            //Assert
            Assert.AreEqual("-1" + Environment.NewLine, result);
        }

        [TestMethod]
        public void InterpretShouldHandleParenthesis() // Expressions can be parenthesized
        {
            //Arrange
            var classUnderTest = new CommodoreC64();
            var input = new UserInput(@"PRINT 1 - (2 + 3)");
            //Act
            var result = classUnderTest.Interpret(input);

            //Assert
            Assert.AreEqual("-1" + Environment.NewLine, result);
        }
    }
}
