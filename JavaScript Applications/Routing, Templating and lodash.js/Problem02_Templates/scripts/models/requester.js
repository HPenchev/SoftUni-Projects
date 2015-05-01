var app = app || {};

app.requester = (function () {
    function Requester() {

    }

    Requester.prototype.get = function (url) {
        var defer = Q.defer();

        var headers = {
            'X-Parse-Application-Id' : 'cR0AsZrzFKsQmA2RIQRcE2vQIh00ac2XZPAtNrmk',
            'X-Parse-REST-API-Key' : 'DgEigIRchJ6ueLEJIEHcC90kY4Wz7OyKBEWa1Re8'
        };

        $.ajax({
            url:url,
            method: 'GET',
            contentType: 'application/json',
            headers: headers,
            success: function (data) {
                defer.resolve(data);
            },
            error: function (error) {
                defer.reject(error);
            }
        });

        return defer.promise;
    };

    return {
        load: function () {
            return new Requester();
        }
    }
}());