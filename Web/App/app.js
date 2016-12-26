
var uri = 'http://localhost:7530';
var app = angular.module('app', [
        // Angular modules
        'ngAnimate',
        'ngRoute'

        // Custom modules

        // 3rd Party Modules
        
])
.config(['$routeProvider', '$locationProvider',
    function ($routeProvider, $locationProvider) {
        $routeProvider
        .when('/', {
            templateUrl: 'Views/home.html',
            controller: 'HomeCtr'
        })
        .when('/author', {
            templateUrl: 'Views/Author.html',
            controller: 'AuthorCtr'
        });
}]);

