using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rover;

namespace RoverTests
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void CreateRover()
        {
            var map = new Map();
            var rover = new Rover.Rover(map);
            rover.Execute("");
        }

        [TestMethod]
        public void TurnLeft()
        {
            var map = new Map();
            var rover = new Rover.Rover(map);
            rover.Execute("L");
            Assert.AreEqual(rover.facing, Rover.Rover.Facing.W);
            rover.Execute("L");
            Assert.AreEqual(rover.facing, Rover.Rover.Facing.S);
            rover.Execute("L");
            Assert.AreEqual(rover.facing, Rover.Rover.Facing.E);
            rover.Execute("L");
            Assert.AreEqual(rover.facing, Rover.Rover.Facing.N);
        }

        [TestMethod]
        public void TurnRight()
        {
            var map = new Map();
            var rover = new Rover.Rover(map);
            rover.Execute("R");
            Assert.AreEqual(rover.facing, Rover.Rover.Facing.E);
            rover.Execute("R");
            Assert.AreEqual(rover.facing, Rover.Rover.Facing.S);
            rover.Execute("R");
            Assert.AreEqual(rover.facing, Rover.Rover.Facing.W);
            rover.Execute("R");
            Assert.AreEqual(rover.facing, Rover.Rover.Facing.N);
        }

        [TestMethod]
        public void MoveForward()
        {
            var map = new Map();
            var rover = new Rover.Rover(map);
            rover.Execute("M");
            Assert.AreEqual(1, rover.position.Y);
            rover.Execute("RM");
            Assert.AreEqual(1, rover.position.Y);
            Assert.AreEqual( 1, rover.position.X);
            var output = rover.Execute("LM");
            Assert.AreEqual(rover.position.X, 1);
            Assert.AreEqual(rover.position.Y, 2);
        }

        [TestMethod]
        public void Example1()
        {
            var input = "MMRMMLM";
            var expected = "2:3:N";
            var map = new Map();
            var rover = new Rover.Rover(map);
            var result = rover.Execute(input);
            Assert.AreEqual(expected,result);
        }

        [TestMethod]
        public void Example2()
        {
            var input = "MMMMMMMMMM";
            var expected = "0:0:N";
            var map = new Map();
            var rover = new Rover.Rover(map);
            var result = rover.Execute(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Example3()
        {
            var expected = "O:0:2:N";
            var input = "MMMM";
            var map = new Map();
            map.Obstacles.Add(new Obstacle(new Position(0,3)));
            var rover = new Rover.Rover(map);
            var result = rover.Execute(input);
            Assert.AreEqual(expected, result);
        }
    }
}
