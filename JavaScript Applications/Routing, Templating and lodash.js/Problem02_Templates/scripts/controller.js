var app = app || {};

app.controller = (function() {
    function Controller(personRepoModel) {
        this._model = personRepoModel;
    }

    Controller.prototype.loadPeople = function (selector) {
        this._model.getPeople()
            .then(function (data) {
                app.peopleView.load(selector, data);
            },
            function (error) {
                console.log(error);
            })
    };

    return {
        load: function (personModel) {
            return new Controller(personModel);
        }
    }
}());