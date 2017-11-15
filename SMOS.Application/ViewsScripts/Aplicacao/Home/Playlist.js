app.controller('PlaylistCtrl', ['$scope', '$http', function ($scope, $http) {
    $scope.PlayList = [];

    //Valida se usuário esta logado.
    $scope.validaToken = function () {
        ShowOverlay();
        $http.get('Auth/ValidaToken').then(function (response) {
            if (response.data == false) {
                window.location = "/#/Auth";
                HideOverlay();
            } else {
                $scope.getPlayList();
            }
        });
    };

    $scope.getPlayList = function () {
        $http.get('Playlist/getPlayList').then(function (response) {
            if (response.data == false) {
                window.location = "/#/Auth";
            } else {
                angular.forEach(response.data.Items, function (item, key) {
                    $scope.PlayList.push({ Id: key, Name: item.Name })
                });
            }
        }).finally(function (response) {
            HideOverlay();
        });;
    }

}]);