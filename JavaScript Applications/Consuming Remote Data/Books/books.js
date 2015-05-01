( function() {
    function addBookToList(bookTitle, bookId) {
        var book = $('<li id="' + bookId + '">' + bookTitle + '</li>'),
            editButton = $('<input type="button" value="Edit Book"/>').on('click', function () {
                var bookId = $(event.target).parent().attr('id');

                $.ajax({
                    method: 'GET',
                    headers: {
                        'X-Parse-Application-Id': 'VVRYibBfL7oJinkwQqxwYPDUgI2CYHaCTPEHr0ad',
                        'X-Parse-REST-API-Key': 'fLgZbXqFkdKao7wfXZM9MIJhtrjcQmIiFMs3LmKA'
                    },
                    url: 'https://api.parse.com/1/classes/Book',
                    data: {
                        where: {
                            'objectId': bookId
                        }
                    }
                }).success(function (data) {
                    var editForm = $('<form class="edit-form">'),
                        editTitleLabel = $('<label for="edited-book-name">Book name: </label>'),
                        editTitleInput = $('<input type="text", class="edited-book-name"/><br/>').val(data.results[0]['title']),
                        editTitleButton = $('<input type="button", value="Edit Title"/><br/>').on('click', function () {
                            var updatedTitle = $(event.target).parent().find('.edited-book-name').val();
                            $.ajax({
                                method: 'PUT',
                                headers: {
                                    'X-Parse-Application-Id': 'VVRYibBfL7oJinkwQqxwYPDUgI2CYHaCTPEHr0ad',
                                    'X-Parse-REST-API-Key': 'fLgZbXqFkdKao7wfXZM9MIJhtrjcQmIiFMs3LmKA'
                                },
                                url: 'https://api.parse.com/1/classes/Book/' + bookId,
                                data: JSON.stringify({
                                    'title': updatedTitle
                                })

                            }).success(function() {
                                alert("Title successfully updated to " + updatedTitle);
                            }). error(function(err) {
                                console.log(err.response)
                            })
                        }),
                        editAuthorLabel = $('<label for="edited-book-author">Author: </label>'),
                        editAuthorInput = $('<input type="text", class="edited-book-author"/><br/>').val(data.results[0]['author']),
                        editAuthorButton = $('<input type="button", value="Edit Author"/><br/>'). on('click', function () {
                            var updatedAuthor = $(event.target).parent().find('.edited-book-author').val();
                            $.ajax({
                                method: 'PUT',
                                headers: {
                                    'X-Parse-Application-Id': 'VVRYibBfL7oJinkwQqxwYPDUgI2CYHaCTPEHr0ad',
                                    'X-Parse-REST-API-Key': 'fLgZbXqFkdKao7wfXZM9MIJhtrjcQmIiFMs3LmKA'
                                },
                                url: 'https://api.parse.com/1/classes/Book/' + bookId,
                                data: JSON.stringify({
                                    'author': updatedAuthor
                                })

                            }).success(function() {
                                alert("Author successfully updated to " + updatedAuthor);
                            }). error(function(err) {
                                console.log(err.response)
                            })
                        }),
                        editIsbnLabel = $('<label for="edited-book-isbn">Author: </label>'),
                        editIsbnInput = $('<input type="text", class="edited-book-isbn"/><br/>').val(data.results[0]['isbn']),
                        editIsbnButton = $('<input type="button", value="Edit ISBN"/><br/>').on('click', function () {
                            var updatedIsbn = $(event.target).parent().find('.edited-book-isbn').val();
                            $.ajax({
                                method: 'PUT',
                                headers: {
                                    'X-Parse-Application-Id': 'VVRYibBfL7oJinkwQqxwYPDUgI2CYHaCTPEHr0ad',
                                    'X-Parse-REST-API-Key': 'fLgZbXqFkdKao7wfXZM9MIJhtrjcQmIiFMs3LmKA'
                                },
                                url: 'https://api.parse.com/1/classes/Book/' + bookId,
                                data: JSON.stringify({
                                    'isbn': updatedIsbn
                                })

                            }).success(function() {
                                alert("ISBN successfully updated to " + updatedIsbn);
                            }). error(function(err) {
                                console.log(err.response)
                            })
                        });

                    $(editForm)
                        .append(editTitleLabel)
                        .append(editTitleInput)
                        .append(editTitleButton)
                        .append('<br/>')
                        .append(editAuthorLabel)
                        .append(editAuthorInput)
                        .append(editAuthorButton)
                        .append('<br/>')
                        .append(editIsbnLabel)
                        .append(editIsbnInput)
                        .append(editIsbnButton)
                        .append('<br/>');

                    if ($(book).find('.edit-form').length < 1) {
                        $(book).append(editForm);
                    } else {
                        $(book).find('.edit-form').remove();
                    }
                })
            }),
            deleteButton =  $('<input type="button" value="Delete Book"/>').on('click', function() {
                $.ajax({
                    method: 'DELETE',
                    headers: {
                        'X-Parse-Application-Id': 'VVRYibBfL7oJinkwQqxwYPDUgI2CYHaCTPEHr0ad',
                        'X-Parse-REST-API-Key': 'fLgZbXqFkdKao7wfXZM9MIJhtrjcQmIiFMs3LmKA'
                    },
                    url: 'https://api.parse.com/1/classes/Book/' + bookId
                }).success(function() {
                    $('#' + bookId).remove();
                }). error(function(err) {
                    console.log(err.response)
                })
            });

        $(book).append(editButton).append(deleteButton);
        $('#list-of-books').append(book);
    }

    $.ajax({
        method: 'GET',
        headers: {
            'X-Parse-Application-Id': 'VVRYibBfL7oJinkwQqxwYPDUgI2CYHaCTPEHr0ad',
            'X-Parse-REST-API-Key': 'fLgZbXqFkdKao7wfXZM9MIJhtrjcQmIiFMs3LmKA'
        },
        url: 'https://api.parse.com/1/classes/Book',
        data: {
            keys: 'title'
        }
    }).success(function (data) {
        var wrapper = $('#wrapper'),
            listOfBooks = $('<ul id="list-of-books">'),
            addBookForm = $('<form>'),
            addBookButton = $('<input type="button" value="Submit"/>').on('click', function(e) {
                var newBookTitle = $('#new-book-name').val(),
                    newBookAuthor = $('#new-book-author').val(),
                    newBookIsdn = $('#new-book-isbn').val();

                $.ajax({
                    method: 'POST',
                    headers: {
                        'X-Parse-Application-Id': 'VVRYibBfL7oJinkwQqxwYPDUgI2CYHaCTPEHr0ad',
                        'X-Parse-REST-API-Key': 'fLgZbXqFkdKao7wfXZM9MIJhtrjcQmIiFMs3LmKA',
                        'Content-Type': 'application/json'
                    },
                    url: 'https://api.parse.com/1/classes/Book',
                    data: JSON.stringify({
                        'title': newBookTitle,
                        'author': newBookAuthor,
                        'isbn': newBookIsdn
                    })

                }).success(function(data) {
                    addBookToList(newBookTitle, data['objectId']);
                    $('#new-book-name').val('');
                    $('#new-book-author').val('');
                    $('#new-book-isbn').val('');
                }).error(function(err) {
                    console.log(err.response)
                })
            });

        $(wrapper).append(listOfBooks);
        for (bookNumber in data.results) {
            addBookToList(data.results[bookNumber]['title'], data.results[bookNumber]['objectId']);
        }

        $(addBookForm)
            .append('<div>Add New Book</div>')
            .append('<label for="new-book-name">Book title: </label>')
            .append('<input type="text", id="new-book-name", placeholder="enter book\'s name"/><br/>')
            .append('<label for="new-book-author">Author name: </label>')
            .append('<input type="text", id="new-book-author", placeholder="enter book\'s author"/><br/>')
            .append('<label for="new-book-isdn">ISDN: </label>')
            .append('<input type="text", id="new-book-isbn", placeholder="enter book\'s isdn"/><br/>')
            .append(addBookButton);
        $(wrapper).append(addBookForm);
    }).error(function (err) {
        console.log(err.response)
    });
})()