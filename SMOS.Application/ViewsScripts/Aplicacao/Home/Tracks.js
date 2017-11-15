app.controller('TracksCtrl', ['$scope', '$http', function ($scope, $http) {
    $scope.Tracks = [];

    //Valida se usuário esta logado.
    $scope.validaToken = function () {
        ShowOverlay();
        $http.get('Auth/ValidaToken').then(function (response) {
            if (response.data == false) {
                window.location = "/#/Auth";
                HideOverlay();
            } else {
                $scope.getTracks();
            }
        });
    };

    $scope.getTracks = function () {
        $http.get('Tracks/getTracks').then(function (response) {
            if (response.data == false) {
                window.location = "/#/Auth";
            } else {
                angular.forEach(response.data, function (item, key) {
                    $scope.Tracks.push({ Id: key, Name: item })
                });
                $scope.gridOptions.data = $scope.Tracks;
            }
        }).finally(function (response) {
            HideOverlay();
        });;
    };

    $scope.gridOptions = {
        enableFiltering: true,
        enableSorting: true,
        paginationPageSizes: [25, 50, 75],
        paginationPageSize: 25,
        columnDefs: [
            { name: 'Id', field: 'Id' },
            { name: 'Name', field: 'Name' }
        ],
        data: [],
        onRegisterApi: function (gridApi) {
            $scope.gridOptions = gridApi;
        }
    };

}]);