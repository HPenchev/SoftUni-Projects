var app = app || {};

app.allBooksView = (function() {

    function render(controller, selector, data) {
        $.get('templates/allBooks.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).html(output);
        })
            .then(function () {
                $('#submit-new-book').click(function () {

                    var title = $('#new-book-name').val(),
                        author = $('#new-book-author').val(),
                        isbn = $('#new-book-isbn').val();
                    controller.addBook('#books-list', title, author, isbn);

                    $('#new-book-name').val(''),
                    $('#new-book-author').val(''),
                    $('#new-book-isbn').val('');
                })

                $('.edit-book').click(function () {
                    app.editBook(event.target);
                })

                $('.delete-book').click(function () {
                    app.deleteBook(event.target);
                })
            });
    }

    return {
        render: function (controller, selector, data) {
            render(controller, selector, data);
        }
    };
}());

