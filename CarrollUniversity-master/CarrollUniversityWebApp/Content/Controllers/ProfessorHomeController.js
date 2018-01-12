app.controller('ProfessorHomeController', ['$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {
    

    var gotCourses = function (answer) {
        $scope.sections = answer.data;

        $scope.hideCourses = false;

    };

    var onError = function (reason) {
        $scope.error = "Error";
    };

    $scope.reset = function () {
        $scope.professor = {};
    };

    if ($routeParams.id3) {
        $scope.hidelogin = true;

        $http.get('api/course/0/' + $routeParams.id3)
            .then(gotCourses, onError);

    }
    else {
        $scope.hidelogin = false;
        $scope.hideCourses = true;

        $scope.login = function () {
            $http.get('/api/professor?username=' + $scope.professor.username)
                .then(gotProfessor, onError);
        };

        var gotProfessor = function (answer) {
            $scope.user = answer.data;

            if ($scope.user.username) {
                if ($scope.professor.password == $scope.user.password) {
                    alert("Log in successful");
                    $scope.hidelogin = true;

                    $http.get('api/course/0/' + $scope.user.Professor_ID)
                        .then(gotCourses, onError);
                }
                else {
                    alert("Invalid Password");
                    $scope.reset();
                }
            }
            else {
                alert("Invalid Username, please register as a user");
                $scope.reset();
            }

        };

    }
}]);