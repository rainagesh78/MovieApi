using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FreeWheelDataAccess.Context;
using FreeWheelDataAccess.Models;
using FreeWheel.Service.DataServices;
using FreeWheel.Service.Infrasturcture.ErrorHandler;

namespace FreeWheel.MovieWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Ratings")]
    public class RatingsController : Controller
    {
        private readonly IMovieService _service;
        private readonly IErrorHandler _errorHandler;

        public RatingsController(IMovieService service, IErrorHandler errorHandler)
        {
            _service = service;
            _errorHandler = errorHandler;
        }

        // POST: api/Ratings
        [HttpPost]
        [ActionName("api/Ratings/AddOrUpdateRating")]
        public IActionResult AddOrUpdateRating([FromBody] Rating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (rating.UserId <= 0 || rating.MovieId <= 0 )
            {
                return BadRequest("invalid data.Please provide valid MovieId,UserId and rating value.");
            }
            if (!_service.IsUserExist(rating.UserId))
            {
                return NotFound("User not found...");

            }
            if (!_service.IsMovieExist(rating.MovieId))
            {
                return NotFound("Movie not found...");
            }
            if (_service.IsRatingExist(rating.UserId, rating.MovieId))
            {
                _service.AddorUpdateRating(rating, false);
            }
            else {
                _service.AddorUpdateRating(rating, true);

            }

            return Ok("Rating added/updated");
        }


    }
}