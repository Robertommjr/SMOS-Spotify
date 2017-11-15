app.controller('WelcomeCtrl', ['$scope', '$http', function ($scope, $http) {
    $scope.userState = "offline";


    //Valida se usuário esta logado.
    $scope.validaToken = function () {
        ShowOverlay();
        $http.get('Auth/ValidaToken').then(function (response) {
            if (response.data !== false) {
                $scope.userState = "online";
            }
            HideOverlay();
        });
    };
}]);