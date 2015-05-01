var app = app || {};

(function() {
    var appId = 'VVRYibBfL7oJinkwQqxwYPDUgI2CYHaCTPEHr0ad';
    var restAPIKey = 'fLgZbXqFkdKao7wfXZM9MIJhtrjcQmIiFMs3LmKA';

    var headers = app.headers.load(appId, restAPIKey);
    var requester = app.requester.load();
    var model = app.bookDataModel.load('https://api.parse.com/1/', requester, headers);
    var controller = app.booksController.load(model);


    app.editBook = function(target) {
        var selector = $(target).parent(),
            id = $(selector).attr('id');

        controller.openBookForEdition(selector, id);
    }

    app.deleteBook = function(target) {
        var id = $(target).parent().attr('id');
        controller.deleteBook(id);
    }

    app.router = Sammy(function () {
        var selector = '#wrapper';

        this.get('#/wrapper', function () {
            controller.loadBooks(selector);
        });
    });

    app.router.run('#/wrapper');
    var tempData = {
        where: {
            objectId: 'NNDyBjdPLa'
        }
    }
}());