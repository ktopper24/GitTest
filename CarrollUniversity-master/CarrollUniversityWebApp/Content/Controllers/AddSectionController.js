app.controller('AddSectionController', ['$scope', '$http', function ($scope, $http) {

    $scope.reset = function () {
        $scope.section = {};
    };
    
    $scope.addSection = function () {
        $http.post('api/section', $scope.section);
        $scope.reset();
    };

    var gotCourses = function (response) {
        $scope.courses = response.data;
    };

    var gotBuildings = function (answer) {
        $scope.buildings = answer.data;
    };

    var onError = function (reason) {
        $scope.error = "Error";
    };

    $http.get('/api/course')
      .then(gotCourses, onError);

    $http.get('/api/building')
      .then(gotBuildings, onError);


}]);