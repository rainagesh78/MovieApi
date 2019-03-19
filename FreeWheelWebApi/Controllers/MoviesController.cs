using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FreeWheel.Service.DataServices;
using FreeWheel.Service.DataService;
using FreeWheel.Service.Infrasturcture.ErrorHandler;

namespace FreeWheel.MovieWebApi.Controllers
{
    [Produces("application/json")]
    
    [Route("api/[controller]/[action]")]
    public class MoviesController : Controller
    {
        private readonly IMovieService _service;
        private readonly IErrorHandler _errorHandler;

        public MoviesController(IMovieService service, IErrorHandler errorHandler)
        {
            _service = service;
            _errorHandler = errorHandler;
        }

        // GET: api/Movies
        [HttpGet]
        [ActionName("FilterMovies")]
        public IActionResult FilterMovies([FromQuery]FilteringParams filteringParams)
        {
            if (string.IsNullOrEmpty(filteringParams.title) && filteringParams.YearOfRelease == 0 && string.IsNullOrEmpty(filteringParams.genres))
            {
                return BadRequest("invalid / no criteria is given.");
            }
            var model = _service.GetMovies(filteringParams);
            
            return model.Count>0? Ok(model.ToList()): StatusCode(404, "no movie is found based on the criteria"); 
        }

        [HttpGet]
        [ActionName("MoviesByRating")]
        public IActionResult MoviesByRating(int topN =5)
        {
            var model = _service.GetTopMoviesByRating();

        
            return model.Count > 0 ? Ok(model.OrderByDescending(a => a.AverageRating).ToList().Take(topN)) : StatusCode(404, "no movie is found based on the criteria");
        }
        [HttpGet]
        [ActionName("MoviesByUser")]
        public IActionResult MoviesByUser(int id, int topN = 5)
        {
            if (id==0)
            {
                return BadRequest("Please pass userid");
            }
            var model = _service.GetTopMoviesByUser(id);

            return model.Count > 0 ? Ok(model.OrderByDescending(a => a.AverageRating).ToList().Take(topN)) : StatusCode(404, "no movie is found based on the criteria");
            
        }

    }
}