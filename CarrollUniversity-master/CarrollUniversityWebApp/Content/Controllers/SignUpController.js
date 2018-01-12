app.controller('SignUpController', ['$scope', '$http', '$routeParams', '$location', function ($scope, $http, $routeParams, $location) {
    $scope.studentid = $routeParams.id2;
    $scope.hideCourses = false;
    $scope.hideSections = true;
    var onComplete = function (response) {
        $scope.courses = response.data;
    };

    var whenFinished = function (answer) {
        $scope.sections = answer.data;
    };

    var onError = function (reason) {
        $scope.error = "Error";
    };

    $http.get('/api/course')
      .then(onComplete, onError);


    $scope.getSections = function (Course_Database_ID) {
        url = 'api/section/' + Course_Database_ID;
        $http.get(url)
          .then(whenFinished, onError);
        $scope.hideCourses = true;
        $scope.hideSections = false;
    };

    $scope.signUp = function (Student_ID, Section_ID) {
        url2 = 'api/studentsection/' + Student_ID + '/' + Section_ID;
        $http.post(url2);
        alert("Successfully Signed Up");
        $location.url('/' + $scope.studentid)
    };
}]);