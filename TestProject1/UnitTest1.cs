using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp3;
using System.Linq;

namespace ConsoleApp3.Tests
{
    [TestClass()]
    public class ArrayProcessorTests
    {

        [TestMethod()]
        public void GenerateRandomArrayTest()
        {
            var processor = new ArrayProcessor(3, 5);
            var result = processor.GenerateRandomArray(-10, 10);
            Assert.AreEqual(3, result.GetLength(0)); // HEIGHT
            Assert.AreEqual(5, result.GetLength(1)); // WIDTH
            // Этот тест проверяет только размеры массива, так как значения случайны
        }



        [TestMethod()]
        public void GetCountNegativeElementsInRowTest()
        {
            var processor = new ArrayProcessor(3, 5);
            var arr = new int[,]
            {
                { -1, -2, 0, 4, 5 },
                { 1, 2, 3, -4, -5 },
                { 1, 2, 3, 4, 5 }
            };
            processor.SetArray(arr); // Установка тестового массива в экземпляре processor

            // Теперь метод GetCountNegativeElementsInRow будет использовать установленный массив arr
            Assert.AreEqual(2, processor.GetCountNegativeElementsInRow(0));
            Assert.AreEqual(2, processor.GetCountNegativeElementsInRow(1));
            Assert.AreEqual(0, processor.GetCountNegativeElementsInRow(2));
        }


        [TestMethod()]
        public void IsSaddlePointTest()
        {
            var processor = new ArrayProcessor(3, 5);
            var array = new int[,]
            {
                { 10, 20, 30, 40, 50 },
                { 5, 4, 3, 8, 1 },
                { -1, -2, 0, 4, 5 } 
            };
            processor.SetArray(array); // Установка тестового массива

            Assert.IsFalse(processor.IsSaddlePoint(0, 4));
            Assert.IsTrue(processor.IsSaddlePoint(0, 0));
        }

    }
}
