app.controller('RegisterProfessorController', ['$scope', '$http', function ($scope, $http) {

    $scope.reset = function () {
        $scope.professor = {};
    };
    $scope.registerProfessor = function () {
        $http.post('api/professor', $scope.professor);
        $scope.reset();
    };
}]);