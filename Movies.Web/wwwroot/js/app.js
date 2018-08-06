// Define the `movies` module
var phonecatApp = angular.module('movies', []);

phonecatApp.controller('moviesListController', function($scope) {
    $scope.refresh = function(){

        $.ajax({
            url:"/Main/GetMovies",
            async: false,
            success:function(data){
            $scope.movieList = JSON.parse(data);
            }

      });

    };

    $scope.refresh();

 /*  $.ajax({
            url:"/Main/GetMovies",
            async: false,
            success:function(data){
            $scope.movieList = JSON.parse(data);
            }

      });*/
     
  
});
