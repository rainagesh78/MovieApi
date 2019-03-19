using FreeWheel.DataAccess.Models;
using FreeWheel.Service.DataService;
using FreeWheelDataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using FreeWheelDataAccess.Models;
using FreeWheel.DataAccess.Helper;

namespace FreeWheel.Service.DataServices
{

    public class MovieService : IMovieService
    {
        readonly FreeWheelDBContext _dbContext;
        public MovieService(FreeWheelDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ResponseModel Get(long id)
        {
            //return _dbContext.Movies.FirstOrDefault(e => e.MovieId == id);
            throw new NotImplementedException();
        }

        public List<ResponseModel> GetMovies(FilteringParams filteringParams)
        {
           
            var predicate = PredicateBuilder.True<Movie>();
            if (!string.IsNullOrEmpty(filteringParams.title))
            {
                predicate = predicate.And(i => i.Title.ToLower().Contains(filteringParams.title));
            }

            if (!string.IsNullOrEmpty(filteringParams.genres))
            {
                predicate = predicate.And(i => i.Genres.ToLower().Contains(filteringParams.genres));
            }
            if (filteringParams.YearOfRelease > 0)
            {
                predicate = predicate.And(i => i.YearOfRelease == filteringParams.YearOfRelease);
            }
           

            var data = from item in _dbContext.Movies
                         .Include("Ratings")
                         .Where(predicate)
                        .ToList()
                       select new ResponseModel
                       {
                           Id = item.MovieId,
                           Title = item.Title,
                           YearOfRelease = item.YearOfRelease,
                           RunningTime = item.RunningTime,
                           Genres = item.Genres,
                           AverageRating = item.Ratings.Count > 0 ? Math.Round(item.Ratings.Average(s => s.GivenRating)) : 0
                       };

            return data.ToList();

        }

        public List<ResponseModel> GetTopMoviesByRating()
        {
            var data = from item in _dbContext.Movies
                        .Include("Ratings")
                        .ToList()
                       select new ResponseModel
                       {
                           Id = item.MovieId,
                           Title = item.Title,
                           YearOfRelease = item.YearOfRelease,
                           RunningTime = item.RunningTime,
                           Genres = item.Genres,
                           AverageRating = item.Ratings.Count > 0 ? Math.Round(item.Ratings.Average(s => s.GivenRating)) : 0
                       };

            return data.ToList();
        }

        public List<ResponseModel> GetTopMoviesByUser(int userId)
        {
            var data = from item in _dbContext.Movies
                         .Include(m => m.Ratings)
                         .Where(r => r.Ratings.Any(u => u.UserId == userId))
                         .ToList()
                       select new ResponseModel
                       {
                           Id = item.MovieId,
                           Title = item.Title,
                           YearOfRelease = item.YearOfRelease,
                           RunningTime = item.RunningTime,
                           Genres = item.Genres,
                           AverageRating = item.Ratings.Count > 0 ? Math.Round( item.Ratings.Average(s => s.GivenRating)) : 0
                       };

            return data.ToList();
        }

        public bool IsUserExist(int id)
        {
            return _dbContext.Users.Any(u => u.UserId == id);
            

        }

        public bool IsMovieExist(int id)
        {
            return _dbContext.Movies.Any(m => m.MovieId == id);
            
        }
        public bool IsRatingExist(int Userid,int MovieId)
        {
            return _dbContext.Ratings.Any(m => m.UserId==Userid && m.MovieId == MovieId);

        }

        public void AddorUpdateRating(Rating rating,bool add)
        {
            if (add)
            {
                _dbContext.Add(rating);
            }
            else
            {
                _dbContext.Update(rating);
            }
            _dbContext.SaveChanges();
        }

    }
}
