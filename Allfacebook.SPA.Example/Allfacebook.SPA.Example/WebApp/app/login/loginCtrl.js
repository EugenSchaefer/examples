

angular
    .module('allfacebookApp')
    .controller('loginCtrl',
        function ($rootScope, $scope, $location, $window) {

            $scope.loginWithFacebook = function() {
                var webServiceDefinition = "http://localhost:15425/api/login/ExternalLogin?provider=facebook&returnUrl=messages";
                $window.location.href = webServiceDefinition;
            };
            
            $scope.loginWithTwitter = function () {
                alert('Login with Twitter');
            };
        });
