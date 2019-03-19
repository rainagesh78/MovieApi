using FreeWheel.DataAccess.Models;
using FreeWheel.Service.DataService;
using FreeWheelDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreeWheel.Service.DataServices
{
    public interface IMovieService
    {
        List<ResponseModel> GetMovies(FilteringParams filteringParams);
        List<ResponseModel> GetTopMoviesByUser(int userId);

        List<ResponseModel> GetTopMoviesByRating();

        void AddorUpdateRating(Rating rating, bool add);
        bool IsUserExist(int id);
        bool IsMovieExist(int id);
        bool IsRatingExist(int UserId, int MovieId);
    }
}
