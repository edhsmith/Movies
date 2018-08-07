// Define the `movies` module
var thisApp = angular.module('movies', []);

thisApp.controller('moviesListController', function ($scope) {
    
    $scope.refresh = function () {

        $scope.movieList = { Movies:[] };
        $scope.movieR = [];

        $.ajax({
            url:"/Main/GetMovies",
            async: true,
            success:function(data){
                $scope.movieList = JSON.parse(data);               
                $scope.$apply();
            }

      });

    };

    $scope.getDetail = function (id, idx) {

        $.ajax({
            url: "/Main/GetMovieDetail/" + id,
            async: true,
            success: function (data) {
                $scope.movieDetail = JSON.parse(data);
                var movieDetail = JSON.parse(data);
                $("#rated" + idx).html(movieDetail.Rated);
                $("#rating" + idx).html(movieDetail.Rating);
                $("#released" + idx).html(movieDetail.Released);
                $("#runtime" + idx).html(movieDetail.Runtime);
                $("#actors" + idx).html(movieDetail.Actors);
                $("#price" + idx).html(movieDetail.Price);
                $("div[controlId=" + idx + "]").removeClass("hidden");
            },
            error: function (jqXHR, textStatus, errorThrown) {               
                alert("get detail error");
            }
        });


    }

    $scope.showDetail = function (id) {
       // $scope.movieDetail = "";
        $.ajax({
            url: "/Main/GetMovieDetail/" + id,
            async: true,
            success: function (data) {
                $scope.movieDetail = JSON.parse(data);
                $scope.$apply();
            },
            error: function (jqXHR,textStatus,errorThrown) {
                $scope.movieDetail = "";
                alert("error");
            }
        });
    };
  
});
