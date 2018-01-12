app.controller('StudentHomeController', ['$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {


    var gotCourses = function (answer) {
        $scope.sections = answer.data;

        $scope.hideCourses = false;

    };

    var onError = function (reason) {
        $scope.error = "Error";
    };

    $scope.reset = function () {
        $scope.student = {};
    };


    if ($routeParams.id) {
        $scope.hidelogin = true;
        $scope.hideSignUp = false;

        $http.get('api/course/' + $routeParams.id)
            .then(gotCourses, onError);

    }
    else {
        $scope.hidelogin = false;
        $scope.hideCourses = true;
        $scope.hideSignUp = true;

        $scope.login = function () {
            $http.get('/api/student?username=' + $scope.student.username)
                .then(gotStudent, onError);
        };

        var gotStudent = function (answer) {
            $scope.user = answer.data;

            if ($scope.user.User) {
                if ($scope.student.password == $scope.user.Password) {
                    alert("Log in successful");
                    $scope.hidelogin = true;
                    $scope.hideSignUp = false;

                    $http.get('api/course/' + $scope.user.Student_ID)
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