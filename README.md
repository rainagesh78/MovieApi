# MovieApi
I used database first approach.Please run following scripts to create and seed db.
- DB Create Script.sql
- DB_Initial_data.sql

Api calls
1. Query movie data based on provided filter criteria: title, year of release, genre(s)
   - api/Movies/FilterMovies?title=club&yearofrelease=199
2. Query top 5 movies based on total user rating
    - api/Movies/MoviesByRating?id=3
3. Query top 5 movies based on a certain user’s rating
   - api/Movies/MoviesByUser?id=3
4. Add or update user rating for a movie
  - /api/Rating
   
   body send as jason
     {
        "MovieId": 555,
        "UserId": 4,
        "GivenRating": 5
    }
