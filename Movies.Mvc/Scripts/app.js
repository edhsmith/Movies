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
