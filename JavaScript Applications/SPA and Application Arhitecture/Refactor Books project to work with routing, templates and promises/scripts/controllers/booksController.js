var app = app || {};

app.booksController = (function() {
    function BooksController(model) {
        this._model = model;
    }

    BooksController.prototype.loadBooks = function (selector) {
        var _this = this;
        this._model.getBooks()
            .then(function (booksData) {
                var outputData = {
                    books: booksData.results
                };
                app.allBooksView.render(_this, selector, outputData);
            }, function (error) {
                console.log(error.responseText);
            })
    };

    BooksController.prototype.addBook = function (selector, title, author, isbn) {
        var book = {
            title: title,
            author: author,
            isbn: isbn
        };

        this._model.addBook(book)
            .then(function (data) {
                book['objectId'] = data.objectId;
                app.addBookView.render(selector, book);
            }, function (error) {
                console.log(error.responseText);
            })
    };

    BooksController.prototype.openBookForEdition = function (selector, id) {
        var data = {
            where: {
                'objectId' : id
            }
        }

        var _this = this;

        this._model.getBooks(data)
            .then(function (data) {
                var book = data.results[0];
                app.editBookView.render(_this, selector, book);
            }, function (error) {
                console.log(error.responseText);
            })
    };

    BooksController.prototype.updateBook = function (element, value, id) {

        var data = {}
        data[element] = value;

        this._model.editBook(id, data)
            .then(function (data) {
                if (element==='title') {
                    app.editBookView.updateTitle(value, id);
                }

                app.editBookView.notifyAboutChange(element, value);
            }, function (error) {
                console.log(error.responseText);
            })
    };

    BooksController.prototype.deleteBook = function (id) {
        this._model.deleteBook(id)
            .then(function (data) {
                app.deleteBookView.deleteBook(id);
            }, function (error) {
                console.log(error.responseText);
            })
    };

    return {
        load: function (model) {
            return new BooksController(model);
        }
    }
}())