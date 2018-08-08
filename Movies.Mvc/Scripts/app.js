// Define the `movies` module
var thisApp = angular.module('movies', []);

thisApp.controller('moviesListController', function ($scope) {

    $scope.details = [];

    $scope.refresh = function () {
             
        $scope.details = [];
        loader(true);
        $.ajax({
            url:"/Main/GetMovies",
            async: true,
            success: function (data) {
               
                $scope.movieList = JSON.parse(data);               
                $scope.$apply();
                loader(false);
            },
            error: function (jxXHR, textStatus, errorThrown) {
                loader(false);
                $("#nomovieModal").modal();
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
                var detail = { index: idx, detail: $scope.movieDetail };
                $scope.details.push(detail);
            },
            error: function (jqXHR, textStatus, errorThrown) {               
                $("#NoDetail" + idx).removeClass("hidden");
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

    $scope.identifyCheapest = function () {
        var price = 2147000000;
        var idx = -1;

        for (var i = 0; i < $scope.details.length; i++) {
            var p = Number($scope.details[i].detail.Price);
            if (p < price) {
                price = p;
                idx = $scope.details[i].index;
            }
        }
        if (idx != -1) {
            $("div[controlId=" + idx + "]").addClass("bg-success");
        }

    }
  
});
