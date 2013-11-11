angular
    .module('allfacebookApp')
    .controller('shellCtrl',
        function($rootScope, $scope, $http) {
            $scope.logout = function() {
                var webServiceDefinition = "http://localhost:15425/api/login/Logout";

                var config = {
                    method: 'GET',
                    url: webServiceDefinition,
                    cache: false,
                    withCredentials: true
                };

                $http(config);
            };

        });