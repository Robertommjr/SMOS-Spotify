app.controller('SortPlayListCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.SortPlayList = [];

    //Valida se usuário esta logado.
    $scope.validaToken = function () {
        ShowOverlay();
        $http.get('Auth/ValidaToken').then(function (response) {
            console.log(response);
            if (response.data == false) {
                window.location = "/#/Auth";
                HideOverlay();
            } else {
                $scope.getPlayList();
            }
        });
    };

    $scope.getPlayList = function () {
        $http.get('SortPlayList/getPlayList').then(function (response) {
            if (response.data == false) {
                window.location = "/#/Auth";
            } else {
                angular.forEach(response.data, function (item, key) {
                    $scope.SortPlayList.push({ Id: key, Name: item })
                });
                console.log($scope.SortPlayList );
            }
        }).finally(function (response) {
            HideOverlay();
        });;
    }
}]);