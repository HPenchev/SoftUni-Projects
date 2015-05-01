var app = app || {};

app.model = (function() {
    function Model(baseUrl, requester) {
        this._baseUrl = baseUrl;
        this.requester = requester;
        this.peopleRepo = {
            people: []
        };
    }

    Model.prototype.getPeople = function () {
        var deffer = Q.defer();
        var _this = this;

        this.peopleRepo.people.length = 0;

        this.requester.get(this._baseUrl + 'classes/Person')
            .then(function (data) {
                data['results'].forEach(function (person) {
                    var personObject = new Person(person.name, person.jobTitle, person.website, person.objectId);
                    _this.peopleRepo.people.push(personObject);
                });
                deffer.resolve(_this.peopleRepo);
            },
            function (error) {
                deffer.reject(error);
            });

        return deffer.promise;
    };

    return {
        load: function (baseUrl, requester) {
            return new Model(baseUrl, requester);
        }
    }
}());