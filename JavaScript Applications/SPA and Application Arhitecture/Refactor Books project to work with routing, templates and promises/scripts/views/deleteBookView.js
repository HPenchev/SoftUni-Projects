var app = app || {};

app.deleteBookView = (function() {
    function deleteBook(id) {
        $('#' + id).remove();
    }

    return {
        deleteBook: function (id) {
            deleteBook(id);
        }
    };
}());