app.controller('RegisterStudentController', ['$scope', '$http', function ($scope, $http) {

    $scope.reset = function () {
        $scope.student = {};
    };
    $scope.registerStudent = function () {
        $http.post('api/student', $scope.student);
        $scope.reset();
    };
}]);