using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mandelbrot; // Namespace of the code to test

namespace Mandelbrot.Tests
{
    [TestClass]
    public class LogicTests
    {
        [TestMethod]
        public void Mandelbrot_Origin_IsInSet()
        {
            // Arrange
            var settings = new SettingsTemplate { iteration = 200, radius = 4 }; 

            // Act
            int result = Logic.mandelbrot_iterations(0.0, 0.0, settings);

            // Assert
            Assert.AreEqual(-1, result, "Point (0,0) should be inside the Mandelbrot set.");
        }

        [TestMethod]
        public void Mandelbrot_Point_C1_IsInSet()
        {
            // Arrange
            var settings = new SettingsTemplate { iteration = 200, radius = 4 };

            // Act
            int result = Logic.mandelbrot_iterations(-0.1, 0.1, settings);

            // Assert
            Assert.AreEqual(-1, result, "Point (-0.1, 0.1) should be inside the Mandelbrot set.");
        }

        [TestMethod]
        public void Mandelbrot_Point_Escapes_Quickly() // Was Mandelbrot_Point_C2_IsOutSideSet
        {
            // Arrange
            var settings = new SettingsTemplate { iteration = 200, radius = 4 };

            // Act
            int result = Logic.mandelbrot_iterations(1.0, 1.0, settings);

            // Assert
            Assert.AreEqual(2, result, "Point (1,1) should escape in 2 iterations with radius 4.");
        }

        [TestMethod]
        public void Mandelbrot_Point_Escapes_Within_MaxIterations() // Revised Test from prompt
        {
            // Arrange
            var settings = new SettingsTemplate { iteration = 5, radius = 4 };

            // Act
            // For (1,1), it should escape in 2 iterations.
            // z0 = 0
            // z1 = 1+i, |z1|^2 = 1^2 + 1^2 = 2
            // z2 = (1+i)^2 + (1+i) = (1 + 2i - 1) + (1+i) = 2i + 1+i = 1+3i, |z2|^2 = 1^2+3^2 = 10.
            // Since 10 > settings.radius (4), it escapes at iteration 2.
            int result = Logic.mandelbrot_iterations(1.0, 1.0, settings);

            // Assert
            Assert.AreEqual(2, result, "Point (1,1) should escape in 2 iterations, which is within max iterations 5.");
        }
        
        [TestMethod]
        public void Julia_KnownPoint_IsInSet()
        {
            // Arrange
            var settings = new SettingsTemplate 
            { 
                juliaX = -0.8, 
                juliaY = 0.156, 
                iteration = 200, 
                radius = 4 
            };

            // Act
            // For Julia set J(-0.8, 0.156), the origin (0,0) is in the set.
            // z0 = 0 + 0i
            // z1 = (0)^2 + (-0.8 + 0.156i) = -0.8 + 0.156i, |z1|^2 = 0.64 + 0.024336 = 0.664336
            // z2 = (-0.8 + 0.156i)^2 + (-0.8 + 0.156i) = (0.64 - 0.024336 - 0.2496i) + (-0.8 + 0.156i)
            //    = (0.615664 - 0.2496i) -0.8 + 0.156i = -0.184336 - 0.0936i
            // |z2|^2 = 0.03398 + 0.00876 = 0.04274. This point is in the set.
            int result = Logic.julia_iterations(0.0, 0.0, settings);

            // Assert
            Assert.AreEqual(-1, result, "Point (0,0) should be inside the Julia set J(-0.8, 0.156).");
        }

        [TestMethod]
        public void Julia_KnownPoint_IsOutSideSet()
        {
            // Arrange
            var settings = new SettingsTemplate 
            { 
                juliaX = -0.8, 
                juliaY = 0.156, 
                iteration = 200, 
                radius = 4 
            };

            // Act
            // For C = -0.8 + 0.156i. Point z = 0.5 + 0.5i. Radius = 4.
            // z0 = 0.5 + 0.5i
            // z1 = (0.5+0.5i)^2 + C = (0.5i) + (-0.8+0.156i) = -0.8 + 0.656i. |z1|^2 = 0.64 + 0.430336 = 1.070336
            // z2 = (-0.8+0.656i)^2 + C = (0.64 - 0.430336 - 1.0496i) + C = (0.209664 - 1.0496i) + (-0.8+0.156i) 
            //    = -0.590336 - 0.8936i. |z2|^2 = 0.348496 + 0.79852096 = 1.14701696
            // z3 = (-0.590336 - 0.8936i)^2 + C = (0.348496 - 0.79852096 + 1.05509i) + C 
            //    = (-0.45002496 + 1.05509i) + (-0.8+0.156i) = -1.25002496 + 1.21109i. |z3|^2 = 1.56256 + 1.46673 = 3.02929
            // z4 = (-1.25002496 + 1.21109i)^2 + C = (1.56256 - 1.46673 - 3.0276i) + C 
            //    = (0.09583 - 3.0276i) + (-0.8+0.156i) = -0.70417 - 2.8716i. |z4|^2 = 0.49585 + 8.2461 = 8.74195.
            // Escapes at iteration 4 because |z4|^2 > 4.
            int result = Logic.julia_iterations(0.5, 0.5, settings);

            // Assert
            Assert.AreEqual(4, result, "Point (0.5,0.5) should escape from Julia set J(-0.8, 0.156) in 4 iterations.");
        }
    }
}
