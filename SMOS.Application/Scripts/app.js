var app = angular.module('app', [
    'ngRoute',
    'ui.grid',
    'ui.grid.pagination'
]);

app.config(function ($routeProvider, $locationProvider) {
    $locationProvider.hashPrefix('');
    $locationProvider.html5Mode(false);
    
    $routeProvider
        .when("/Tracks", {
            templateUrl: "Home/Tracks",
            controller: 'TracksCtrl'
        })
        .when("/Playlist", {
            templateUrl: "Home/Playlist",
            controller: 'PlaylistCtrl'
        })
        .when("/SortPlayList", {
            templateUrl: "Home/SortPlayList",
            controller: 'SortPlayListCtrl'
        })
        .when("/Welcome", {
            templateUrl: "Home/Welcome",
            controller: "WelcomeCtrl"
        })
        .when("/Auth", {
            templateUrl: "Auth/logIn",
            controller: 'AuthCtrl'
        })
        .when("/Profile", {
            templateUrl: "Profile/Index",
            controller: 'ProfileCtrl'
        })
        .when("/Profile", {
            templateUrl: "Profile/Index",
            controller: 'ProfileCtrl'
        })


        .otherwise({ redirectTo: '/Welcome'})
});