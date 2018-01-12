var app = angular.module('CarrollUniversityApp', ['ngRoute']);

app.config(function ($routeProvider) {
    $routeProvider
        .when('/', {
            controller: 'HomeController',
            templateUrl: '/Content/templates/home.html'
        })
        .when('/student/:id?', {
            controller: 'StudentHomeController',
            templateUrl: '/Content/templates/student.html'
        })
        .when('/professor/:id3?', {
            controller: 'ProfessorHomeController',
            templateUrl: '/Content/templates/professor.html'
        })
        .when('/create/course', {
            controller: 'AddCourseController',
            templateUrl: '/Content/templates/addCourse.html'
        })
        .when('/create/building', {
            controller: 'AddBuildingController',
            templateUrl: '/Content/templates/addBuilding.html'
        })
        .when('/create/section', {
            controller: 'AddSectionController',
            templateUrl: '/Content/templates/addSection.html'
        })
        .when('/register/professor', {
            controller: 'RegisterProfessorController',
            templateUrl: '/Content/templates/registerProfessor.html'
        })
        .when('/register/student', {
            controller: 'RegisterStudentController',
            templateUrl: '/Content/templates/registerStudent.html'
        })
        .when('/signUp/:id2', {
            controller: 'SignUpController',
            templateUrl: '/Content/templates/signUp.html'
        })
        .otherwise({
            redirectTo: '/'
        });
});