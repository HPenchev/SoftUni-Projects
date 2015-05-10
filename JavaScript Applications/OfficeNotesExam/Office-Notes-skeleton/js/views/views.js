var app = app || {};

app.views = (function() {
    function Views() {
    }

    Views.prototype.loadWelcomeGuestScreen = function (selector) {
        $.get('templates/welcome.html', function(template) {
            var outHtml = Mustache.render(template);
            $(selector).html(outHtml);
        })
    };

    Views.prototype.loadUserHomePage = function (selector, data) {
        $.get('templates/home.html', function(template) {
            var outHtml = Mustache.render(template, data);
            $(selector).html(outHtml);
        })
    };

    Views.prototype.loadRegisterForm = function (controller, selector) {
        $.get('templates/register.html', function(template) {
            var outHtml = Mustache.render(template);
            $(selector).html(outHtml);
            $('#registerButton').on('click', function() {
                var username = $('#username').val(),
                    password = $('#password').val(),
                    fullName = $('#fullName').val();
                controller.register(username, password, fullName);
            })
        })
    };

    Views.prototype.loadLoginForm = function (controller, selector) {
        $.get('templates/login.html', function(template) {
            var outHtml = Mustache.render(template);
            $(selector).html(outHtml);
            $('#loginButton').on('click', function() {
                var username = $('#username').val(),
                    password = $('#password').val();
                controller.login(username, password);
            })
        })
    };
    //
    Views.prototype.displayAddNoteForm = function (controller, selector) {
        $.get('templates/addNote.html', function(template) {
            var outHtml = Mustache.render(template);
            $(selector).html(outHtml);
            $('#addNoteButton').on('click', function() {
                var title = $('#title').val(),
                    text = $('#text').val(),
                    deadline = new Date($('#deadline').val());

                controller.addNote(title, text, deadline);
            })
        })
    };

    Views.prototype.loadEditNoteForm = function (controller, selector, data) {
        var dateArray = data.deadline.split('/');
        data.deadline = dateArray[2] + '-' + dateArray[1] + '-' + dateArray[0];
        console.log(data.deadline);
        $.get('templates/editNote.html', function(template) {
            var outHtml = Mustache.render(template, data);
            $(selector).html(outHtml);
            $('#deadline').val(data.deadline);

            $('#editNoteButton').on('click', function() {
                var title = $('#title').val(),
                    text = $('#text').val(),
                    deadline = new Date($('#deadline').val()),
                    productId = data.objectId;


                controller.editNote(productId, title, text, deadline);
            })
        })
    };

    Views.prototype.loadDeleteNoteForm = function (controller, selector, data) {
        var dateArray = data.deadline.split('/');
        data.deadline = dateArray[2] + '-' + dateArray[1] + '-' + dateArray[0];
        console.log(data.deadline);
        $.get('templates/deleteNote.html', function(template) {
            var outHtml = Mustache.render(template, data);
            $(selector).html(outHtml);
            $('#deadline').val(data.deadline);

            $('#deleteNoteButton').on('click', function() {
                var n = noty({
                    text: 'Are you sure you want to delete this note?',
                    type: 'confirm',
                    layout: 'center',
                    theme: 'defaultTheme',
                    buttons: [
                        {addClass: 'btn btn-primary', text: 'Ok', onClick: function($noty) {

                            $noty.close();
                            controller.deleteNote(data.objectId);
                        }
                        },
                        {addClass: 'btn btn-danger', text: 'Cancel', onClick: function($noty) {
                            $noty.close();
                        }
                        }
                    ]
                });
            })
        })
    };

    Views.prototype.listAllNotesForToday = function (selector, data) {
        $.get('templates/officeNoteTemplate.html', function(template) {
            var outHtml = Mustache.render(template, data);
            $(selector).html(outHtml);
            $('#pagination').pagination({
                items: data.count,
                itemsOnPage: 10,
                cssStyle: 'light-theme',
                hrefTextPrefix: '#/office/'
            }).pagination('selectPage', 1);
        })
    };

    Views.prototype.listAllMyNotes = function (selector, data) {
        $.get('templates/myNoteTemplate.html', function(template) {
            var outHtml = Mustache.render(template, data);
            $(selector).html(outHtml);
            $('#pagination').pagination({
                items: data.count,
                itemsOnPage: 10,
                cssStyle: 'light-theme',
                hrefTextPrefix: '#/myNotes/'
            }).pagination('selectPage', 1);
            $('.edit').on('click', function(event) {
                var parent = $(event.target).parent()[0],
                    noteId = $(parent).attr('data-id');
                window.location.replace('#/edit/' + noteId);
            })
            $('.delete').on('click', function(event) {
                var parent = $(event.target).parent()[0],
                    noteId = $(parent).attr('data-id');
                window.location.replace('#/delete/' + noteId);
            })
        })
    };

    return {
        load: function() {
            return new Views();
        }
    }
}());