using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Tests.Features
{
    class RestaurantRater
    {
        private Restaurant _restaurant;
        public RestaurantRater(Restaurant restaurant)
        {
            this._restaurant = restaurant;
        }
        public RatingResult ComputeRating(int p)
        {
            var result= new RatingResult();
            result.Rating = (int)_restaurant.Reviews.Average(r=>r.Rating);
            return result;

        }
    }
}
