var app = angular.module('myApp', ['ui.router'])

app.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/home');

    $stateProvider

    // HOME STATES AND NESTED VIEWS ========================================
    .state('home', {
        url: '/home',
        templateUrl: "../Clientapp/Contact/contact.html"
    })

});
