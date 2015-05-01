var app = app || {};

app.bookDataModel = (function() {
    function BookDataModel(baseUrl, requester, headers) {
        this._requester = requester;
        this._headers = headers;
        this._serviceUrl = baseUrl + 'classes/Book';
    }

    BookDataModel.prototype.getBooks = function (data) {
        var headers = this._headers.getHeaders();

        return this._requester.get(this._serviceUrl, headers, data);
    };

    BookDataModel.prototype.addBook = function (book) {
        var headers = this._headers.getHeaders();

        return this._requester.post(this._serviceUrl, headers, book);
    };

    BookDataModel.prototype.deleteBook = function (id) {
        var headers = this._headers.getHeaders();

        return this._requester.remove(this._serviceUrl + '/' + id, headers);
    };

    BookDataModel.prototype.editBook = function (id, data) {
        var headers = this._headers.getHeaders();

        return this._requester.edit(this._serviceUrl + '/' + id, headers, data);
    };

    return {
        load: function(baseUrl, requester, headers) {
            return new BookDataModel(baseUrl, requester, headers);
        }
    }
}());