var app = app || {};

(function() {
    var appId= 'yL6QsHEBidMCVnqlwS3fA77ZHFmxoJ5qRDGvkf8G';
    var restAPI = 'aUsnemP2T172UXwYgM9lMzVWxUDm4FETHvJmT5pt';
    var baseUrl = 'https://api.parse.com/1/';

    var headers = app.headers.load(appId, restAPI);
    var requester = app.requester.load();
    var model = app.model.load(baseUrl, requester, headers);
    var views = app.views.load();
    var controller = app.controller.load(model, views);

    app.router = Sammy(function () {
        var selector = ('#container')

        this.before( function() {
            var userId = sessionStorage['userId'];
            if(userId) {
                $('#welcomeMenu').text('Welcome, ' + sessionStorage['username']);
                $('#menu').show();
            } else {
                $('#menu').hide();
            }
        });

        this.before('#/', function() {
            var userId = sessionStorage['userId'];
            if(userId) {
                this.redirect('#/home/');
                return false;
            }
        });

        this.before('#/register/', function() {
            var userId = sessionStorage['userId'];
            if(userId) {
                this.redirect('#/home/');
                return false;
            }
        });

        this.before('#/login/', function() {
            var userId = sessionStorage['userId'];
            if(userId) {
                this.redirect('#/home/');
                return false;
            }
        });

        this.before('#/home/', function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                this.redirect('#/');
                return false;
            }
        });

        this.before('#/office/', function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                this.redirect('#/');
                return false;
            }
        });

        this.before('#/myNotes/', function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                this.redirect('#/');
                return false;
            }
        });

        this.before('#/myNotes/:id', function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                this.redirect('#/');
                return false;
            }
        });

        this.before('#/addNote/', function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                this.redirect('#/');
                return false;
            }
        });

        this.before('#/edit/:id', function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                this.redirect('#/');
                return false;
            }
        });

        this.before('#/delete/:id', function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                this.redirect('#/');
                return false;
            }
        });

        this.before('#/logout/', function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                this.redirect('#/');
                return false;
            }
        });

        this.get('#/', function () {
            controller.loadWelcomeGuestScreen(selector);
        });

        this.get('#/register/', function() {
            controller.loadRegisterForm(selector);
        });

        this.get('#/login/', function() {
            controller.loadLoginForm(selector);
        });

        this.get('#/home/', function() {
            controller.loadUserHomePage(selector);
        });

        this.get('#/office/', function() {
            window.location.replace('#/office/1');
        });

        this.get('#/office/:id', function() {
            controller.loadNotesForToday(selector, (parseInt(this.params['id']) - 1) * 10);
        });

        this.get('#/myNotes/', function() {
            window.location.replace('#/myNotes/1');
        });

        this.get('#/myNotes/:id', function() {
            controller.loadMyNotes(selector, (parseInt(this.params['id']) - 1) * 10);
        });

        this.get('#/addNote/', function() {
            controller.loadAddNoteForm(selector);
        });

        this.get('#/edit/:id', function() {
            controller.loadEditNoteForm(selector, this.params['id']);
        });

        this.get('#/delete/:id', function() {
            controller.loadDeleteNoteForm(selector, this.params['id']);
        });

        this.get('#/logout/', function() {
            controller.logout(selector);
        });
    });

    app.router.run('#/');
}());