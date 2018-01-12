app.controller('AddCourseController', ['$scope', '$http', function ($scope, $http) {

    $scope.reset = function () {
        $scope.course = {};
    };

    var gotProfessors = function (answer) {
        $scope.professors = answer.data;
    };

    var onError = function (reason) {
        $scope.error = "Error";
    };

    $scope.addCourse = function () {
        $http.post('api/course', $scope.course);
        $scope.reset();
    };

    $http.get('/api/professor')
      .then(gotProfessors, onError);
  

}]);