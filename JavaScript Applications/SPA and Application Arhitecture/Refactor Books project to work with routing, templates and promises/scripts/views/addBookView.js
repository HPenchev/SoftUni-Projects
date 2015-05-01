var app = app || {};

app.addBookView = (function() {
    function render(selector, book) {
        $.get('templates/book.html', function (template) {
            var output = Mustache.render(template, book);
            $(selector).append(output);
            $('.edit-book:last').on('click', function() {
                app.editBook(event.target);
            });
            $('.delete-book:last').on('click', function() {
                app.deleteBook(event.target);
            });
        });
    }

    return {
        render: function (controller, selector, data) {
            render(controller, selector, data);
        }
    };
}());