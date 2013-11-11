angular
    .module('allfacebookApp', ['ngSanitize', 'ui.bootstrap'])
    .config(function($routeProvider, $locationProvider) {
        $routeProvider.
            when('/messages', {
                templateUrl: 'Messages/Index'
            }).
            when('/login', {
                templateUrl: 'Login/Index'
            }).
            when('/', {
                templateUrl: 'Dashboard/Index',
            }).
            otherwise({
                redirectTo: '/'
            });
    });