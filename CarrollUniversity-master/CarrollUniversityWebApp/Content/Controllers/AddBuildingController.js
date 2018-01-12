app.controller('AddBuildingController', ['$scope', '$http', function ($scope, $http) {

    $scope.reset = function () {
        $scope.building = {};
    };
    $scope.addBuilding = function () {
        $http.post('api/building', $scope.building);
        $scope.reset();
    };
}]);