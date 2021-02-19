using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rover;

namespace RoverTests
{
    [TestClass]
    public class RoverTests
    {
        private Map _map;
        private Rover.Rover _rover;

        [TestInitialize]
        public void Setup()
        {
            _map = new Map();
            _rover = new Rover.Rover(_map);
        }

        [TestMethod]
        public void TurnLeft()
        {
            var output = _rover.Execute("L");
            Assert.AreEqual("0:0:W",output);
            output = _rover.Execute("L");
            Assert.AreEqual("0:0:S", output);
            output = _rover.Execute("L");
            Assert.AreEqual("0:0:E", output);
            output = _rover.Execute("L");
            Assert.AreEqual("0:0:N", output);
        }

        [TestMethod]
        public void TurnRight()
        {
            var output = _rover.Execute("R");
            Assert.AreEqual("0:0:E", output);
            output = _rover.Execute("R");
            Assert.AreEqual("0:0:S", output);
            output = _rover.Execute("R");
            Assert.AreEqual("0:0:W", output);
            output = _rover.Execute("R");
            Assert.AreEqual("0:0:N", output);
        }

        [TestMethod]
        public void MoveForward()
        {
            var output = _rover.Execute("M");
            Assert.AreEqual("0:1:N", output);
            output = _rover.Execute("RM");
            Assert.AreEqual("1:1:E", output);
            output = _rover.Execute("LM");
            Assert.AreEqual("1:2:N", output);
        }

        [TestMethod]
        public void Example1()
        {
            var input = "MMRMMLM";
            var expected = "2:3:N";
            var result = _rover.Execute(input);
            Assert.AreEqual(expected,result);
        }

        [TestMethod]
        public void Example2()
        {
            var input = "MMMMMMMMMM";
            var expected = "0:0:N";
            var result = _rover.Execute(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Example3()
        {
            var expected = "O:0:2:N";
            var input = "MMMM";
            _map.Obstacles.Add(new Position(0,3));
            var result = _rover.Execute(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WestWrap()
        {
            var result = _rover.Execute("LM");
            Assert.AreEqual("9:0:W",result);
        }

        [TestMethod]
        public void SouthWrap()
        {
            var result = _rover.Execute("LLM");
            Assert.AreEqual("0:9:S", result);
        }
    }
}
