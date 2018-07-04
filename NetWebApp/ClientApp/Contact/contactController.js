app.controller('contactController', function ($scope, contactService) {

    $scope.contactList = [];
    $scope.selectedContact = {};

    $scope.openAddContactModel = function () {
        $scope.selectedContact = {
            FirstName: '',
            LastName: '',
            Email: '',
            PhoneNumber: ''
        };

        $('#newContact').modal('show');
    }

    $scope.openEditContactModel = function (id) {
        contactService.getContact(id).then(function (result) {
            $scope.selectedContact = result.Data;
        })

        $('#newContact').modal('show');
    }

    $scope.saveContact = function () {

        if ($scope.contactForm.$invalid)
            return;

        if (!$scope.selectedContact.Id)
            contactService.saveContact($scope.selectedContact).then(function (result) {
                init();
                alert('New Contact Saved Successfully!!!');

                $('#newContact').modal('hide');
            })

        else {
            contactService.updateContact($scope.selectedContact).then(function (result) {
                init();
                alert('Contact Updated Successfully!!!');
                $('#newContact').modal('hide');
            })
        }
    }

    $scope.deleteContact = function (id) {
        contactService.deleteContact(id).then(function (result) {
            init();
            alert('Contact Deleted Successfully!!!');
        });
    }


    function init() {
        contactService.getContacts().then(function (result) {
            $scope.contactList = result.Data;
        });
    }

    init();
});