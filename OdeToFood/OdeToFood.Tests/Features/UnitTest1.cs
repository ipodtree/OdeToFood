using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeToFood.Models;
using System.Collections.Generic;

namespace OdeToFood.Tests.Features
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Computes_Result_For_One_Review()
        {   
            var data=new Restaurant();
            data.Reviews=new List<RestaurantReview>();
            data.Reviews.Add(new RestaurantReview(){Rating=4});

            var rater = new RestaurantRater(data);
            var result = rater.ComputeRating(10);

            Assert.AreEqual(4, result.Rating);
        }

        [TestMethod]
        public void Computes_Result_For_Two_Review()
        {
            var data = new Restaurant();
            data.Reviews = new List<RestaurantReview>();
            data.Reviews.Add(new RestaurantReview() { Rating = 4 });
            data.Reviews.Add(new RestaurantReview() { Rating = 8 });

            var rater = new RestaurantRater(data);
            var result = rater.ComputeRating(10);

            Assert.AreEqual(6, result.Rating);
        }
    }
}
