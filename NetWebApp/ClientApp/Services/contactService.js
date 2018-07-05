
app.service('contactService', function ($http, $q) {

    this.getContacts = function () {
        var deferred = $q.defer();

        $http.get(contactUrls.getContacts).then(function (result) {
            deferred.resolve(result.data)
        })

        return deferred.promise;
    }

    this.getContact = function (id) {
        var deferred = $q.defer();

        $http.get(contactUrls.getContacts + '/' + id).then(function (result) {
            deferred.resolve(result.data)
        });

        return deferred.promise;
    }

    this.saveContact = function (contact) {
        var deferred = $q.defer();

        $http.post(contactUrls.saveContact, contact).then(function (result) {
            deferred.resolve(result.data)
        });

        return deferred.promise;
    }

    this.updateContact = function (contact) {
        var deferred = $q.defer();

        $http.put(contactUrls.saveContact, contact).then(function (result) {
            deferred.resolve(result.data)
        });

        return deferred.promise;
    }

    this.deleteContact = function (id) {
        var deferred = $q.defer();

        $http.delete(contactUrls.getContacts + '/' + id).then(function (result) {
            deferred.resolve(result.data)
        });

        return deferred.promise;
    }
});