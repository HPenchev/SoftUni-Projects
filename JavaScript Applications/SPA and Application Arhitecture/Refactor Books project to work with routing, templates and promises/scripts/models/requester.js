var app = app || {};

app.requester = (function() {
    function Requester() {
    }

    Requester.prototype.get = function (url, headers, data) {
        return makeRequest('GET', headers, url, data);
    };

    Requester.prototype.post = function (url, headers, data) {
        return makeRequest('POST', headers, url, JSON.stringify(data));
    };

    Requester.prototype.remove = function (url, headers) {
        return makeRequest('DELETE', headers, url);
    };

    Requester.prototype.edit = function (url, headers, data) {
        return makeRequest('PUT', headers, url, JSON.stringify(data));
    };

    function makeRequest(method, headers, url, data) {
        var deffer = Q.defer();

        $.ajax({
            method: method,
            headers: headers,
            url: url,
            data: data,
            success: function (data) {
                deffer.resolve(data);
            },
            error: function (error) {
                deffer.reject(error);
            }
        });

        return deffer.promise;
    }

    return {
        load: function () {
            return new Requester();
        }
    }
}());