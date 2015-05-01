var app = app || {};

app.editBookView = (function() {

    function render(controller, selector, book) {
        //var selector = $(element).parent();

        if ($(selector).find('.edit-form').length > 0) {
            $(selector).find('.edit-form').remove();

            return;
        }

        $.get('templates/editBook.html', function (template) {
            var def = Q.defer();
            var output = Mustache.render(template, book);
            $(selector).append(output);
            $(selector).find(".update-button").click(function(){
                var clickedButton,
                    attribute,
                    value;

                clickedButton = $(event.target).attr('class');

                if (clickedButton.indexOf('edit-title-button') != -1) {
                    attribute = 'title';
                    value = $(selector).find(".edited-book-name").val();
                } else if (clickedButton.indexOf('edit-author-button') != -1) {
                    attribute = 'author';
                    value = $(selector).find(".edited-author-name").val();
                } else if (clickedButton.indexOf('edit-isbn-button') != -1) {
                    attribute = 'isbn';
                    value = $(selector).find(".edited-isbn").val()
                }

                controller.updateBook(attribute, value, book.objectId)
            })
        })
    }



    function updateTitle(newTitle, id) {
        var temp = $('#' + id).find('.title').text(newTitle);
    }

    function notifyAboutChange(element, updatedValue) {
        element = element.charAt(0).toUpperCase() + element.slice(1);

        alert(element + ' successfully changed to ' + updatedValue);
    }

    return {
        render: function (controller, element, book) {
            render(controller, element, book);
        },

        updateTitle: function (newTitle, id) {
            updateTitle(newTitle, id);
        },

        notifyAboutChange: function(element, updatedValue) {
            notifyAboutChange(element, updatedValue);
        }
    };
}());