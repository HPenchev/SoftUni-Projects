var app = app || {};

(function() {
    var requester = app.requester.load();
    var personRepoModel = app.model.load('https://api.parse.com/1/', requester);
    var controller = app.controller.load(personRepoModel),
        selector = '#wrapper';

    controller.loadPeople(selector);
    //console.log(controller);
}());