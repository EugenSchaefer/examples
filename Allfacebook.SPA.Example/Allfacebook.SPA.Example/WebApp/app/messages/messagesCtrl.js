angular
    .module('allfacebookApp')
    .controller('messagesCtrl',
        function ($rootScope, $scope, $location, $http) {
            $scope.messages = [];           

            $scope.getMessages = function () {
                var result = {};
                var webServiceDefinition = "http://localhost:15425/api/message";

                var config = {
                    method: 'GET',
                    url: webServiceDefinition,
                    cache: false,
                    withCredentials: true
                };

                result = $http(config);
                return result;
            };
            
            $scope.getMessages().then(function(result) {
                $scope.messages = result.data;
            });

            
        });