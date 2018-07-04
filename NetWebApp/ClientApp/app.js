var app = angular.module('myApp', ['ui.router'])

app.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/home');

    $stateProvider

    // HOME STATES AND NESTED VIEWS ========================================
    .state('home', {
        url: '/home',
        templateUrl: "../Clientapp/Contact/contact.html"
    })

    // ABOUT PAGE AND MULTIPLE NAMED VIEWS =================================
    //.state('newcontact', {
    //    url: '/newContact',
    //    templateUrl: "../Clientapp/NewContact/newContact.html"
    //});
});

app.controller('myCtrl', function ($scope) {
    $scope.firstName = 'firstName';
    $scope.lastName = 'lastName';
});
